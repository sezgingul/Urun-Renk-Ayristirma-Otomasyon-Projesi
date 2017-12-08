'Renk ayırma otomasyonu 
'Developed by Sezgin GÜL
'Robimek - 2017 
Imports System.IO
Imports System
Imports System.ComponentModel
Imports System.Threading
Imports System.IO.Ports
Public Class Form1

    Dim data1 = 0
    Dim data2 = 0
    Dim data3 = 0
    Dim data4 = 0
    Dim data5 = 0
    Dim data6 = 0
    Dim myPort As Array
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        myPort = IO.Ports.SerialPort.GetPortNames()

        For i = 0 To UBound(myPort)
            ComboBox1.Items.Add(myPort(i))
        Next
        ComboBox1.Text = ComboBox1.Items.Item(0)

        Button2.Enabled = False
        Button3.Enabled = False
        Button4.Enabled = False

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        TextBox1.Text = 0
        TextBox2.Text = 0
        TextBox3.Text = 0
        TextBox4.Text = 0
        TextBox5.Text = 0
        TextBox6.Text = 0
        TextBox7.Text = 0


        SerialPort1.PortName = ComboBox1.Text
        SerialPort1.BaudRate = 9600
        SerialPort1.DataBits = 8
        SerialPort1.Parity = IO.Ports.Parity.None
        SerialPort1.StopBits = IO.Ports.StopBits.One
       

        SerialPort1.Open()

        Button1.Enabled = False
        Button2.Enabled = True
        Button4.Enabled = True
        Button3.Enabled = False



    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
       

        SerialPort1.Close()

        Button1.Enabled = True
        Button2.Enabled = False
        Button4.Enabled = False
        Button3.Enabled = False

    End Sub
    Private Sub cmbPort_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        If SerialPort1.IsOpen = False Then
            SerialPort1.PortName = ComboBox1.Text
        Else
            MsgBox("BAĞLANTIYI, KAPALIYKEN DEĞİŞTİRİNİZ", vbCritical)
        End If
    End Sub

    Dim carpanx As Integer = 1
    Dim carpany As Integer = 1
    Dim sonportsayisi As Integer = 0
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        myPort = IO.Ports.SerialPort.GetPortNames()
        If sonportsayisi <> myPort.Length Then
            ComboBox1.Items.Clear()
            For i = 0 To UBound(myPort)
                ComboBox1.Items.Add(myPort(i))
            Next
            ComboBox1.Text = ComboBox1.Items.Item(0)

            sonportsayisi = myPort.Length
        End If

    



    End Sub



    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        SerialPort1.Write("8")
        Button4.Enabled = False
        Button3.Enabled = True
        Button1.Enabled = False
        Button2.Enabled = False
        'Timer1.Start()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        SerialPort1.Write("9")
        Button1.Enabled = False
        Button2.Enabled = True
        Button4.Enabled = True
        Button3.Enabled = False
        'Timer1.Stop()
    End Sub
    Dim say As Integer = 0
    Private Sub SerialPort1_DataReceived(sender As Object, e As SerialDataReceivedEventArgs) Handles SerialPort1.DataReceived
        Try
            Dim receiveddata As Integer = SerialPort1.ReadLine()
            Me.Invoke(Sub()
                          If receiveddata = 1 Then
                              data1 = data1 + 1
                              TextBox1.Text = data1
                              TextBox8.Text = "Turuncu"
                              say = 0
                          ElseIf receiveddata = 2 Then
                              data2 = data2 + 1
                              TextBox2.Text = data2
                              TextBox8.Text = "Yeşil"
                              say = 0
                          ElseIf receiveddata = 3 Then
                              data3 = data3 + 1
                              TextBox3.Text = data3
                              TextBox8.Text = "Sarı"
                              say = 0
                          ElseIf receiveddata = 4 Then
                              data4 = data4 + 1
                              TextBox4.Text = data4
                              TextBox8.Text = "Pembe"
                              say = 0
                          ElseIf receiveddata = 5 Then
                              data5 = data5 + 1
                              TextBox5.Text = data5
                              TextBox8.Text = "Kırmızı"
                              say = 0
                          ElseIf receiveddata = 6 Then
                              data6 = data6 + 1
                              TextBox6.Text = data6
                              TextBox8.Text = "Mavi"
                              say = 0
                          ElseIf receiveddata = 0 Then
                              say += 1
                              TextBox8.Text = "Ürün Yok"
                          End If

                          If say > 0 Then
                              SerialPort1.Write("9")
                              Button1.Enabled = False
                              Button2.Enabled = True
                              Button4.Enabled = True
                              Button3.Enabled = False
                              MsgBox(" İşlem Tamamlandı ! ")

                          End If
                          TextBox7.Text = data1 + data2 + data3 + data4 + data5 + data6

                      End Sub)
        Catch ex As Exception

        End Try
     
     
    

    End Sub

  

    
  
    Private Sub PictureBox7_Click(sender As Object, e As EventArgs) Handles PictureBox7.Click
        System.Diagnostics.Process.Start("http://www.robimek.com/arduino-ile-renklerine-gore-urunleri-ayiklama-robotu-yapimi/")
    End Sub
End Class
