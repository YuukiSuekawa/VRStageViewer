# まずはunityちゃんを動かす
[【2019】UNITY-CHAN（ユニティちゃん）を最速で動かす具体的な方法](https://miyagame.net/unity-chan-move/)
1. Unityちゃんのアニメーション変更
+ unitychanのオブジェクトのAnimatorをUnityChanLocomotionsに変更
2. 不要なコンポーネントを非アクティブにする
+ IdleChanger
+ FaceUpdate
3. コンポーネント追加
+ Rigidbody
+ CapsuleCollider
4. CapsuleColliderのコンポーネント修正
Center x:0,y:0.8,z:0  
Radius 0.5  
Height 1.5  
あとはデフォルト
5. スクリプトで管理クラスからキャラコントローラクラスを動かすように指示


# ロボも同じように
[UnityのMecanimでキャラクターを動かす](https://qiita.com/yando/items/601e6fd35002e77ae9c8)

# ステージの設定
[【Unity】NavMeshを学ぶ 焼けた編](https://www.urablog.xyz/entry/2017/10/11/234547)
+ NavigationStatic設定すべてのステージ用に用意したオブジェクトのStatic設定を