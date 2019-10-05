Imports DevExpress.XtraMap
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks
Imports System.Windows.Forms

Namespace InMemoryTileProvider
	Partial Public Class Form1
		Inherits Form

		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
			Dim tileDataProvider As New ImageTileDataProvider()
			tileDataProvider.TileSource = New SimpleTileGenerator()
			Me.imageLayer1.DataProvider = tileDataProvider
		End Sub

		Public Class SimpleTileGenerator
			Implements IImageTileSource

			Private rnd As New Random()
			Public ReadOnly Property CanDisposeSourceImage() As Boolean
				Get
					Return True
				End Get
			End Property
			Public ReadOnly Property Name() As String
				Get
					Return NameOf(SimpleTileGenerator)
				End Get
			End Property

			Public Function GetImage(ByVal x As Integer, ByVal y As Integer, ByVal level As Integer, ByVal size As Size) As Image
				Dim bitmap As New Bitmap(size.Width, size.Height)
				Using gr As Graphics = Graphics.FromImage(bitmap)
					gr.Clear(Color.FromArgb(128, rnd.Next(255), rnd.Next(255), rnd.Next(255)))
					gr.DrawString(String.Format("{0} {1} {2}", x, y, level), New Font("Arial", 10), Brushes.Black, New PointF(5, 5))
				End Using
				Return bitmap
			End Function
		End Class
	End Class
End Namespace
