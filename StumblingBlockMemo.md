# VRStageViewer作成つまづきメモ
このプロジェクトの作成に関してつまづいたところのメモ。  
基本何でも書いていく。  

# Oculus Integrationのインポート時にOVRPluginの新しいやつにするかのダイアログが出る
OVRPluginは元々UnityエディタでのOculusRiftとAndroidのサポートしたもの。  
[OVR Utilities Plugin (OVRPlugin)](https://developer.oculus.com/documentation/unity/latest/concepts/unity-utilities-overview/#ovr-utilities-plugin-ovrplugin)

## 対応
VRに関しては新しいの使ったほうがバグ修正されてそうなのでYes。

# Unity-chan!インポート時にnamespaceエラー
インポートしただけだとエラーが出てしまう。  
## エラー内容
Assets\ImportAssets\unity-chan!\Unity-chan! Model\Scripts\AutoBlink.cs(8,23): error CS0234: The type or namespace name 'Policy' does not exist in the namespace 'System.Security' (are you missing an assembly reference?)
## 解決方法
System.Security.Policyのクラス使ってないようなので、コメント化で対応。


# ロボモデル配置しただけの3DプロジェクトでビルドしたAPKがOculusQuestで落ちる
ビルド時にエラー出てた  
## エラー内容
+ BuildFailedException: XR is currently not supported when using the Vulkan Graphics API. Please go to PlayerSettings and remove 'Vulkan' from the list of Graphics APIs.
+ 和訳「BuildFailedException：Vulkan Graphics APIを使用している場合、XRは現在サポートされていません。 PlayerSettingsに行き、グラフィックAPIのリストから「Vulkan」を削除してください。」

つまりVulkanが邪魔。
## 解決方法
OtherSettingsのGraphicsAPIsからVulkanを削除。  
[参考：UnityでVRアプリを作ったら上下が逆転してしまった](https://qiita.com/Ihal/items/5135521915b70d9c0e91)