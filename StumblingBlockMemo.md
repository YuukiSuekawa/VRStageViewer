# VRStageViewer作成つまづきメモ
このプロジェクトの作成に関してつまづいたところのメモ。  
基本何でも書いていく。  

# ロボモデル配置しただけの3DプロジェクトでビルドしたAPKがOculusQuestで落ちる
ビルド時にエラー出てた  
+ BuildFailedException: XR is currently not supported when using the Vulkan Graphics API. Please go to PlayerSettings and remove 'Vulkan' from the list of Graphics APIs.
+ 和訳「BuildFailedException：Vulkan Graphics APIを使用している場合、XRは現在サポートされていません。 PlayerSettingsに行き、グラフィックAPIのリストから「Vulkan」を削除してください。」

つまりVulkanが邪魔。
## 解決方法
OtherSettingsのGraphicsAPIsからVulkanを削除。  
[参考：UnityでVRアプリを作ったら上下が逆転してしまった](https://qiita.com/Ihal/items/5135521915b70d9c0e91)