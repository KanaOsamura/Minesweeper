# Minesweeper
### 概要

社内研修で作成した、デスクトップアプリケーションのマインスイーパーです。
マウスを使用して遊ぶことができます。  
左クリックでブロックの中身が明かされ、右クリックで、”旗”（爆弾確定）→”？”（検討中）のようにブロックに印をつけることができます。"？"のときに右クリックすると元の状態に戻ります。
また、ブロックにマークがついていないときのみ左クリックで中身を見ることができます。  
このゲームの勝利条件は、全ての爆弾の位置を推測し、正しい位置に、右クリックで旗を立てることです。  
ゲーム終了時、スコアがメッセージボックスで表示されます。
スコアは時間経過による減算と、暴いた爆弾個数による加算の合計値で決まります。  
データベースに接続するためのプログラムは研修で教えていただいたものをそのまま使用しているため、リポジトリから抜いております。

<img src = "https://github.com/user-attachments/assets/d77ca9f8-a6f6-4399-8af7-c690163a9dc0" width="50%">

### 開発期間
‎2024‎年‎7‎月‎3‎日～‎2024‎年‎7‎月‎5‎日

### OS
Windows

### 開発環境
Visual Studio 2022、sqlserver

### 開発言語
C#、SQL

### クラスの説明
Program : 複数のクラスで扱う変数や、インスタンス化しないプログラムなど。

Form1 : フォームやラベル、ボタンなどコントロールの操作に関するプログラム。

Block : マインスイーパーのブロック1つのプログラム。設定したブロックの数だけインスタンス化して使用する。PictureBoxを継承している。

BlockImages : ブロックの画像を呼び出すためのプログラム。

Rdb(リポジトリに入れておりません) : データベースの接続や、接続エラーに対する処理のプログラム。

### データベースなしver
ビルドして遊べるよう、データベースに関するコードを消したバージョンのプログラムを作成しました。

https://github.com/KanaOsamura/Minesweeper/tree/deleteRdbCode
