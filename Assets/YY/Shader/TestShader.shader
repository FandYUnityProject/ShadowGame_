Shader "Custom/TestShader" {

	// 変数みたいなもの
	Properties {

		// Inpectorに”Main Color”という名前で、色を指定できるようにする
		_SimpleColor ( "Main Color", COLOR ) = (0,0,1,1)
		// Inpectorに”Base Texture”という名前で、テクスチャを設定できるようにする
		_MainTex("Base Texture", 2D) = "white" {}	// デフォルトは白
	}
	SubShader {
		
		// オブジェクトのレンダリング
		Pass{
			// マテリアルの定義
			Material{
				Diffuse[_SimpleColor]
				Ambient[_SimpleColor]
			}
			// 標準ライティングの適用
			Lighting On
			
			// テクスチャーは色を決める最終段階で処理をするのでコードの最後
			// { Combine ... } どのように色を結合するか設定
			// DOUBLE 照明の強度を2倍高める
			SetTexture[_MainTex]{ Combine texture* primary DOUBLE }
		}
	}
	Fallback "OtherShader"
}
