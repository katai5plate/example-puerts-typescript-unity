# Example-Puerts-TypeScript-Unity

Puerts + TypeScript を使って Unity 開発を行うサンプルプロジェクトです。  
これを元に開発を始めることもできます。

## Usage

記載のコマンドは基本的に Windows 環境です。

- 必要なもの
  - Git
    - リポジトリの DL に必要
  - Node.js
    - TypeScript 開発に必要
  - VSCode
    - TypeScript 開発に最適
- なくてもいいけど、この次で使うもの
  - curl
    - 必須ファイルの DL に必要
  - wget
    - 必須ファイルの DL に必要
  - jq
    - 必須ファイルの DL に必要
  - 7zip (コマンドライン)
    - 必須ファイルの解凍に必要
- あると便利なもの
  - Visual Studio
    - C# はこっちで書いたほうがいい

### 準備

- [リポジトリをダウンロード](https://github.com/katai5plate/example-puerts-typescript-unity/archive/refs/heads/main.zip)して解凍するか、クローンする。
  - **このリポジトリを元に新たにゲームを作る場合は、ダウンロードするほうがおすすめ。** (`.git` がついてこないので)
  - ダウンロードする場合は解凍したディレクトリをコマンドプロンプトで開く。
  - クローンする場合は以下のコマンドを実行。

```
git clone --depth 1 https://github.com/katai5plate/example-puerts-typescript-unity.git
cd example-puerts-typescript-unity
```

この先はどちらか好きなほうを。

#### 自動で行う

- Windows 環境なら `./init.bat` を管理者実行すれば、よしなにやってくれます。
  - 実行には `git, curl, wget, jq, 7z` をコマンドプロンプトから実行できる Windows 環境が必要です。
- 手動の `(※)` の部分は自動でやってくれないので自分でやってください。
- 失敗したら諦めて手動でやってください。

#### 手動で行う

- リポジトリ `Tencent/puerts` と `chexiongsheng/puerts_unity_demo` を落とす。

```
git clone --depth 1 https://github.com/Tencent/puerts.git
git clone --depth 1 https://github.com/chexiongsheng/puerts_unity_demo.git
```

- 最新の Plugins_Nodejs も落として解凍する。 (以降便宜上、`Plugins_Nodejs_latest` と呼ぶ)
  - [手動でやる場合はここで `Node` とあるものを選ぶ。](https://github.com/Tencent/puerts/releases)
  - 以下のコマンドは `curl, jq, wget, 7z` で頑張るとき用。

```
curl -s https://api.github.com/repos/Tencent/puerts/releases/latest > puerts_releases_latest.txt
type puerts_releases_latest.txt | jq -r ".assets[] | select(.name | contains(\"Plugins_Nodejs\")) | .browser_download_url" > puerts_latest_url.txt
wget -i puerts_latest_url.txt -O Plugins_Nodejs_latest.tgz
7z x Plugins_Nodejs_latest.tgz && 7z x Plugins_Nodejs_latest.tar -oPlugins_Nodejs_latest
```

1. `./puerts/unity/Assets/Puerts` を `./Assets/Puerts` としてコピー
2. `./puerts/unity/Assets/Plugins` を `./Assets/PuertsPlugins` としてコピー
3. `./Plugins_Nodejs_latest/Plugins` の中身を `./Assets/PuertsPlugins` にコピー

- 4 (※) `./puerts_unity_demo/Assets/Plugins` には前述の Plugins には無いものも含まれているので、もし必要なら `./Assets/PuertsPlugins` にコピー
- 5 (※) `./puerts_unity_demo/Assets/Examples/Editor` には Config ファイルがいくつか用意されているので、もし必要なら `./Assets/Editor/PuertsConfig.cs` としてコピー/上書き

以下のような感じに配置できてたら完了。

```
├───Assets
│   ├───Editor (5)
│   │       PuetsConfig.cs (5)
│   ├───Puerts (1)
│   │   ├───Src
│   │   └───Typing
│   ├───PuertsPlugins (2) (3) (4)
│   │   ├───macOS
│   │   ├───x86
│   │   └───x86_64 などなど
│   ├───Scenes
│   └───Scripts
│           JSLoader.cs
├───Packages
├───ProjectSettings
├───TypeScript
│   │   copyJsFile.js
│   │   package.json
│   │   tsconfig.json
│   └───src
└───UserSettings
```

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
