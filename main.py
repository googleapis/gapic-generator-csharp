import os
import subprocess
import re
import shutil

# --- Configuration ---
_PROJECTS_DIR = "{_PROJECTS_DIR}"
_REPO_NAME = "{_REPO_NAME}"

BOT_KEYWORDS = {'bot', 'dependabot', 'renovate', 'jenkins', 'ci', 'automation', 'github-actions'}

def is_bot(name, email):
    """Checks if the user is a bot."""
    if '[bot]' in name.lower(): return True
    for k in BOT_KEYWORDS:
        if k in name.lower() or k in email.lower(): return True
    return False

def fetch_github_username(email):
    """
    Fetches GitHub username via CLI with 'in:email' precision.
    Falls back to email prefix on failure.
    """
    default_handle = email.split('@')[0]

    if not shutil.which("gh"):
        return default_handle

    try:
        # Use -f to safely format the query parameters
        cmd = [
            "gh", "api", "search/users", 
            "-f", f"q={email} in:email", 
            "--jq", ".items[0].login"
        ]
        
        # check=False prevents crashing on 404s
        result = subprocess.run(cmd, capture_output=True, text=True, check=False)
        
        if result.returncode != 0:
            return default_handle
            
        username = result.stdout.strip()
        
        if not username or username == "null":
            return default_handle
            
        return username

    except Exception:
        return default_handle

def get_top_contributors(folder_path, limit=3):
    """
    Returns a list of the top N non-bot contributors' handles.
    """
    contributors = []
    
    try:
        # git shortlog sorts by commit count descending
        cmd = ["git", "shortlog", "-sne", "--no-merges", "--", folder_path]
        result = subprocess.run(cmd, capture_output=True, text=True, check=True)
        
        output = result.stdout.strip()
        if not output:
            return []
            
        lines = output.split('\n')

        for line in lines:
            # Stop if we already have enough contributors
            if len(contributors) >= limit:
                break
                
            line = line.strip()
            if not line: continue

            # Regex parse: "105  Name Name <email@domain.com>"
            match = re.search(r'^\d+\s+(.+?)\s+<(.+)>', line)
            
            if match:
                name = match.group(1)
                email = match.group(2)

                # 1. Skip Bots
                if is_bot(name, email):
                    continue

                # 2. Get Handle
                handle = fetch_github_username(email)
                
                # 3. Add to list if unique
                # (Prevents duplicates if one user has multiple emails)
                if handle not in contributors:
                    contributors.append(handle)
            
        return contributors

    except subprocess.CalledProcessError:
        return []

def main():
    root_dir = "."
    print("Generating config with top 3 contributors...")
    
    items = os.listdir(root_dir)
    folders = [d for d in items if os.path.isdir(d) and not d.startswith('.')]
    folders.sort()

    for folder in folders:
        # Get list of top 3 handles
        contributor_list = get_top_contributors(folder, limit=3)
        
        # Reviewers list remains empty as per requirement
        reviewers_list = []

        key_string = f"f'{_PROJECTS_DIR}/{_REPO_NAME}/{folder}/*'"
        value_list = [reviewers_list, contributor_list]
        
        print(f"{key_string}: {value_list},")

if __name__ == "__main__":
    main()