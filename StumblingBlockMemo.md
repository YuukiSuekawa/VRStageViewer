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

# カッコ付きのインポートアセットのフォルダがGitでAddしようとしたときにエラーになる
## エラー内容
the following problems have occured when adding the files "(X&Y)AAAAAA" did not mach any files.

## 解決方法
アセット内フォルダに()と&があったのでそこをリネームして再起動。(リネームするだけだとRider側がフォルダ名保持していたため再起動)

# 実機の時にposition指定の移動がうまく動かない
## 内容
プレイヤーオブジェクト(OVRPlayerController)のTransformのpositionに移動箇所の位置を指定しても何故か変な場所に動いてしまう。

## 解決方法
OVRPlayerController内で常時カメラの位置をUpdateかけているため、一時的にOVRPlayerControllerをdisable状態にする。
移動処理後、enableに戻す。

# 実機のみ移動直後のLookAtで向きを変えると傾いていく
## 内容
中心を向かせるためにVector3.zeroで指定していると移動するたびに傾きが反映されてしまっていた。

## 解決方法
自分の高さと同じようにするためにnew Vector3(0,自身のオブジェクトのY,0)として水平に向くように修正。

