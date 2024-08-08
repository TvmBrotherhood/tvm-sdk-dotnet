# Function to find the latest release based on a postfix
filter_latest_release() {
  local postfix=$1
  local releases=$2
  
  # Find the latest release
  local latest_release
  latest_release=$(echo "$releases" | jq --arg postfix "$postfix" '
    map(select(.tag_name | endswith($postfix)))
    | sort_by(.published_at) 
    | last
    | { tag_name, tarball_url, name }
  ')
  
  echo "$latest_release"
}

build_sdk() {
  local latest_release=$1
  local project_name=$2
  local output_archive_filename="sdk.tar.gz"
  local tarball_url=$(echo $latest_release | jq -r '.tarball_url')
  
  curl -L -o "$output_archive_filename" "$tarball_url"
  tar xvf "$output_archive_filename" > /dev/null 2>&1
  rm $output_archive_filename
  directory=$(ls -d */ | grep -v '/\.$')
  api_path="$(echo $PWD)/$(echo $directory)tools/api.json"
  cd "../tools/TvmSdk.ClientGenerator"
  dotnet run "$PWD" "$project_name" "$api_path"
  rm -r "../../scripts/$directory"
  cd ../../scripts
}

# Configuration
REPO_OWNER="tvmlabs"
REPO_NAME="tvm-sdk"

# Fetch releases
releases=$(curl -s "https://api.github.com/repos/${REPO_OWNER}/${REPO_NAME}/releases")

# Remove control characters using tr
cleaned_releases=$(echo "$releases" | tr -d '\000-\031')

latest_release_an=$(filter_latest_release ".an" "$cleaned_releases")
latest_release_ever=$(filter_latest_release ".ever" "$cleaned_releases")
latest_release_ton=$(filter_latest_release ".ton" "$cleaned_releases")

echo "AckiNacki: $latest_release_an"
echo "Everscale: $latest_release_ever"
echo "TON: $latest_release_ton"

build_sdk "$latest_release_an" "TvmSdk.AckiNacki"
build_sdk "$latest_release_ever" "TvmSdk.Everscale"
build_sdk "$latest_release_ton" "TvmSdk.Ton"
