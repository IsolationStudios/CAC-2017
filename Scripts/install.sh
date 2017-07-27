echo 'Downloading package'
curl -o Unity.pkg https://unity3d.com/get-unity/download?thank-you=update&download_nid=47505&os=Mac

echo 'Installing'
sudo installer -dumplog -package Unity.pkg -target /
