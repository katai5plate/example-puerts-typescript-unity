# Example-Puerts-TypeScript-Unity

Puerts + TypeScript を使って Unity 開発を行うサンプルプロジェクトです。これを元に開発を始めることもできます。

## Usage

記載のコマンドは基本的に Windows 環境です。

### 準備

- まずクローンして落とす。

```
git clone --depth 1 https://github.com/katai5plate/example-puerts-typescript-unity.git
cd example-puerts-typescript-unity
```

- 次に関連リポジトリを落とす。

```
git clone --depth 1 https://github.com/Tencent/puerts.git
git clone --depth 1 https://github.com/chexiongsheng/puerts_unity_demo.git
```

- 関連ファイルも落として解凍する。 (便宜上、以後、解凍したものは `Plugins_Nodejs_latest` とする)
  - [手動でやる場合はここで `Node` とあるものを選ぶ。](https://github.com/Tencent/puerts/releases)
  - 以下のコマンドは Windows 環境で curl, jq, wget, 7zip で頑張るとき用。

```
curl -s https://api.github.com/repos/Tencent/puerts/releases/latest > puerts_releases_latest.txt
type puerts_releases_latest.txt | jq -r ".assets[] | select(.name | contains(\"Plugins_Nodejs\")) | .browser_download_url" > puerts_latest_url.txt
wget -i puerts_latest_url.txt -O Plugins_Nodejs_latest.tgz
7z x Plugins_Nodejs_latest.tgz && 7z x Plugins_Nodejs_latest.tar -oPlugins_Nodejs_latest
```

- `./puerts/unity/Assets/Puerts` を `./Assets/Puerts` としてコピー
- `./puerts/unity/Assets/Plugins` を `./Assets/PuertsPlugins` としてコピー
- `./Plugins_Nodejs_latest/Plugins` の中身を `./Assets/PuertsPlugins` にコピー
  - `./puerts_unity_demo/Assets/Plugins` には前述の Plugins には無いものも含まれているので、もし必要ならコピー
- `./puerts_unity_demo/Assets/Examples/Editor` には Config ファイルがいくつか用意されているので、もし必要なら `./Assets/Editor/PuertsConfig.cs` としてコピー/上書き

### 初期設定

#### Unity

- このプロジェクトを開く。
- トップバーに追加されている `Puerts` から `Generate index.d.ts` をクリック。
  - 型定義ファイルが生成される。今後 C# 側でクラスを増やしたら都度行う。

#### VSCode

- VSCode で `./TypeScript/` をディレクトリから開く。
- 以下を実行する。
  - build を実行すると TypeScript がコンパイルされ、`./Assets/Resources/js` にコピーされる

```
npm i
npm run build
```

### 作業開始

- TypeScript を書く作業を開始するときは、以下を実行する。
  - 実行中にファイルに変更を加えると自動で build が走る。

```
npm run dev
```