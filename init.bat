git clone --depth 1 https://github.com/Tencent/puerts.git
git clone --depth 1 https://github.com/chexiongsheng/puerts_unity_demo.git

curl -s https://api.github.com/repos/Tencent/puerts/releases/latest > puerts_releases_latest.txt
type puerts_releases_latest.txt | jq -r ".assets[] | select(.name | contains(\"Plugins_Nodejs\")) | .browser_download_url" > puerts_latest_url.txt
wget -i puerts_latest_url.txt -O Plugins_Nodejs_latest.tgz
7z x Plugins_Nodejs_latest.tgz && 7z x Plugins_Nodejs_latest.tar -oPlugins_Nodejs_latest

echo D | xcopy /e/y "./puerts/unity/Assets/Puerts" "./Assets/Puerts"
echo D | xcopy /e/y "./puerts/unity/Assets/Plugins" "./Assets/PuertsPlugins"
echo D | xcopy /e/y "./Plugins_Nodejs_latest/Plugins" "./Assets/PuertsPlugins"