Imports PackageIO
Imports System.IO
Imports System.Net
Public Class Form1
    Dim Zeldasave As String
    Private pInititialized As Boolean
    Private IsFormBeingDragged As Boolean = False
    Private MousedwnX As Integer
    Private MousedwnY As Integer
    Dim applicationpath = Application.StartupPath
    Dim CRC32Data1 = &H0
    Dim Actualworld = &H0
    Dim Sector = &H4
    Dim Zonename = &HC
    Dim Stoyprogress = &H40
    Dim Actuahearts = &HC0
    Dim Maxhearts = &HC1
    Dim Heartfragments = &HC2
    Dim Bottle1item = &HC3
    Dim Bottle2item = &HC4
    Dim Bottle3item = &HC5
    Dim Bottle4item = &HC6
    Dim Bottle5item = &HC7
    Dim Swordupgrad = &HC8
    Dim Shield = &HC9
    Dim Bombs = &HCA
    Dim Boomerang = &HCB
    Dim Bow = &HCC
    Dim Bowoflight = &HCD
    Dim Hammer = &HCE
    Dim Sandrod = &HCF
    Dim Firerod = &HD0
    Dim Icerod = &HD1
    Dim Tornadorod = &HD2
    Dim Hookshot = &HD3
    Dim Lamp = &HD4
    Dim Net = &HD5
    Dim Hintglasses = &HD6
    Dim Irenesbell = &HD7
    Dim Scootfruit = &HD8
    Dim Foulfruit = &HD9
    Dim Bottle1 = &HDA
    Dim Bottle2 = &HDB
    Dim Bottle3 = &HDC
    Dim Bottle4 = &HDD
    Dim Bottle5 = &HDE
    Dim Raviobracelet = &HDF
    Dim Pendwisdom = &HE0
    Dim Pendpower = &HE1
    Dim Pendcourage = &HE2
    Dim Amulet = &HE3
    Dim Zoraflippers = &HE4
    Dim Smoothgem = &HE5
    Dim Powerglove = &HE6
    Dim Tunic = &HE7
    Dim Pegasusboots = &HE8
    Dim Beebadge = &HE9
    Dim Coiledsword = &HEC
    Dim Staminascroll = &HEE
    Dim Pouch = &HEF
    Dim Monstertail = &H18B
    Dim Monstergust = &H18C
    Dim Monsterhorn = &H18D
    Dim Rupee = &H18E
    Dim Lostmaiamai = &H190
    Dim Dungeonmaiamai = &H4E0
    Dim Savename = &HD60
    Dim CRC32_1 = &HDFC
    Dim CRC32Data2 = &HE00
    Dim CRC32_2 = &H13FC
    Dim CRC32Data3 = &H1400
    Dim CRC32_3 = &H15FC

    Private Sub Closebutton_Click(sender As Object, e As EventArgs) Handles Closebutton.Click
        Me.Close()
    End Sub

    Private Sub Closebutton_MouseMove(sender As Object, e As MouseEventArgs) Handles Closebutton.MouseMove
        Closebutton.Image = My.Resources.close_red_tl
    End Sub

    Private Sub Closebutton_MouseLeave(sender As Object, e As EventArgs) Handles Closebutton.MouseLeave
        Closebutton.Image = My.Resources.close_tl
    End Sub

    Private Sub TLSE_header_MouseDown(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles TLSE_header.MouseDown, TLSE_title.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Left Then
            IsFormBeingDragged = True
            MousedwnX = e.X
            MousedwnY = e.Y
        End If
    End Sub

    Private Sub TLSE_header_MouseUp(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles TLSE_header.MouseUp, TLSE_title.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Left Then
            IsFormBeingDragged = False
        End If
    End Sub

    Private Sub TLSE_header_MouseMove(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles TLSE_header.MouseMove, TLSE_title.MouseMove
        If IsFormBeingDragged = True Then
            Dim tmp As Point = New Point()
            tmp.X = Me.Location.X + (e.X - MousedwnX)
            tmp.Y = Me.Location.Y + (e.Y - MousedwnY)
            Me.Location = tmp
            tmp = Nothing
        End If
    End Sub

    Private Sub Minimizebutton_Click(sender As Object, e As EventArgs) Handles Minimizebutton.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub Minimizebutton_MouseMove(sender As Object, e As MouseEventArgs) Handles Minimizebutton.MouseMove
        Minimizebutton.Image = My.Resources.minimize_gray
    End Sub

    Private Sub Minimizebutton_MouseLeave(sender As Object, e As EventArgs) Handles Minimizebutton.MouseLeave
        Minimizebutton.Image = My.Resources.minimize
    End Sub

    Private Sub Text_menu_open_Click(sender As Object, e As EventArgs) Handles Text_menu_open.Click
        Dim open As New OpenFileDialog
        open.Title = "Open Save_0.bin, Save_1.bin, or Save_2.bin"
        open.ShowDialog()
        Zeldasave = open.FileName
        readzeldasave()
        Text_menu_save.Visible = True
    End Sub

    Public Sub Hidemenu()
        Menu_linkstatus.BackgroundImage = My.Resources.bg_menuitems_off
        Menu_inventory.BackgroundImage = My.Resources.bg_menuitems_off
        Menu_storymap.BackgroundImage = My.Resources.bg_menuitems_off
        Menu_manual.BackgroundImage = My.Resources.bg_menuitems_off
        Menu_settings.BackgroundImage = My.Resources.bg_menuitems_off
    End Sub

    Public Sub Hidepanel()
        Panel_linkstatus.Visible = False
        Panel_inventory.Visible = False
    End Sub

    Public Sub readzeldasave()
        Try
            Dim Reader As New PackageIO.Reader(Zeldasave, PackageIO.Endian.Little)
            Reader.Position = CRC32Data1
            Text_datacrc32_z1.Text = Reader.ReadHexString(&HDFC)
            Reader.Position = Rupee
            valu_ruppe.Value = Reader.ReadUInt16
            Reader.Position = Lostmaiamai
            valu_lostmaiamai.Value = Reader.ReadByte
            Reader.Position = Monstertail
            valu_monstertail.Value = Reader.ReadByte
            Reader.Position = Monsterhorn
            valu_monsterhorn.Value = Reader.ReadByte
            Reader.Position = Monstergust
            valu_monstergust.Value = Reader.ReadByte
            Reader.Position = Actuahearts
            valu_currenthearts.Value = Reader.ReadByte
            Reader.Position = Maxhearts
            valu_maxhearts.Value = Reader.ReadByte
            Reader.Position = Savename
            Text_savename.Text = Reader.ReadUnicodeString(10)
            Reader.Position = Actualworld
            valu_actualworld.Value = Reader.ReadByte
            Reader.Position = Sector
            valu_sector.Value = Reader.ReadByte
            Reader.Position = Bombs
            valu_bombs.Value = Reader.ReadByte
            Reader.Position = Boomerang
            valu_boomerang.Value = Reader.ReadByte
            Reader.Position = Bow
            valu_bow.Value = Reader.ReadByte
            Reader.Position = Bowoflight
            valu_bowoflight.Value = Reader.ReadByte
            Reader.Position = Hammer
            valu_hammer.Value = Reader.ReadByte
            Reader.Position = Sandrod
            valu_sandrod.Value = Reader.ReadByte
            Reader.Position = Firerod
            valu_firerod.Value = Reader.ReadByte
            Reader.Position = Icerod
            valu_icerod.Value = Reader.ReadByte
            Reader.Position = Tornadorod
            valu_tornadorod.Value = Reader.ReadByte
            Reader.Position = Hookshot
            valu_hookshot.Value = Reader.ReadByte
            Reader.Position = Lamp
            valu_lamp.Value = Reader.ReadByte
            Reader.Position = Net
            valu_net.Value = Reader.ReadByte
            Reader.Position = Hintglasses
            valu_hintglasses.Value = Reader.ReadByte
            Reader.Position = Scootfruit
            valu_scootfruit.Value = Reader.ReadByte
            Reader.Position = Foulfruit
            valu_foulfruit.Value = Reader.ReadByte
            Reader.Position = Bottle1
            valu_bottle1.Value = Reader.ReadByte
            Reader.Position = Bottle2
            valu_bottle2.Value = Reader.ReadByte
            Reader.Position = Bottle3
            valu_bottle3.Value = Reader.ReadByte
            Reader.Position = Bottle4
            valu_bottle4.Value = Reader.ReadByte
            Reader.Position = Bottle5
            valu_bottle5.Value = Reader.ReadByte
            Reader.Position = Bottle1item
            valu_bottleitem_1.Value = Reader.ReadByte
            Reader.Position = Bottle2item
            valu_bottleitem_2.Value = Reader.ReadByte
            Reader.Position = Bottle3item
            valu_bottleitem_3.Value = Reader.ReadByte
            Reader.Position = Bottle4item
            valu_bottleitem_4.Value = Reader.ReadByte
            Reader.Position = Bottle5item
            valu_bottleitem_5.Value = Reader.ReadByte
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs)
        Crc32_z1()
    End Sub

    Private Crctable = {&H0, &H77073096, &HEE0E612C, &H990951BA, &H76DC419, &H706AF48F,
    &HE963A535, &H9E6495A3, &HEDB8832, &H79DCB8A4, &HE0D5E91E, &H97D2D988,
    &H9B64C2B, &H7EB17CBD, &HE7B82D07, &H90BF1D91, &H1DB71064, &H6AB020F2,
    &HF3B97148, &H84BE41DE, &H1ADAD47D, &H6DDDE4EB, &HF4D4B551, &H83D385C7,
    &H136C9856, &H646BA8C0, &HFD62F97A, &H8A65C9EC, &H14015C4F, &H63066CD9,
    &HFA0F3D63, &H8D080DF5, &H3B6E20C8, &H4C69105E, &HD56041E4, &HA2677172,
    &H3C03E4D1, &H4B04D447, &HD20D85FD, &HA50AB56B, &H35B5A8FA, &H42B2986C,
    &HDBBBC9D6, &HACBCF940, &H32D86CE3, &H45DF5C75, &HDCD60DCF, &HABD13D59,
    &H26D930AC, &H51DE003A, &HC8D75180, &HBFD06116, &H21B4F4B5, &H56B3C423,
    &HCFBA9599, &HB8BDA50F, &H2802B89E, &H5F058808, &HC60CD9B2, &HB10BE924,
    &H2F6F7C87, &H58684C11, &HC1611DAB, &HB6662D3D, &H76DC4190, &H1DB7106,
    &H98D220BC, &HEFD5102A, &H71B18589, &H6B6B51F, &H9FBFE4A5, &HE8B8D433,
    &H7807C9A2, &HF00F934, &H9609A88E, &HE10E9818, &H7F6A0DBB, &H86D3D2D,
    &H91646C97, &HE6635C01, &H6B6B51F4, &H1C6C6162, &H856530D8, &HF262004E,
    &H6C0695ED, &H1B01A57B, &H8208F4C1, &HF50FC457, &H65B0D9C6, &H12B7E950,
    &H8BBEB8EA, &HFCB9887C, &H62DD1DDF, &H15DA2D49, &H8CD37CF3, &HFBD44C65,
    &H4DB26158, &H3AB551CE, &HA3BC0074, &HD4BB30E2, &H4ADFA541, &H3DD895D7,
    &HA4D1C46D, &HD3D6F4FB, &H4369E96A, &H346ED9FC, &HAD678846, &HDA60B8D0,
    &H44042D73, &H33031DE5, &HAA0A4C5F, &HDD0D7CC9, &H5005713C, &H270241AA,
    &HBE0B1010, &HC90C2086, &H5768B525, &H206F85B3, &HB966D409, &HCE61E49F,
    &H5EDEF90E, &H29D9C998, &HB0D09822, &HC7D7A8B4, &H59B33D17, &H2EB40D81,
    &HB7BD5C3B, &HC0BA6CAD, &HEDB88320, &H9ABFB3B6, &H3B6E20C, &H74B1D29A,
    &HEAD54739, &H9DD277AF, &H4DB2615, &H73DC1683, &HE3630B12, &H94643B84,
    &HD6D6A3E, &H7A6A5AA8, &HE40ECF0B, &H9309FF9D, &HA00AE27, &H7D079EB1,
    &HF00F9344, &H8708A3D2, &H1E01F268, &H6906C2FE, &HF762575D, &H806567CB,
    &H196C3671, &H6E6B06E7, &HFED41B76, &H89D32BE0, &H10DA7A5A, &H67DD4ACC,
    &HF9B9DF6F, &H8EBEEFF9, &H17B7BE43, &H60B08ED5, &HD6D6A3E8, &HA1D1937E,
    &H38D8C2C4, &H4FDFF252, &HD1BB67F1, &HA6BC5767, &H3FB506DD, &H48B2364B,
    &HD80D2BDA, &HAF0A1B4C, &H36034AF6, &H41047A60, &HDF60EFC3, &HA867DF55,
    &H316E8EEF, &H4669BE79, &HCB61B38C, &HBC66831A, &H256FD2A0, &H5268E236,
    &HCC0C7795, &HBB0B4703, &H220216B9, &H5505262F, &HC5BA3BBE, &HB2BD0B28,
    &H2BB45A92, &H5CB36A04, &HC2D7FFA7, &HB5D0CF31, &H2CD99E8B, &H5BDEAE1D,
    &H9B64C2B0, &HEC63F226, &H756AA39C, &H26D930A, &H9C0906A9, &HEB0E363F,
    &H72076785, &H5005713, &H95BF4A82, &HE2B87A14, &H7BB12BAE, &HCB61B38,
    &H92D28E9B, &HE5D5BE0D, &H7CDCEFB7, &HBDBDF21, &H86D3D2D4, &HF1D4E242,
    &H68DDB3F8, &H1FDA836E, &H81BE16CD, &HF6B9265B, &H6FB077E1, &H18B74777,
    &H88085AE6, &HFF0F6A70, &H66063BCA, &H11010B5C, &H8F659EFF, &HF862AE69,
    &H616BFFD3, &H166CCF45, &HA00AE278, &HD70DD2EE, &H4E048354, &H3903B3C2,
    &HA7672661, &HD06016F7, &H4969474D, &H3E6E77DB, &HAED16A4A, &HD9D65ADC,
    &H40DF0B66, &H37D83BF0, &HA9BCAE53, &HDEBB9EC5, &H47B2CF7F, &H30B5FFE9,
    &HBDBDF21C, &HCABAC28A, &H53B39330, &H24B4A3A6, &HBAD03605, &HCDD70693,
    &H54DE5729, &H23D967BF, &HB3667A2E, &HC4614AB8, &H5D681B02, &H2A6F2B94,
    &HB40BBE37, &HC30C8EA1, &H5A05DF1B, &H2D02EF8D}

    Public Sub Crc32_z1()
        Dim crc As Integer = &HFFFFFFFF
        Dim x As Integer = 0
        Dim c As Byte = 0
        Dim str As String = Text_datacrc32_z1.Text
        Dim ctr = PackageIO.Conversions.HexToByteArray(str)
        While x <= ctr.Length - 1
            c = ctr(x)
            crc = (((crc And &HFFFFFF00) >> 8) And &HFFFFFF) Xor (Crctable((crc And 255) Xor c))
            x += 1
        End While
        crc = (Not crc)
        Text_crc32_z1.Text = Hex(crc).PadLeft(8, "0")
        Text_crc32_z1reflet.Text = Text_crc32_z1.Text.Substring(6, 2) & Text_crc32_z1.Text.Substring(4, 2) & Text_crc32_z1.Text.Substring(2, 2) & Text_crc32_z1.Text.Substring(0, 2)
    End Sub

    Private Sub Text_menu_save_Click(sender As Object, e As EventArgs) Handles Text_menu_save.Click
        Writezelda()
        writezelda1()
        readzeldasave()
        Crc32_z1()
        'writezelda2()
        WriteCRC()
        Text_menu_save.Visible = False
    End Sub

    Public Sub Writezelda()
        Try
            Dim Writerx As New PackageIO.Writer(Zeldasave, PackageIO.Endian.Little)
            Writerx.Position = Rupee
            Writerx.WriteUInt16(valu_ruppe.Value)
            For i = 0 To 9
                Writerx.Position = Savename + i
                Writerx.WriteInt8(0)
            Next
            Writerx.Position = Savename
            Writerx.WriteUnicodeString(Text_savename.Text)
            Writerx.Flush()
            Writerx.Close()
        Catch ex As Exception
        End Try
    End Sub

    Public Sub writezelda1()
        Try
            Dim fs As New FileStream(Zeldasave, FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite)
            fs.Position = Lostmaiamai
            fs.WriteByte(valu_lostmaiamai.Value)
            fs.Position = Monstertail
            fs.WriteByte(valu_monstertail.Value)
            fs.Position = Monsterhorn
            fs.WriteByte(valu_monsterhorn.Value)
            fs.Position = Monstergust
            fs.WriteByte(valu_monstergust.Value)
            fs.Position = Actuahearts
            fs.WriteByte(valu_currenthearts.Value)
            fs.Position = Maxhearts
            fs.WriteByte(valu_maxhearts.Value)
            fs.Position = Bombs
            fs.WriteByte(valu_bombs.Value)
            fs.Position = Boomerang
            fs.WriteByte(valu_boomerang.Value)
            fs.Position = Bow
            fs.WriteByte(valu_bow.Value)
            fs.Position = Bowoflight
            fs.WriteByte(valu_bowoflight.Value)
            fs.Position = Hammer
            fs.WriteByte(valu_hammer.Value)
            fs.Position = Sandrod
            fs.WriteByte(valu_sandrod.Value)
            fs.Position = Firerod
            fs.WriteByte(valu_firerod.Value)
            fs.Position = Icerod
            fs.WriteByte(valu_icerod.Value)
            fs.Position = Tornadorod
            fs.WriteByte(valu_tornadorod.Value)
            fs.Position = Hookshot
            fs.WriteByte(valu_hookshot.Value)
            fs.Position = Lamp
            fs.WriteByte(valu_lamp.Value)
            fs.Position = Net
            fs.WriteByte(valu_net.Value)
            fs.Position = Hintglasses
            fs.WriteByte(valu_hintglasses.Value)
            fs.Position = Scootfruit
            fs.WriteByte(valu_scootfruit.Value)
            fs.Position = Foulfruit
            fs.WriteByte(valu_foulfruit.Value)
            fs.Position = Bottle1
            fs.WriteByte(valu_bottle1.Value)
            fs.Position = Bottle2
            fs.WriteByte(valu_bottle2.Value)
            fs.Position = Bottle3
            fs.WriteByte(valu_bottle3.Value)
            fs.Position = Bottle4
            fs.WriteByte(valu_bottle4.Value)
            fs.Position = Bottle5
            fs.WriteByte(valu_bottle5.Value)
            fs.Position = Bottle1item
            fs.WriteByte(valu_bottleitem_1.Value)
            fs.Position = Bottle2item
            fs.WriteByte(valu_bottleitem_2.Value)
            fs.Position = Bottle3item
            fs.WriteByte(valu_bottleitem_3.Value)
            fs.Position = Bottle4item
            fs.WriteByte(valu_bottleitem_4.Value)
            fs.Position = Bottle5item
            fs.WriteByte(valu_bottleitem_5.Value)
        Catch ex As Exception
        End Try
    End Sub

    Public Sub writezelda2()
        Try
            Dim xs As New FileStream(Zeldasave, FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite)
            xs.Position = &HDFC
            For j As Integer = 0 To Text_crc32_z1reflet.Text.Length - 1 Step 2
                xs.WriteByte(CByte(Conversion.Val("&H" & Text_crc32_z1reflet.Text.Substring(j, 2))))
            Next
        Catch ex As Exception

        End Try
    End Sub

    Public Sub WriteCRC()
        Try
            Dim writer As New PackageIO.Writer(Zeldasave, PackageIO.Endian.Little)
            writer.Position = &HDFC
            writer.WriteHexString(Text_crc32_z1reflet.Text)
            MsgBox("crc write")
        Catch ex As Exception

        End Try
    End Sub

    Public Sub Maxheart()
        If valu_maxhearts.Value = 12 Then
            Icon_maxheart_3.Image = My.Resources.icon_heart_4x4
            Icon_maxheart_4.Image = My.Resources.icon_heart_0x4
            Icon_maxheart_5.Image = My.Resources.icon_heart_0x4
            Icon_maxheart_6.Image = My.Resources.icon_heart_0x4
            Icon_maxheart_7.Image = My.Resources.icon_heart_0x4
            Icon_maxheart_8.Image = My.Resources.icon_heart_0x4
            Icon_maxheart_9.Image = My.Resources.icon_heart_0x4
            Icon_maxheart_10.Image = My.Resources.icon_heart_0x4
            Icon_maxheart_11.Image = My.Resources.icon_heart_0x4
            Icon_maxheart_12.Image = My.Resources.icon_heart_0x4
            Icon_maxheart_13.Image = My.Resources.icon_heart_0x4
            Icon_maxheart_14.Image = My.Resources.icon_heart_0x4
            Icon_maxheart_15.Image = My.Resources.icon_heart_0x4
            Icon_maxheart_16.Image = My.Resources.icon_heart_0x4
            Icon_maxheart_17.Image = My.Resources.icon_heart_0x4
            Icon_maxheart_18.Image = My.Resources.icon_heart_0x4
            Icon_maxheart_19.Image = My.Resources.icon_heart_0x4
            Icon_maxheart_20.Image = My.Resources.icon_heart_0x4
        ElseIf valu_maxhearts.Value = 16 Then
            Icon_maxheart_3.Image = My.Resources.icon_heart_4x4
            Icon_maxheart_4.Image = My.Resources.icon_heart_4x4
            Icon_maxheart_5.Image = My.Resources.icon_heart_0x4
            Icon_maxheart_6.Image = My.Resources.icon_heart_0x4
            Icon_maxheart_7.Image = My.Resources.icon_heart_0x4
            Icon_maxheart_8.Image = My.Resources.icon_heart_0x4
            Icon_maxheart_9.Image = My.Resources.icon_heart_0x4
            Icon_maxheart_10.Image = My.Resources.icon_heart_0x4
            Icon_maxheart_11.Image = My.Resources.icon_heart_0x4
            Icon_maxheart_12.Image = My.Resources.icon_heart_0x4
            Icon_maxheart_13.Image = My.Resources.icon_heart_0x4
            Icon_maxheart_14.Image = My.Resources.icon_heart_0x4
            Icon_maxheart_15.Image = My.Resources.icon_heart_0x4
            Icon_maxheart_16.Image = My.Resources.icon_heart_0x4
            Icon_maxheart_17.Image = My.Resources.icon_heart_0x4
            Icon_maxheart_18.Image = My.Resources.icon_heart_0x4
            Icon_maxheart_19.Image = My.Resources.icon_heart_0x4
            Icon_maxheart_20.Image = My.Resources.icon_heart_0x4
        ElseIf valu_maxhearts.Value = 20 Then
            Icon_maxheart_3.Image = My.Resources.icon_heart_4x4
            Icon_maxheart_4.Image = My.Resources.icon_heart_4x4
            Icon_maxheart_5.Image = My.Resources.icon_heart_4x4
            Icon_maxheart_6.Image = My.Resources.icon_heart_0x4
            Icon_maxheart_7.Image = My.Resources.icon_heart_0x4
            Icon_maxheart_8.Image = My.Resources.icon_heart_0x4
            Icon_maxheart_9.Image = My.Resources.icon_heart_0x4
            Icon_maxheart_10.Image = My.Resources.icon_heart_0x4
            Icon_maxheart_11.Image = My.Resources.icon_heart_0x4
            Icon_maxheart_12.Image = My.Resources.icon_heart_0x4
            Icon_maxheart_13.Image = My.Resources.icon_heart_0x4
            Icon_maxheart_14.Image = My.Resources.icon_heart_0x4
            Icon_maxheart_15.Image = My.Resources.icon_heart_0x4
            Icon_maxheart_16.Image = My.Resources.icon_heart_0x4
            Icon_maxheart_17.Image = My.Resources.icon_heart_0x4
            Icon_maxheart_18.Image = My.Resources.icon_heart_0x4
            Icon_maxheart_19.Image = My.Resources.icon_heart_0x4
            Icon_maxheart_20.Image = My.Resources.icon_heart_0x4
        ElseIf valu_maxhearts.Value = 24 Then
            Icon_maxheart_3.Image = My.Resources.icon_heart_4x4
            Icon_maxheart_4.Image = My.Resources.icon_heart_4x4
            Icon_maxheart_5.Image = My.Resources.icon_heart_4x4
            Icon_maxheart_6.Image = My.Resources.icon_heart_4x4
            Icon_maxheart_7.Image = My.Resources.icon_heart_0x4
            Icon_maxheart_8.Image = My.Resources.icon_heart_0x4
            Icon_maxheart_9.Image = My.Resources.icon_heart_0x4
            Icon_maxheart_10.Image = My.Resources.icon_heart_0x4
            Icon_maxheart_11.Image = My.Resources.icon_heart_0x4
            Icon_maxheart_12.Image = My.Resources.icon_heart_0x4
            Icon_maxheart_13.Image = My.Resources.icon_heart_0x4
            Icon_maxheart_14.Image = My.Resources.icon_heart_0x4
            Icon_maxheart_15.Image = My.Resources.icon_heart_0x4
            Icon_maxheart_16.Image = My.Resources.icon_heart_0x4
            Icon_maxheart_17.Image = My.Resources.icon_heart_0x4
            Icon_maxheart_18.Image = My.Resources.icon_heart_0x4
            Icon_maxheart_19.Image = My.Resources.icon_heart_0x4
            Icon_maxheart_20.Image = My.Resources.icon_heart_0x4
        ElseIf valu_maxhearts.Value = 28 Then
            Icon_maxheart_3.Image = My.Resources.icon_heart_4x4
            Icon_maxheart_4.Image = My.Resources.icon_heart_4x4
            Icon_maxheart_5.Image = My.Resources.icon_heart_4x4
            Icon_maxheart_6.Image = My.Resources.icon_heart_4x4
            Icon_maxheart_7.Image = My.Resources.icon_heart_4x4
            Icon_maxheart_8.Image = My.Resources.icon_heart_0x4
            Icon_maxheart_9.Image = My.Resources.icon_heart_0x4
            Icon_maxheart_10.Image = My.Resources.icon_heart_0x4
            Icon_maxheart_11.Image = My.Resources.icon_heart_0x4
            Icon_maxheart_12.Image = My.Resources.icon_heart_0x4
            Icon_maxheart_13.Image = My.Resources.icon_heart_0x4
            Icon_maxheart_14.Image = My.Resources.icon_heart_0x4
            Icon_maxheart_15.Image = My.Resources.icon_heart_0x4
            Icon_maxheart_16.Image = My.Resources.icon_heart_0x4
            Icon_maxheart_17.Image = My.Resources.icon_heart_0x4
            Icon_maxheart_18.Image = My.Resources.icon_heart_0x4
            Icon_maxheart_19.Image = My.Resources.icon_heart_0x4
            Icon_maxheart_20.Image = My.Resources.icon_heart_0x4
        ElseIf valu_maxhearts.Value = 32 Then
            Icon_maxheart_3.Image = My.Resources.icon_heart_4x4
            Icon_maxheart_4.Image = My.Resources.icon_heart_4x4
            Icon_maxheart_5.Image = My.Resources.icon_heart_4x4
            Icon_maxheart_6.Image = My.Resources.icon_heart_4x4
            Icon_maxheart_7.Image = My.Resources.icon_heart_4x4
            Icon_maxheart_8.Image = My.Resources.icon_heart_4x4
            Icon_maxheart_9.Image = My.Resources.icon_heart_0x4
            Icon_maxheart_10.Image = My.Resources.icon_heart_0x4
            Icon_maxheart_11.Image = My.Resources.icon_heart_0x4
            Icon_maxheart_12.Image = My.Resources.icon_heart_0x4
            Icon_maxheart_13.Image = My.Resources.icon_heart_0x4
            Icon_maxheart_14.Image = My.Resources.icon_heart_0x4
            Icon_maxheart_15.Image = My.Resources.icon_heart_0x4
            Icon_maxheart_16.Image = My.Resources.icon_heart_0x4
            Icon_maxheart_17.Image = My.Resources.icon_heart_0x4
            Icon_maxheart_18.Image = My.Resources.icon_heart_0x4
            Icon_maxheart_19.Image = My.Resources.icon_heart_0x4
            Icon_maxheart_20.Image = My.Resources.icon_heart_0x4
        ElseIf valu_maxhearts.Value = 36 Then
            Icon_maxheart_3.Image = My.Resources.icon_heart_4x4
            Icon_maxheart_4.Image = My.Resources.icon_heart_4x4
            Icon_maxheart_5.Image = My.Resources.icon_heart_4x4
            Icon_maxheart_6.Image = My.Resources.icon_heart_4x4
            Icon_maxheart_7.Image = My.Resources.icon_heart_4x4
            Icon_maxheart_8.Image = My.Resources.icon_heart_4x4
            Icon_maxheart_9.Image = My.Resources.icon_heart_4x4
            Icon_maxheart_10.Image = My.Resources.icon_heart_0x4
            Icon_maxheart_11.Image = My.Resources.icon_heart_0x4
            Icon_maxheart_12.Image = My.Resources.icon_heart_0x4
            Icon_maxheart_13.Image = My.Resources.icon_heart_0x4
            Icon_maxheart_14.Image = My.Resources.icon_heart_0x4
            Icon_maxheart_15.Image = My.Resources.icon_heart_0x4
            Icon_maxheart_16.Image = My.Resources.icon_heart_0x4
            Icon_maxheart_17.Image = My.Resources.icon_heart_0x4
            Icon_maxheart_18.Image = My.Resources.icon_heart_0x4
            Icon_maxheart_19.Image = My.Resources.icon_heart_0x4
            Icon_maxheart_20.Image = My.Resources.icon_heart_0x4
        ElseIf valu_maxhearts.Value = 40 Then
            Icon_maxheart_3.Image = My.Resources.icon_heart_4x4
            Icon_maxheart_4.Image = My.Resources.icon_heart_4x4
            Icon_maxheart_5.Image = My.Resources.icon_heart_4x4
            Icon_maxheart_6.Image = My.Resources.icon_heart_4x4
            Icon_maxheart_7.Image = My.Resources.icon_heart_4x4
            Icon_maxheart_8.Image = My.Resources.icon_heart_4x4
            Icon_maxheart_9.Image = My.Resources.icon_heart_4x4
            Icon_maxheart_10.Image = My.Resources.icon_heart_4x4
            Icon_maxheart_11.Image = My.Resources.icon_heart_0x4
            Icon_maxheart_12.Image = My.Resources.icon_heart_0x4
            Icon_maxheart_13.Image = My.Resources.icon_heart_0x4
            Icon_maxheart_14.Image = My.Resources.icon_heart_0x4
            Icon_maxheart_15.Image = My.Resources.icon_heart_0x4
            Icon_maxheart_16.Image = My.Resources.icon_heart_0x4
            Icon_maxheart_17.Image = My.Resources.icon_heart_0x4
            Icon_maxheart_18.Image = My.Resources.icon_heart_0x4
            Icon_maxheart_19.Image = My.Resources.icon_heart_0x4
            Icon_maxheart_20.Image = My.Resources.icon_heart_0x4
        ElseIf valu_maxhearts.Value = 44 Then
            Icon_maxheart_3.Image = My.Resources.icon_heart_4x4
            Icon_maxheart_4.Image = My.Resources.icon_heart_4x4
            Icon_maxheart_5.Image = My.Resources.icon_heart_4x4
            Icon_maxheart_6.Image = My.Resources.icon_heart_4x4
            Icon_maxheart_7.Image = My.Resources.icon_heart_4x4
            Icon_maxheart_8.Image = My.Resources.icon_heart_4x4
            Icon_maxheart_9.Image = My.Resources.icon_heart_4x4
            Icon_maxheart_10.Image = My.Resources.icon_heart_4x4
            Icon_maxheart_11.Image = My.Resources.icon_heart_4x4
            Icon_maxheart_12.Image = My.Resources.icon_heart_0x4
            Icon_maxheart_13.Image = My.Resources.icon_heart_0x4
            Icon_maxheart_14.Image = My.Resources.icon_heart_0x4
            Icon_maxheart_15.Image = My.Resources.icon_heart_0x4
            Icon_maxheart_16.Image = My.Resources.icon_heart_0x4
            Icon_maxheart_17.Image = My.Resources.icon_heart_0x4
            Icon_maxheart_18.Image = My.Resources.icon_heart_0x4
            Icon_maxheart_19.Image = My.Resources.icon_heart_0x4
            Icon_maxheart_20.Image = My.Resources.icon_heart_0x4
        ElseIf valu_maxhearts.Value = 48 Then
            Icon_maxheart_3.Image = My.Resources.icon_heart_4x4
            Icon_maxheart_4.Image = My.Resources.icon_heart_4x4
            Icon_maxheart_5.Image = My.Resources.icon_heart_4x4
            Icon_maxheart_6.Image = My.Resources.icon_heart_4x4
            Icon_maxheart_7.Image = My.Resources.icon_heart_4x4
            Icon_maxheart_8.Image = My.Resources.icon_heart_4x4
            Icon_maxheart_9.Image = My.Resources.icon_heart_4x4
            Icon_maxheart_10.Image = My.Resources.icon_heart_4x4
            Icon_maxheart_11.Image = My.Resources.icon_heart_4x4
            Icon_maxheart_12.Image = My.Resources.icon_heart_4x4
            Icon_maxheart_13.Image = My.Resources.icon_heart_0x4
            Icon_maxheart_14.Image = My.Resources.icon_heart_0x4
            Icon_maxheart_15.Image = My.Resources.icon_heart_0x4
            Icon_maxheart_16.Image = My.Resources.icon_heart_0x4
            Icon_maxheart_17.Image = My.Resources.icon_heart_0x4
            Icon_maxheart_18.Image = My.Resources.icon_heart_0x4
            Icon_maxheart_19.Image = My.Resources.icon_heart_0x4
            Icon_maxheart_20.Image = My.Resources.icon_heart_0x4
        ElseIf valu_maxhearts.Value = 52 Then
            Icon_maxheart_3.Image = My.Resources.icon_heart_4x4
            Icon_maxheart_4.Image = My.Resources.icon_heart_4x4
            Icon_maxheart_5.Image = My.Resources.icon_heart_4x4
            Icon_maxheart_6.Image = My.Resources.icon_heart_4x4
            Icon_maxheart_7.Image = My.Resources.icon_heart_4x4
            Icon_maxheart_8.Image = My.Resources.icon_heart_4x4
            Icon_maxheart_9.Image = My.Resources.icon_heart_4x4
            Icon_maxheart_10.Image = My.Resources.icon_heart_4x4
            Icon_maxheart_11.Image = My.Resources.icon_heart_4x4
            Icon_maxheart_12.Image = My.Resources.icon_heart_4x4
            Icon_maxheart_13.Image = My.Resources.icon_heart_4x4
            Icon_maxheart_14.Image = My.Resources.icon_heart_0x4
            Icon_maxheart_15.Image = My.Resources.icon_heart_0x4
            Icon_maxheart_16.Image = My.Resources.icon_heart_0x4
            Icon_maxheart_17.Image = My.Resources.icon_heart_0x4
            Icon_maxheart_18.Image = My.Resources.icon_heart_0x4
            Icon_maxheart_19.Image = My.Resources.icon_heart_0x4
            Icon_maxheart_20.Image = My.Resources.icon_heart_0x4
        ElseIf valu_maxhearts.Value = 56 Then
            Icon_maxheart_3.Image = My.Resources.icon_heart_4x4
            Icon_maxheart_4.Image = My.Resources.icon_heart_4x4
            Icon_maxheart_5.Image = My.Resources.icon_heart_4x4
            Icon_maxheart_6.Image = My.Resources.icon_heart_4x4
            Icon_maxheart_7.Image = My.Resources.icon_heart_4x4
            Icon_maxheart_8.Image = My.Resources.icon_heart_4x4
            Icon_maxheart_9.Image = My.Resources.icon_heart_4x4
            Icon_maxheart_10.Image = My.Resources.icon_heart_4x4
            Icon_maxheart_11.Image = My.Resources.icon_heart_4x4
            Icon_maxheart_12.Image = My.Resources.icon_heart_4x4
            Icon_maxheart_13.Image = My.Resources.icon_heart_4x4
            Icon_maxheart_14.Image = My.Resources.icon_heart_4x4
            Icon_maxheart_15.Image = My.Resources.icon_heart_0x4
            Icon_maxheart_16.Image = My.Resources.icon_heart_0x4
            Icon_maxheart_17.Image = My.Resources.icon_heart_0x4
            Icon_maxheart_18.Image = My.Resources.icon_heart_0x4
            Icon_maxheart_19.Image = My.Resources.icon_heart_0x4
            Icon_maxheart_20.Image = My.Resources.icon_heart_0x4
        ElseIf valu_maxhearts.Value = 60 Then
            Icon_maxheart_3.Image = My.Resources.icon_heart_4x4
            Icon_maxheart_4.Image = My.Resources.icon_heart_4x4
            Icon_maxheart_5.Image = My.Resources.icon_heart_4x4
            Icon_maxheart_6.Image = My.Resources.icon_heart_4x4
            Icon_maxheart_7.Image = My.Resources.icon_heart_4x4
            Icon_maxheart_8.Image = My.Resources.icon_heart_4x4
            Icon_maxheart_9.Image = My.Resources.icon_heart_4x4
            Icon_maxheart_10.Image = My.Resources.icon_heart_4x4
            Icon_maxheart_11.Image = My.Resources.icon_heart_4x4
            Icon_maxheart_12.Image = My.Resources.icon_heart_4x4
            Icon_maxheart_13.Image = My.Resources.icon_heart_4x4
            Icon_maxheart_14.Image = My.Resources.icon_heart_4x4
            Icon_maxheart_15.Image = My.Resources.icon_heart_4x4
            Icon_maxheart_16.Image = My.Resources.icon_heart_0x4
            Icon_maxheart_17.Image = My.Resources.icon_heart_0x4
            Icon_maxheart_18.Image = My.Resources.icon_heart_0x4
            Icon_maxheart_19.Image = My.Resources.icon_heart_0x4
            Icon_maxheart_20.Image = My.Resources.icon_heart_0x4
        ElseIf valu_maxhearts.Value = 64 Then
            Icon_maxheart_3.Image = My.Resources.icon_heart_4x4
            Icon_maxheart_4.Image = My.Resources.icon_heart_4x4
            Icon_maxheart_5.Image = My.Resources.icon_heart_4x4
            Icon_maxheart_6.Image = My.Resources.icon_heart_4x4
            Icon_maxheart_7.Image = My.Resources.icon_heart_4x4
            Icon_maxheart_8.Image = My.Resources.icon_heart_4x4
            Icon_maxheart_9.Image = My.Resources.icon_heart_4x4
            Icon_maxheart_10.Image = My.Resources.icon_heart_4x4
            Icon_maxheart_11.Image = My.Resources.icon_heart_4x4
            Icon_maxheart_12.Image = My.Resources.icon_heart_4x4
            Icon_maxheart_13.Image = My.Resources.icon_heart_4x4
            Icon_maxheart_14.Image = My.Resources.icon_heart_4x4
            Icon_maxheart_15.Image = My.Resources.icon_heart_4x4
            Icon_maxheart_16.Image = My.Resources.icon_heart_4x4
            Icon_maxheart_17.Image = My.Resources.icon_heart_0x4
            Icon_maxheart_18.Image = My.Resources.icon_heart_0x4
            Icon_maxheart_19.Image = My.Resources.icon_heart_0x4
            Icon_maxheart_20.Image = My.Resources.icon_heart_0x4
        ElseIf valu_maxhearts.Value = 68 Then
            Icon_maxheart_3.Image = My.Resources.icon_heart_4x4
            Icon_maxheart_4.Image = My.Resources.icon_heart_4x4
            Icon_maxheart_5.Image = My.Resources.icon_heart_4x4
            Icon_maxheart_6.Image = My.Resources.icon_heart_4x4
            Icon_maxheart_7.Image = My.Resources.icon_heart_4x4
            Icon_maxheart_8.Image = My.Resources.icon_heart_4x4
            Icon_maxheart_9.Image = My.Resources.icon_heart_4x4
            Icon_maxheart_10.Image = My.Resources.icon_heart_4x4
            Icon_maxheart_11.Image = My.Resources.icon_heart_4x4
            Icon_maxheart_12.Image = My.Resources.icon_heart_4x4
            Icon_maxheart_13.Image = My.Resources.icon_heart_4x4
            Icon_maxheart_14.Image = My.Resources.icon_heart_4x4
            Icon_maxheart_15.Image = My.Resources.icon_heart_4x4
            Icon_maxheart_16.Image = My.Resources.icon_heart_4x4
            Icon_maxheart_17.Image = My.Resources.icon_heart_4x4
            Icon_maxheart_18.Image = My.Resources.icon_heart_0x4
            Icon_maxheart_19.Image = My.Resources.icon_heart_0x4
            Icon_maxheart_20.Image = My.Resources.icon_heart_0x4
        ElseIf valu_maxhearts.Value = 72 Then
            Icon_maxheart_3.Image = My.Resources.icon_heart_4x4
            Icon_maxheart_4.Image = My.Resources.icon_heart_4x4
            Icon_maxheart_5.Image = My.Resources.icon_heart_4x4
            Icon_maxheart_6.Image = My.Resources.icon_heart_4x4
            Icon_maxheart_7.Image = My.Resources.icon_heart_4x4
            Icon_maxheart_8.Image = My.Resources.icon_heart_4x4
            Icon_maxheart_9.Image = My.Resources.icon_heart_4x4
            Icon_maxheart_10.Image = My.Resources.icon_heart_4x4
            Icon_maxheart_11.Image = My.Resources.icon_heart_4x4
            Icon_maxheart_12.Image = My.Resources.icon_heart_4x4
            Icon_maxheart_13.Image = My.Resources.icon_heart_4x4
            Icon_maxheart_14.Image = My.Resources.icon_heart_4x4
            Icon_maxheart_15.Image = My.Resources.icon_heart_4x4
            Icon_maxheart_16.Image = My.Resources.icon_heart_4x4
            Icon_maxheart_17.Image = My.Resources.icon_heart_4x4
            Icon_maxheart_18.Image = My.Resources.icon_heart_4x4
            Icon_maxheart_19.Image = My.Resources.icon_heart_0x4
            Icon_maxheart_20.Image = My.Resources.icon_heart_0x4
        ElseIf valu_maxhearts.Value = 76 Then
            Icon_maxheart_3.Image = My.Resources.icon_heart_4x4
            Icon_maxheart_4.Image = My.Resources.icon_heart_4x4
            Icon_maxheart_5.Image = My.Resources.icon_heart_4x4
            Icon_maxheart_6.Image = My.Resources.icon_heart_4x4
            Icon_maxheart_7.Image = My.Resources.icon_heart_4x4
            Icon_maxheart_8.Image = My.Resources.icon_heart_4x4
            Icon_maxheart_9.Image = My.Resources.icon_heart_4x4
            Icon_maxheart_10.Image = My.Resources.icon_heart_4x4
            Icon_maxheart_11.Image = My.Resources.icon_heart_4x4
            Icon_maxheart_12.Image = My.Resources.icon_heart_4x4
            Icon_maxheart_13.Image = My.Resources.icon_heart_4x4
            Icon_maxheart_14.Image = My.Resources.icon_heart_4x4
            Icon_maxheart_15.Image = My.Resources.icon_heart_4x4
            Icon_maxheart_16.Image = My.Resources.icon_heart_4x4
            Icon_maxheart_17.Image = My.Resources.icon_heart_4x4
            Icon_maxheart_18.Image = My.Resources.icon_heart_4x4
            Icon_maxheart_19.Image = My.Resources.icon_heart_4x4
            Icon_maxheart_20.Image = My.Resources.icon_heart_0x4
        ElseIf valu_maxhearts.Value = 80 Then
            Icon_maxheart_3.Image = My.Resources.icon_heart_4x4
            Icon_maxheart_4.Image = My.Resources.icon_heart_4x4
            Icon_maxheart_5.Image = My.Resources.icon_heart_4x4
            Icon_maxheart_6.Image = My.Resources.icon_heart_4x4
            Icon_maxheart_7.Image = My.Resources.icon_heart_4x4
            Icon_maxheart_8.Image = My.Resources.icon_heart_4x4
            Icon_maxheart_9.Image = My.Resources.icon_heart_4x4
            Icon_maxheart_10.Image = My.Resources.icon_heart_4x4
            Icon_maxheart_11.Image = My.Resources.icon_heart_4x4
            Icon_maxheart_12.Image = My.Resources.icon_heart_4x4
            Icon_maxheart_13.Image = My.Resources.icon_heart_4x4
            Icon_maxheart_14.Image = My.Resources.icon_heart_4x4
            Icon_maxheart_15.Image = My.Resources.icon_heart_4x4
            Icon_maxheart_16.Image = My.Resources.icon_heart_4x4
            Icon_maxheart_17.Image = My.Resources.icon_heart_4x4
            Icon_maxheart_18.Image = My.Resources.icon_heart_4x4
            Icon_maxheart_19.Image = My.Resources.icon_heart_4x4
            Icon_maxheart_20.Image = My.Resources.icon_heart_4x4
        Else
            Icon_maxheart_3.Image = My.Resources.icon_heart_4x4
            Icon_maxheart_4.Image = My.Resources.icon_heart_0x4
            Icon_maxheart_5.Image = My.Resources.icon_heart_0x4
            Icon_maxheart_6.Image = My.Resources.icon_heart_0x4
            Icon_maxheart_7.Image = My.Resources.icon_heart_0x4
            Icon_maxheart_8.Image = My.Resources.icon_heart_0x4
            Icon_maxheart_9.Image = My.Resources.icon_heart_0x4
            Icon_maxheart_10.Image = My.Resources.icon_heart_0x4
            Icon_maxheart_11.Image = My.Resources.icon_heart_0x4
            Icon_maxheart_12.Image = My.Resources.icon_heart_0x4
            Icon_maxheart_13.Image = My.Resources.icon_heart_0x4
            Icon_maxheart_14.Image = My.Resources.icon_heart_0x4
            Icon_maxheart_15.Image = My.Resources.icon_heart_0x4
            Icon_maxheart_16.Image = My.Resources.icon_heart_0x4
            Icon_maxheart_17.Image = My.Resources.icon_heart_0x4
            Icon_maxheart_18.Image = My.Resources.icon_heart_0x4
            Icon_maxheart_19.Image = My.Resources.icon_heart_0x4
            Icon_maxheart_20.Image = My.Resources.icon_heart_0x4
        End If
    End Sub

    Private Sub valu_maxhearts_ValueChanged(sender As Object, e As EventArgs) Handles valu_maxhearts.ValueChanged
        Maxheart()
    End Sub

    Private Sub Icon_maxheart_3_MouseMove(sender As Object, e As MouseEventArgs) Handles Icon_maxheart_3.MouseMove
        Icon_maxheart_3.Image = My.Resources.icon_heart_4x4
        Icon_maxheart_4.Image = My.Resources.icon_heart_0x4
        Icon_maxheart_5.Image = My.Resources.icon_heart_0x4
        Icon_maxheart_6.Image = My.Resources.icon_heart_0x4
        Icon_maxheart_7.Image = My.Resources.icon_heart_0x4
        Icon_maxheart_8.Image = My.Resources.icon_heart_0x4
        Icon_maxheart_9.Image = My.Resources.icon_heart_0x4
        Icon_maxheart_10.Image = My.Resources.icon_heart_0x4
        Icon_maxheart_11.Image = My.Resources.icon_heart_0x4
        Icon_maxheart_12.Image = My.Resources.icon_heart_0x4
        Icon_maxheart_13.Image = My.Resources.icon_heart_0x4
        Icon_maxheart_14.Image = My.Resources.icon_heart_0x4
        Icon_maxheart_15.Image = My.Resources.icon_heart_0x4
        Icon_maxheart_16.Image = My.Resources.icon_heart_0x4
        Icon_maxheart_17.Image = My.Resources.icon_heart_0x4
        Icon_maxheart_18.Image = My.Resources.icon_heart_0x4
        Icon_maxheart_19.Image = My.Resources.icon_heart_0x4
        Icon_maxheart_20.Image = My.Resources.icon_heart_0x4
    End Sub

    Private Sub Icon_maxheart_3_MouseLeave(sender As Object, e As EventArgs) Handles Icon_maxheart_3.MouseLeave
        Maxheart()
    End Sub

    Private Sub Icon_maxheart_3_Click(sender As Object, e As EventArgs) Handles Icon_maxheart_3.Click
        valu_maxhearts.Value = 12
    End Sub

    Private Sub Icon_maxheart_4_MouseMove(sender As Object, e As MouseEventArgs) Handles Icon_maxheart_4.MouseMove
        Icon_maxheart_3.Image = My.Resources.icon_heart_4x4
        Icon_maxheart_4.Image = My.Resources.icon_heart_4x4
        Icon_maxheart_5.Image = My.Resources.icon_heart_0x4
        Icon_maxheart_6.Image = My.Resources.icon_heart_0x4
        Icon_maxheart_7.Image = My.Resources.icon_heart_0x4
        Icon_maxheart_8.Image = My.Resources.icon_heart_0x4
        Icon_maxheart_9.Image = My.Resources.icon_heart_0x4
        Icon_maxheart_10.Image = My.Resources.icon_heart_0x4
        Icon_maxheart_11.Image = My.Resources.icon_heart_0x4
        Icon_maxheart_12.Image = My.Resources.icon_heart_0x4
        Icon_maxheart_13.Image = My.Resources.icon_heart_0x4
        Icon_maxheart_14.Image = My.Resources.icon_heart_0x4
        Icon_maxheart_15.Image = My.Resources.icon_heart_0x4
        Icon_maxheart_16.Image = My.Resources.icon_heart_0x4
        Icon_maxheart_17.Image = My.Resources.icon_heart_0x4
        Icon_maxheart_18.Image = My.Resources.icon_heart_0x4
        Icon_maxheart_19.Image = My.Resources.icon_heart_0x4
        Icon_maxheart_20.Image = My.Resources.icon_heart_0x4
    End Sub

    Private Sub Icon_maxheart_4_MouseLeave(sender As Object, e As EventArgs) Handles Icon_maxheart_4.MouseLeave
        Maxheart()
    End Sub

    Private Sub Icon_maxheart_4_Click(sender As Object, e As EventArgs) Handles Icon_maxheart_4.Click
        valu_maxhearts.Value = 16
    End Sub

    Private Sub Icon_maxheart_5_MouseMove(sender As Object, e As MouseEventArgs) Handles Icon_maxheart_5.MouseMove
        Icon_maxheart_3.Image = My.Resources.icon_heart_4x4
        Icon_maxheart_4.Image = My.Resources.icon_heart_4x4
        Icon_maxheart_5.Image = My.Resources.icon_heart_4x4
        Icon_maxheart_6.Image = My.Resources.icon_heart_0x4
        Icon_maxheart_7.Image = My.Resources.icon_heart_0x4
        Icon_maxheart_8.Image = My.Resources.icon_heart_0x4
        Icon_maxheart_9.Image = My.Resources.icon_heart_0x4
        Icon_maxheart_10.Image = My.Resources.icon_heart_0x4
        Icon_maxheart_11.Image = My.Resources.icon_heart_0x4
        Icon_maxheart_12.Image = My.Resources.icon_heart_0x4
        Icon_maxheart_13.Image = My.Resources.icon_heart_0x4
        Icon_maxheart_14.Image = My.Resources.icon_heart_0x4
        Icon_maxheart_15.Image = My.Resources.icon_heart_0x4
        Icon_maxheart_16.Image = My.Resources.icon_heart_0x4
        Icon_maxheart_17.Image = My.Resources.icon_heart_0x4
        Icon_maxheart_18.Image = My.Resources.icon_heart_0x4
        Icon_maxheart_19.Image = My.Resources.icon_heart_0x4
        Icon_maxheart_20.Image = My.Resources.icon_heart_0x4
    End Sub

    Private Sub Icon_maxheart_5_MouseLeave(sender As Object, e As EventArgs) Handles Icon_maxheart_5.MouseLeave
        Maxheart()
    End Sub

    Private Sub Icon_maxheart_5_Click(sender As Object, e As EventArgs) Handles Icon_maxheart_5.Click
        valu_maxhearts.Value = 20
    End Sub

    Private Sub Icon_maxheart_6_MouseMove(sender As Object, e As MouseEventArgs) Handles Icon_maxheart_6.MouseMove
        Icon_maxheart_3.Image = My.Resources.icon_heart_4x4
        Icon_maxheart_4.Image = My.Resources.icon_heart_4x4
        Icon_maxheart_5.Image = My.Resources.icon_heart_4x4
        Icon_maxheart_6.Image = My.Resources.icon_heart_4x4
        Icon_maxheart_7.Image = My.Resources.icon_heart_0x4
        Icon_maxheart_8.Image = My.Resources.icon_heart_0x4
        Icon_maxheart_9.Image = My.Resources.icon_heart_0x4
        Icon_maxheart_10.Image = My.Resources.icon_heart_0x4
        Icon_maxheart_11.Image = My.Resources.icon_heart_0x4
        Icon_maxheart_12.Image = My.Resources.icon_heart_0x4
        Icon_maxheart_13.Image = My.Resources.icon_heart_0x4
        Icon_maxheart_14.Image = My.Resources.icon_heart_0x4
        Icon_maxheart_15.Image = My.Resources.icon_heart_0x4
        Icon_maxheart_16.Image = My.Resources.icon_heart_0x4
        Icon_maxheart_17.Image = My.Resources.icon_heart_0x4
        Icon_maxheart_18.Image = My.Resources.icon_heart_0x4
        Icon_maxheart_19.Image = My.Resources.icon_heart_0x4
        Icon_maxheart_20.Image = My.Resources.icon_heart_0x4
    End Sub

    Private Sub Icon_maxheart_6_MouseLeave(sender As Object, e As EventArgs) Handles Icon_maxheart_6.MouseLeave
        Maxheart()
    End Sub

    Private Sub Icon_maxheart_6_Click(sender As Object, e As EventArgs) Handles Icon_maxheart_6.Click
        valu_maxhearts.Value = 24
    End Sub

    Private Sub Icon_maxheart_7_MouseMove(sender As Object, e As MouseEventArgs) Handles Icon_maxheart_7.MouseMove
        Icon_maxheart_3.Image = My.Resources.icon_heart_4x4
        Icon_maxheart_4.Image = My.Resources.icon_heart_4x4
        Icon_maxheart_5.Image = My.Resources.icon_heart_4x4
        Icon_maxheart_6.Image = My.Resources.icon_heart_4x4
        Icon_maxheart_7.Image = My.Resources.icon_heart_4x4
        Icon_maxheart_8.Image = My.Resources.icon_heart_0x4
        Icon_maxheart_9.Image = My.Resources.icon_heart_0x4
        Icon_maxheart_10.Image = My.Resources.icon_heart_0x4
        Icon_maxheart_11.Image = My.Resources.icon_heart_0x4
        Icon_maxheart_12.Image = My.Resources.icon_heart_0x4
        Icon_maxheart_13.Image = My.Resources.icon_heart_0x4
        Icon_maxheart_14.Image = My.Resources.icon_heart_0x4
        Icon_maxheart_15.Image = My.Resources.icon_heart_0x4
        Icon_maxheart_16.Image = My.Resources.icon_heart_0x4
        Icon_maxheart_17.Image = My.Resources.icon_heart_0x4
        Icon_maxheart_18.Image = My.Resources.icon_heart_0x4
        Icon_maxheart_19.Image = My.Resources.icon_heart_0x4
        Icon_maxheart_20.Image = My.Resources.icon_heart_0x4
    End Sub

    Private Sub Icon_maxheart_7_MouseLeave(sender As Object, e As EventArgs) Handles Icon_maxheart_7.MouseLeave
        Maxheart()
    End Sub

    Private Sub Icon_maxheart_7_Click(sender As Object, e As EventArgs) Handles Icon_maxheart_7.Click
        valu_maxhearts.Value = 28
    End Sub

    Private Sub Icon_maxheart_8_MouseMove(sender As Object, e As MouseEventArgs) Handles Icon_maxheart_8.MouseMove
        Icon_maxheart_3.Image = My.Resources.icon_heart_4x4
        Icon_maxheart_4.Image = My.Resources.icon_heart_4x4
        Icon_maxheart_5.Image = My.Resources.icon_heart_4x4
        Icon_maxheart_6.Image = My.Resources.icon_heart_4x4
        Icon_maxheart_7.Image = My.Resources.icon_heart_4x4
        Icon_maxheart_8.Image = My.Resources.icon_heart_4x4
        Icon_maxheart_9.Image = My.Resources.icon_heart_0x4
        Icon_maxheart_10.Image = My.Resources.icon_heart_0x4
        Icon_maxheart_11.Image = My.Resources.icon_heart_0x4
        Icon_maxheart_12.Image = My.Resources.icon_heart_0x4
        Icon_maxheart_13.Image = My.Resources.icon_heart_0x4
        Icon_maxheart_14.Image = My.Resources.icon_heart_0x4
        Icon_maxheart_15.Image = My.Resources.icon_heart_0x4
        Icon_maxheart_16.Image = My.Resources.icon_heart_0x4
        Icon_maxheart_17.Image = My.Resources.icon_heart_0x4
        Icon_maxheart_18.Image = My.Resources.icon_heart_0x4
        Icon_maxheart_19.Image = My.Resources.icon_heart_0x4
        Icon_maxheart_20.Image = My.Resources.icon_heart_0x4
    End Sub

    Private Sub Icon_maxheart_8_MouseLeave(sender As Object, e As EventArgs) Handles Icon_maxheart_8.MouseLeave
        Maxheart()
    End Sub

    Private Sub Icon_maxheart_8_Click(sender As Object, e As EventArgs) Handles Icon_maxheart_8.Click
        valu_maxhearts.Value = 32
    End Sub

    Private Sub Icon_maxheart_9_MouseMove(sender As Object, e As MouseEventArgs) Handles Icon_maxheart_9.MouseMove
        Icon_maxheart_3.Image = My.Resources.icon_heart_4x4
        Icon_maxheart_4.Image = My.Resources.icon_heart_4x4
        Icon_maxheart_5.Image = My.Resources.icon_heart_4x4
        Icon_maxheart_6.Image = My.Resources.icon_heart_4x4
        Icon_maxheart_7.Image = My.Resources.icon_heart_4x4
        Icon_maxheart_8.Image = My.Resources.icon_heart_4x4
        Icon_maxheart_9.Image = My.Resources.icon_heart_4x4
        Icon_maxheart_10.Image = My.Resources.icon_heart_0x4
        Icon_maxheart_11.Image = My.Resources.icon_heart_0x4
        Icon_maxheart_12.Image = My.Resources.icon_heart_0x4
        Icon_maxheart_13.Image = My.Resources.icon_heart_0x4
        Icon_maxheart_14.Image = My.Resources.icon_heart_0x4
        Icon_maxheart_15.Image = My.Resources.icon_heart_0x4
        Icon_maxheart_16.Image = My.Resources.icon_heart_0x4
        Icon_maxheart_17.Image = My.Resources.icon_heart_0x4
        Icon_maxheart_18.Image = My.Resources.icon_heart_0x4
        Icon_maxheart_19.Image = My.Resources.icon_heart_0x4
        Icon_maxheart_20.Image = My.Resources.icon_heart_0x4
    End Sub

    Private Sub Icon_maxheart_9_MouseLeave(sender As Object, e As EventArgs) Handles Icon_maxheart_9.MouseLeave
        Maxheart()
    End Sub

    Private Sub Icon_maxheart_9_Click(sender As Object, e As EventArgs) Handles Icon_maxheart_9.Click
        valu_maxhearts.Value = 36
    End Sub

    Private Sub Icon_maxheart_10_MouseMove(sender As Object, e As MouseEventArgs) Handles Icon_maxheart_10.MouseMove
        Icon_maxheart_3.Image = My.Resources.icon_heart_4x4
        Icon_maxheart_4.Image = My.Resources.icon_heart_4x4
        Icon_maxheart_5.Image = My.Resources.icon_heart_4x4
        Icon_maxheart_6.Image = My.Resources.icon_heart_4x4
        Icon_maxheart_7.Image = My.Resources.icon_heart_4x4
        Icon_maxheart_8.Image = My.Resources.icon_heart_4x4
        Icon_maxheart_9.Image = My.Resources.icon_heart_4x4
        Icon_maxheart_10.Image = My.Resources.icon_heart_4x4
        Icon_maxheart_11.Image = My.Resources.icon_heart_0x4
        Icon_maxheart_12.Image = My.Resources.icon_heart_0x4
        Icon_maxheart_13.Image = My.Resources.icon_heart_0x4
        Icon_maxheart_14.Image = My.Resources.icon_heart_0x4
        Icon_maxheart_15.Image = My.Resources.icon_heart_0x4
        Icon_maxheart_16.Image = My.Resources.icon_heart_0x4
        Icon_maxheart_17.Image = My.Resources.icon_heart_0x4
        Icon_maxheart_18.Image = My.Resources.icon_heart_0x4
        Icon_maxheart_19.Image = My.Resources.icon_heart_0x4
        Icon_maxheart_20.Image = My.Resources.icon_heart_0x4
    End Sub

    Private Sub Icon_maxheart_10_MouseLeave(sender As Object, e As EventArgs) Handles Icon_maxheart_10.MouseLeave
        Maxheart()
    End Sub

    Private Sub Icon_maxheart_10_Click(sender As Object, e As EventArgs) Handles Icon_maxheart_10.Click
        valu_maxhearts.Value = 40
    End Sub

    Private Sub Icon_maxheart_11_MouseMove(sender As Object, e As MouseEventArgs) Handles Icon_maxheart_11.MouseMove
        Icon_maxheart_3.Image = My.Resources.icon_heart_4x4
        Icon_maxheart_4.Image = My.Resources.icon_heart_4x4
        Icon_maxheart_5.Image = My.Resources.icon_heart_4x4
        Icon_maxheart_6.Image = My.Resources.icon_heart_4x4
        Icon_maxheart_7.Image = My.Resources.icon_heart_4x4
        Icon_maxheart_8.Image = My.Resources.icon_heart_4x4
        Icon_maxheart_9.Image = My.Resources.icon_heart_4x4
        Icon_maxheart_10.Image = My.Resources.icon_heart_4x4
        Icon_maxheart_11.Image = My.Resources.icon_heart_4x4
        Icon_maxheart_12.Image = My.Resources.icon_heart_0x4
        Icon_maxheart_13.Image = My.Resources.icon_heart_0x4
        Icon_maxheart_14.Image = My.Resources.icon_heart_0x4
        Icon_maxheart_15.Image = My.Resources.icon_heart_0x4
        Icon_maxheart_16.Image = My.Resources.icon_heart_0x4
        Icon_maxheart_17.Image = My.Resources.icon_heart_0x4
        Icon_maxheart_18.Image = My.Resources.icon_heart_0x4
        Icon_maxheart_19.Image = My.Resources.icon_heart_0x4
        Icon_maxheart_20.Image = My.Resources.icon_heart_0x4
    End Sub

    Private Sub Icon_maxheart_11_MouseLeave(sender As Object, e As EventArgs) Handles Icon_maxheart_11.MouseLeave
        Maxheart()
    End Sub

    Private Sub Icon_maxheart_11_Click(sender As Object, e As EventArgs) Handles Icon_maxheart_11.Click
        valu_maxhearts.Value = 44
    End Sub

    Private Sub Icon_maxheart_12_MouseMove(sender As Object, e As MouseEventArgs) Handles Icon_maxheart_12.MouseMove
        Icon_maxheart_3.Image = My.Resources.icon_heart_4x4
        Icon_maxheart_4.Image = My.Resources.icon_heart_4x4
        Icon_maxheart_5.Image = My.Resources.icon_heart_4x4
        Icon_maxheart_6.Image = My.Resources.icon_heart_4x4
        Icon_maxheart_7.Image = My.Resources.icon_heart_4x4
        Icon_maxheart_8.Image = My.Resources.icon_heart_4x4
        Icon_maxheart_9.Image = My.Resources.icon_heart_4x4
        Icon_maxheart_10.Image = My.Resources.icon_heart_4x4
        Icon_maxheart_11.Image = My.Resources.icon_heart_4x4
        Icon_maxheart_12.Image = My.Resources.icon_heart_4x4
        Icon_maxheart_13.Image = My.Resources.icon_heart_0x4
        Icon_maxheart_14.Image = My.Resources.icon_heart_0x4
        Icon_maxheart_15.Image = My.Resources.icon_heart_0x4
        Icon_maxheart_16.Image = My.Resources.icon_heart_0x4
        Icon_maxheart_17.Image = My.Resources.icon_heart_0x4
        Icon_maxheart_18.Image = My.Resources.icon_heart_0x4
        Icon_maxheart_19.Image = My.Resources.icon_heart_0x4
        Icon_maxheart_20.Image = My.Resources.icon_heart_0x4
    End Sub

    Private Sub Icon_maxheart_12_MouseLeave(sender As Object, e As EventArgs) Handles Icon_maxheart_12.MouseLeave
        Maxheart()
    End Sub

    Private Sub Icon_maxheart_12_Click(sender As Object, e As EventArgs) Handles Icon_maxheart_12.Click
        valu_maxhearts.Value = 48
    End Sub

    Private Sub Icon_maxheart_13_MouseMove(sender As Object, e As MouseEventArgs) Handles Icon_maxheart_13.MouseMove
        Icon_maxheart_3.Image = My.Resources.icon_heart_4x4
        Icon_maxheart_4.Image = My.Resources.icon_heart_4x4
        Icon_maxheart_5.Image = My.Resources.icon_heart_4x4
        Icon_maxheart_6.Image = My.Resources.icon_heart_4x4
        Icon_maxheart_7.Image = My.Resources.icon_heart_4x4
        Icon_maxheart_8.Image = My.Resources.icon_heart_4x4
        Icon_maxheart_9.Image = My.Resources.icon_heart_4x4
        Icon_maxheart_10.Image = My.Resources.icon_heart_4x4
        Icon_maxheart_11.Image = My.Resources.icon_heart_4x4
        Icon_maxheart_12.Image = My.Resources.icon_heart_4x4
        Icon_maxheart_13.Image = My.Resources.icon_heart_4x4
        Icon_maxheart_14.Image = My.Resources.icon_heart_0x4
        Icon_maxheart_15.Image = My.Resources.icon_heart_0x4
        Icon_maxheart_16.Image = My.Resources.icon_heart_0x4
        Icon_maxheart_17.Image = My.Resources.icon_heart_0x4
        Icon_maxheart_18.Image = My.Resources.icon_heart_0x4
        Icon_maxheart_19.Image = My.Resources.icon_heart_0x4
        Icon_maxheart_20.Image = My.Resources.icon_heart_0x4
    End Sub

    Private Sub Icon_maxheart_13_MouseLeave(sender As Object, e As EventArgs) Handles Icon_maxheart_13.MouseLeave
        Maxheart()
    End Sub

    Private Sub Icon_maxheart_13_Click(sender As Object, e As EventArgs) Handles Icon_maxheart_13.Click
        valu_maxhearts.Value = 52
    End Sub

    Private Sub Icon_maxheart_14_MouseMove(sender As Object, e As MouseEventArgs) Handles Icon_maxheart_14.MouseMove
        Icon_maxheart_3.Image = My.Resources.icon_heart_4x4
        Icon_maxheart_4.Image = My.Resources.icon_heart_4x4
        Icon_maxheart_5.Image = My.Resources.icon_heart_4x4
        Icon_maxheart_6.Image = My.Resources.icon_heart_4x4
        Icon_maxheart_7.Image = My.Resources.icon_heart_4x4
        Icon_maxheart_8.Image = My.Resources.icon_heart_4x4
        Icon_maxheart_9.Image = My.Resources.icon_heart_4x4
        Icon_maxheart_10.Image = My.Resources.icon_heart_4x4
        Icon_maxheart_11.Image = My.Resources.icon_heart_4x4
        Icon_maxheart_12.Image = My.Resources.icon_heart_4x4
        Icon_maxheart_13.Image = My.Resources.icon_heart_4x4
        Icon_maxheart_14.Image = My.Resources.icon_heart_4x4
        Icon_maxheart_15.Image = My.Resources.icon_heart_0x4
        Icon_maxheart_16.Image = My.Resources.icon_heart_0x4
        Icon_maxheart_17.Image = My.Resources.icon_heart_0x4
        Icon_maxheart_18.Image = My.Resources.icon_heart_0x4
        Icon_maxheart_19.Image = My.Resources.icon_heart_0x4
        Icon_maxheart_20.Image = My.Resources.icon_heart_0x4
    End Sub

    Private Sub Icon_maxheart_14_MouseLeave(sender As Object, e As EventArgs) Handles Icon_maxheart_14.MouseLeave
        Maxheart()
    End Sub

    Private Sub Icon_maxheart_14_Click(sender As Object, e As EventArgs) Handles Icon_maxheart_14.Click
        valu_maxhearts.Value = 56
    End Sub

    Private Sub Icon_maxheart_15_MouseMove(sender As Object, e As MouseEventArgs) Handles Icon_maxheart_15.MouseMove
        Icon_maxheart_3.Image = My.Resources.icon_heart_4x4
        Icon_maxheart_4.Image = My.Resources.icon_heart_4x4
        Icon_maxheart_5.Image = My.Resources.icon_heart_4x4
        Icon_maxheart_6.Image = My.Resources.icon_heart_4x4
        Icon_maxheart_7.Image = My.Resources.icon_heart_4x4
        Icon_maxheart_8.Image = My.Resources.icon_heart_4x4
        Icon_maxheart_9.Image = My.Resources.icon_heart_4x4
        Icon_maxheart_10.Image = My.Resources.icon_heart_4x4
        Icon_maxheart_11.Image = My.Resources.icon_heart_4x4
        Icon_maxheart_12.Image = My.Resources.icon_heart_4x4
        Icon_maxheart_13.Image = My.Resources.icon_heart_4x4
        Icon_maxheart_14.Image = My.Resources.icon_heart_4x4
        Icon_maxheart_15.Image = My.Resources.icon_heart_4x4
        Icon_maxheart_16.Image = My.Resources.icon_heart_0x4
        Icon_maxheart_17.Image = My.Resources.icon_heart_0x4
        Icon_maxheart_18.Image = My.Resources.icon_heart_0x4
        Icon_maxheart_19.Image = My.Resources.icon_heart_0x4
        Icon_maxheart_20.Image = My.Resources.icon_heart_0x4
    End Sub

    Private Sub Icon_maxheart_15_MouseLeave(sender As Object, e As EventArgs) Handles Icon_maxheart_15.MouseLeave
        Maxheart()
    End Sub

    Private Sub Icon_maxheart_15_Click(sender As Object, e As EventArgs) Handles Icon_maxheart_15.Click
        valu_maxhearts.Value = 60
    End Sub

    Private Sub Icon_maxheart_16_MouseMove(sender As Object, e As MouseEventArgs) Handles Icon_maxheart_16.MouseMove
        Icon_maxheart_3.Image = My.Resources.icon_heart_4x4
        Icon_maxheart_4.Image = My.Resources.icon_heart_4x4
        Icon_maxheart_5.Image = My.Resources.icon_heart_4x4
        Icon_maxheart_6.Image = My.Resources.icon_heart_4x4
        Icon_maxheart_7.Image = My.Resources.icon_heart_4x4
        Icon_maxheart_8.Image = My.Resources.icon_heart_4x4
        Icon_maxheart_9.Image = My.Resources.icon_heart_4x4
        Icon_maxheart_10.Image = My.Resources.icon_heart_4x4
        Icon_maxheart_11.Image = My.Resources.icon_heart_4x4
        Icon_maxheart_12.Image = My.Resources.icon_heart_4x4
        Icon_maxheart_13.Image = My.Resources.icon_heart_4x4
        Icon_maxheart_14.Image = My.Resources.icon_heart_4x4
        Icon_maxheart_15.Image = My.Resources.icon_heart_4x4
        Icon_maxheart_16.Image = My.Resources.icon_heart_4x4
        Icon_maxheart_17.Image = My.Resources.icon_heart_0x4
        Icon_maxheart_18.Image = My.Resources.icon_heart_0x4
        Icon_maxheart_19.Image = My.Resources.icon_heart_0x4
        Icon_maxheart_20.Image = My.Resources.icon_heart_0x4
    End Sub

    Private Sub Icon_maxheart_16_MouseLeave(sender As Object, e As EventArgs) Handles Icon_maxheart_16.MouseLeave
        Maxheart()
    End Sub

    Private Sub Icon_maxheart_16_Click(sender As Object, e As EventArgs) Handles Icon_maxheart_16.Click
        valu_maxhearts.Value = 64
    End Sub

    Private Sub Icon_maxheart_17_MouseMove(sender As Object, e As MouseEventArgs) Handles Icon_maxheart_17.MouseMove
        Icon_maxheart_3.Image = My.Resources.icon_heart_4x4
        Icon_maxheart_4.Image = My.Resources.icon_heart_4x4
        Icon_maxheart_5.Image = My.Resources.icon_heart_4x4
        Icon_maxheart_6.Image = My.Resources.icon_heart_4x4
        Icon_maxheart_7.Image = My.Resources.icon_heart_4x4
        Icon_maxheart_8.Image = My.Resources.icon_heart_4x4
        Icon_maxheart_9.Image = My.Resources.icon_heart_4x4
        Icon_maxheart_10.Image = My.Resources.icon_heart_4x4
        Icon_maxheart_11.Image = My.Resources.icon_heart_4x4
        Icon_maxheart_12.Image = My.Resources.icon_heart_4x4
        Icon_maxheart_13.Image = My.Resources.icon_heart_4x4
        Icon_maxheart_14.Image = My.Resources.icon_heart_4x4
        Icon_maxheart_15.Image = My.Resources.icon_heart_4x4
        Icon_maxheart_16.Image = My.Resources.icon_heart_4x4
        Icon_maxheart_17.Image = My.Resources.icon_heart_4x4
        Icon_maxheart_18.Image = My.Resources.icon_heart_0x4
        Icon_maxheart_19.Image = My.Resources.icon_heart_0x4
        Icon_maxheart_20.Image = My.Resources.icon_heart_0x4
    End Sub

    Private Sub Icon_maxheart_17_MouseLeave(sender As Object, e As EventArgs) Handles Icon_maxheart_17.MouseLeave
        Maxheart()
    End Sub

    Private Sub Icon_maxheart_17_Click(sender As Object, e As EventArgs) Handles Icon_maxheart_17.Click
        valu_maxhearts.Value = 68
    End Sub

    Private Sub Icon_maxheart_18_MouseMove(sender As Object, e As MouseEventArgs) Handles Icon_maxheart_18.MouseMove
        Icon_maxheart_3.Image = My.Resources.icon_heart_4x4
        Icon_maxheart_4.Image = My.Resources.icon_heart_4x4
        Icon_maxheart_5.Image = My.Resources.icon_heart_4x4
        Icon_maxheart_6.Image = My.Resources.icon_heart_4x4
        Icon_maxheart_7.Image = My.Resources.icon_heart_4x4
        Icon_maxheart_8.Image = My.Resources.icon_heart_4x4
        Icon_maxheart_9.Image = My.Resources.icon_heart_4x4
        Icon_maxheart_10.Image = My.Resources.icon_heart_4x4
        Icon_maxheart_11.Image = My.Resources.icon_heart_4x4
        Icon_maxheart_12.Image = My.Resources.icon_heart_4x4
        Icon_maxheart_13.Image = My.Resources.icon_heart_4x4
        Icon_maxheart_14.Image = My.Resources.icon_heart_4x4
        Icon_maxheart_15.Image = My.Resources.icon_heart_4x4
        Icon_maxheart_16.Image = My.Resources.icon_heart_4x4
        Icon_maxheart_17.Image = My.Resources.icon_heart_4x4
        Icon_maxheart_18.Image = My.Resources.icon_heart_4x4
        Icon_maxheart_19.Image = My.Resources.icon_heart_0x4
        Icon_maxheart_20.Image = My.Resources.icon_heart_0x4
    End Sub

    Private Sub Icon_maxheart_18_MouseLeave(sender As Object, e As EventArgs) Handles Icon_maxheart_18.MouseLeave
        Maxheart()
    End Sub

    Private Sub Icon_maxheart_18_Click(sender As Object, e As EventArgs) Handles Icon_maxheart_18.Click
        valu_maxhearts.Value = 72
    End Sub

    Private Sub Icon_maxheart_19_MouseMove(sender As Object, e As MouseEventArgs) Handles Icon_maxheart_19.MouseMove
        Icon_maxheart_3.Image = My.Resources.icon_heart_4x4
        Icon_maxheart_4.Image = My.Resources.icon_heart_4x4
        Icon_maxheart_5.Image = My.Resources.icon_heart_4x4
        Icon_maxheart_6.Image = My.Resources.icon_heart_4x4
        Icon_maxheart_7.Image = My.Resources.icon_heart_4x4
        Icon_maxheart_8.Image = My.Resources.icon_heart_4x4
        Icon_maxheart_9.Image = My.Resources.icon_heart_4x4
        Icon_maxheart_10.Image = My.Resources.icon_heart_4x4
        Icon_maxheart_11.Image = My.Resources.icon_heart_4x4
        Icon_maxheart_12.Image = My.Resources.icon_heart_4x4
        Icon_maxheart_13.Image = My.Resources.icon_heart_4x4
        Icon_maxheart_14.Image = My.Resources.icon_heart_4x4
        Icon_maxheart_15.Image = My.Resources.icon_heart_4x4
        Icon_maxheart_16.Image = My.Resources.icon_heart_4x4
        Icon_maxheart_17.Image = My.Resources.icon_heart_4x4
        Icon_maxheart_18.Image = My.Resources.icon_heart_4x4
        Icon_maxheart_19.Image = My.Resources.icon_heart_4x4
        Icon_maxheart_20.Image = My.Resources.icon_heart_0x4
    End Sub

    Private Sub Icon_maxheart_19_MouseLeave(sender As Object, e As EventArgs) Handles Icon_maxheart_19.MouseLeave
        Maxheart()
    End Sub

    Private Sub Icon_maxheart_19_Click(sender As Object, e As EventArgs) Handles Icon_maxheart_19.Click
        valu_maxhearts.Value = 76
    End Sub

    Private Sub Icon_maxheart_20_MouseMove(sender As Object, e As MouseEventArgs) Handles Icon_maxheart_20.MouseMove
        Icon_maxheart_3.Image = My.Resources.icon_heart_4x4
        Icon_maxheart_4.Image = My.Resources.icon_heart_4x4
        Icon_maxheart_5.Image = My.Resources.icon_heart_4x4
        Icon_maxheart_6.Image = My.Resources.icon_heart_4x4
        Icon_maxheart_7.Image = My.Resources.icon_heart_4x4
        Icon_maxheart_8.Image = My.Resources.icon_heart_4x4
        Icon_maxheart_9.Image = My.Resources.icon_heart_4x4
        Icon_maxheart_10.Image = My.Resources.icon_heart_4x4
        Icon_maxheart_11.Image = My.Resources.icon_heart_4x4
        Icon_maxheart_12.Image = My.Resources.icon_heart_4x4
        Icon_maxheart_13.Image = My.Resources.icon_heart_4x4
        Icon_maxheart_14.Image = My.Resources.icon_heart_4x4
        Icon_maxheart_15.Image = My.Resources.icon_heart_4x4
        Icon_maxheart_16.Image = My.Resources.icon_heart_4x4
        Icon_maxheart_17.Image = My.Resources.icon_heart_4x4
        Icon_maxheart_18.Image = My.Resources.icon_heart_4x4
        Icon_maxheart_19.Image = My.Resources.icon_heart_4x4
        Icon_maxheart_20.Image = My.Resources.icon_heart_4x4
    End Sub

    Private Sub Icon_maxheart_20_MouseLeave(sender As Object, e As EventArgs) Handles Icon_maxheart_20.MouseLeave
        Maxheart()
    End Sub

    Private Sub Icon_maxheart_20_Click(sender As Object, e As EventArgs) Handles Icon_maxheart_20.Click
        valu_maxhearts.Value = 80
    End Sub

    Public Sub Currentheart()
        If valu_currenthearts.Value = 1 Then
            Icon_currentheart_1.Image = My.Resources.icon_heart_1x4
            Icon_currentheart_2.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_3.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_4.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_5.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_6.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_7.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_8.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_9.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_10.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_11.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_12.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_13.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_14.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_15.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_16.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_17.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_18.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_19.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_20.Image = My.Resources.icon_heart_0x4
        ElseIf valu_currenthearts.Value = 2 Then
            Icon_currentheart_1.Image = My.Resources.icon_heart_2x4
            Icon_currentheart_2.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_3.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_4.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_5.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_6.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_7.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_8.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_9.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_10.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_11.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_12.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_13.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_14.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_15.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_16.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_17.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_18.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_19.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_20.Image = My.Resources.icon_heart_0x4
        ElseIf valu_currenthearts.Value = 3 Then
            Icon_currentheart_1.Image = My.Resources.icon_heart_3x4
            Icon_currentheart_2.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_3.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_4.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_5.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_6.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_7.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_8.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_9.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_10.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_11.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_12.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_13.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_14.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_15.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_16.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_17.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_18.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_19.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_20.Image = My.Resources.icon_heart_0x4
        ElseIf valu_currenthearts.Value = 4 Then
            Icon_currentheart_1.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_2.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_3.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_4.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_5.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_6.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_7.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_8.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_9.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_10.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_11.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_12.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_13.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_14.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_15.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_16.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_17.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_18.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_19.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_20.Image = My.Resources.icon_heart_0x4
        ElseIf valu_currenthearts.Value = 5 Then
            Icon_currentheart_1.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_2.Image = My.Resources.icon_heart_1x4
            Icon_currentheart_3.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_4.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_5.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_6.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_7.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_8.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_9.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_10.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_11.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_12.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_13.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_14.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_15.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_16.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_17.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_18.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_19.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_20.Image = My.Resources.icon_heart_0x4
        ElseIf valu_currenthearts.Value = 6 Then
            Icon_currentheart_1.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_2.Image = My.Resources.icon_heart_2x4
            Icon_currentheart_3.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_4.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_5.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_6.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_7.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_8.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_9.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_10.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_11.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_12.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_13.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_14.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_15.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_16.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_17.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_18.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_19.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_20.Image = My.Resources.icon_heart_0x4
        ElseIf valu_currenthearts.Value = 7 Then
            Icon_currentheart_1.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_2.Image = My.Resources.icon_heart_3x4
            Icon_currentheart_3.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_4.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_5.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_6.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_7.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_8.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_9.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_10.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_11.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_12.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_13.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_14.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_15.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_16.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_17.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_18.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_19.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_20.Image = My.Resources.icon_heart_0x4
        ElseIf valu_currenthearts.Value = 8 Then
            Icon_currentheart_1.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_2.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_3.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_4.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_5.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_6.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_7.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_8.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_9.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_10.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_11.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_12.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_13.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_14.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_15.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_16.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_17.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_18.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_19.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_20.Image = My.Resources.icon_heart_0x4
        ElseIf valu_currenthearts.Value = 9 Then
            Icon_currentheart_1.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_2.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_3.Image = My.Resources.icon_heart_1x4
            Icon_currentheart_4.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_5.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_6.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_7.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_8.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_9.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_10.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_11.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_12.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_13.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_14.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_15.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_16.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_17.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_18.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_19.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_20.Image = My.Resources.icon_heart_0x4
        ElseIf valu_currenthearts.Value = 10 Then
            Icon_currentheart_1.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_2.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_3.Image = My.Resources.icon_heart_2x4
            Icon_currentheart_4.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_5.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_6.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_7.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_8.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_9.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_10.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_11.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_12.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_13.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_14.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_15.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_16.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_17.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_18.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_19.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_20.Image = My.Resources.icon_heart_0x4
        ElseIf valu_currenthearts.Value = 11 Then
            Icon_currentheart_1.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_2.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_3.Image = My.Resources.icon_heart_3x4
            Icon_currentheart_4.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_5.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_6.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_7.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_8.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_9.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_10.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_11.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_12.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_13.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_14.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_15.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_16.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_17.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_18.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_19.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_20.Image = My.Resources.icon_heart_0x4
        ElseIf valu_currenthearts.Value = 12 Then
            Icon_currentheart_1.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_2.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_3.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_4.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_5.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_6.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_7.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_8.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_9.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_10.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_11.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_12.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_13.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_14.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_15.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_16.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_17.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_18.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_19.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_20.Image = My.Resources.icon_heart_0x4
        ElseIf valu_currenthearts.Value = 13 Then
            Icon_currentheart_1.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_2.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_3.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_4.Image = My.Resources.icon_heart_1x4
            Icon_currentheart_5.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_6.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_7.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_8.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_9.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_10.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_11.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_12.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_13.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_14.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_15.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_16.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_17.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_18.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_19.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_20.Image = My.Resources.icon_heart_0x4
        ElseIf valu_currenthearts.Value = 14 Then
            Icon_currentheart_1.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_2.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_3.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_4.Image = My.Resources.icon_heart_2x4
            Icon_currentheart_5.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_6.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_7.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_8.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_9.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_10.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_11.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_12.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_13.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_14.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_15.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_16.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_17.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_18.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_19.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_20.Image = My.Resources.icon_heart_0x4
        ElseIf valu_currenthearts.Value = 15 Then
            Icon_currentheart_1.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_2.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_3.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_4.Image = My.Resources.icon_heart_3x4
            Icon_currentheart_5.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_6.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_7.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_8.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_9.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_10.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_11.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_12.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_13.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_14.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_15.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_16.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_17.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_18.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_19.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_20.Image = My.Resources.icon_heart_0x4
        ElseIf valu_currenthearts.Value = 16 Then
            Icon_currentheart_1.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_2.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_3.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_4.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_5.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_6.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_7.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_8.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_9.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_10.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_11.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_12.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_13.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_14.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_15.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_16.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_17.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_18.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_19.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_20.Image = My.Resources.icon_heart_0x4
        ElseIf valu_currenthearts.Value = 17 Then
            Icon_currentheart_1.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_2.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_3.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_4.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_5.Image = My.Resources.icon_heart_1x4
            Icon_currentheart_6.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_7.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_8.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_9.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_10.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_11.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_12.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_13.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_14.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_15.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_16.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_17.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_18.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_19.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_20.Image = My.Resources.icon_heart_0x4
        ElseIf valu_currenthearts.Value = 18 Then
            Icon_currentheart_1.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_2.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_3.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_4.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_5.Image = My.Resources.icon_heart_2x4
            Icon_currentheart_6.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_7.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_8.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_9.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_10.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_11.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_12.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_13.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_14.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_15.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_16.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_17.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_18.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_19.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_20.Image = My.Resources.icon_heart_0x4
        ElseIf valu_currenthearts.Value = 19 Then
            Icon_currentheart_1.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_2.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_3.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_4.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_5.Image = My.Resources.icon_heart_3x4
            Icon_currentheart_6.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_7.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_8.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_9.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_10.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_11.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_12.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_13.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_14.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_15.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_16.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_17.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_18.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_19.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_20.Image = My.Resources.icon_heart_0x4
        ElseIf valu_currenthearts.Value = 20 Then
            Icon_currentheart_1.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_2.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_3.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_4.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_5.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_6.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_7.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_8.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_9.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_10.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_11.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_12.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_13.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_14.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_15.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_16.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_17.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_18.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_19.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_20.Image = My.Resources.icon_heart_0x4
        ElseIf valu_currenthearts.Value = 21 Then
            Icon_currentheart_1.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_2.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_3.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_4.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_5.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_6.Image = My.Resources.icon_heart_1x4
            Icon_currentheart_7.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_8.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_9.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_10.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_11.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_12.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_13.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_14.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_15.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_16.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_17.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_18.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_19.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_20.Image = My.Resources.icon_heart_0x4
        ElseIf valu_currenthearts.Value = 22 Then
            Icon_currentheart_1.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_2.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_3.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_4.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_5.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_6.Image = My.Resources.icon_heart_2x4
            Icon_currentheart_7.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_8.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_9.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_10.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_11.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_12.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_13.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_14.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_15.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_16.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_17.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_18.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_19.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_20.Image = My.Resources.icon_heart_0x4
        ElseIf valu_currenthearts.Value = 23 Then
            Icon_currentheart_1.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_2.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_3.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_4.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_5.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_6.Image = My.Resources.icon_heart_3x4
            Icon_currentheart_7.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_8.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_9.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_10.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_11.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_12.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_13.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_14.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_15.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_16.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_17.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_18.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_19.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_20.Image = My.Resources.icon_heart_0x4
        ElseIf valu_currenthearts.Value = 24 Then
            Icon_currentheart_1.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_2.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_3.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_4.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_5.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_6.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_7.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_8.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_9.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_10.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_11.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_12.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_13.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_14.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_15.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_16.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_17.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_18.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_19.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_20.Image = My.Resources.icon_heart_0x4
        ElseIf valu_currenthearts.Value = 25 Then
            Icon_currentheart_1.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_2.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_3.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_4.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_5.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_6.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_7.Image = My.Resources.icon_heart_1x4
            Icon_currentheart_8.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_9.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_10.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_11.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_12.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_13.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_14.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_15.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_16.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_17.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_18.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_19.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_20.Image = My.Resources.icon_heart_0x4
        ElseIf valu_currenthearts.Value = 26 Then
            Icon_currentheart_1.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_2.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_3.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_4.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_5.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_6.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_7.Image = My.Resources.icon_heart_2x4
            Icon_currentheart_8.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_9.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_10.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_11.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_12.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_13.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_14.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_15.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_16.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_17.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_18.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_19.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_20.Image = My.Resources.icon_heart_0x4
        ElseIf valu_currenthearts.Value = 27 Then
            Icon_currentheart_1.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_2.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_3.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_4.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_5.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_6.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_7.Image = My.Resources.icon_heart_3x4
            Icon_currentheart_8.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_9.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_10.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_11.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_12.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_13.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_14.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_15.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_16.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_17.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_18.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_19.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_20.Image = My.Resources.icon_heart_0x4
        ElseIf valu_currenthearts.Value = 28 Then
            Icon_currentheart_1.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_2.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_3.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_4.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_5.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_6.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_7.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_8.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_9.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_10.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_11.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_12.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_13.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_14.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_15.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_16.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_17.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_18.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_19.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_20.Image = My.Resources.icon_heart_0x4
        ElseIf valu_currenthearts.Value = 29 Then
            Icon_currentheart_1.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_2.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_3.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_4.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_5.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_6.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_7.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_8.Image = My.Resources.icon_heart_1x4
            Icon_currentheart_9.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_10.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_11.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_12.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_13.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_14.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_15.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_16.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_17.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_18.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_19.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_20.Image = My.Resources.icon_heart_0x4
        ElseIf valu_currenthearts.Value = 30 Then
            Icon_currentheart_1.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_2.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_3.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_4.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_5.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_6.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_7.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_8.Image = My.Resources.icon_heart_2x4
            Icon_currentheart_9.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_10.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_11.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_12.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_13.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_14.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_15.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_16.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_17.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_18.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_19.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_20.Image = My.Resources.icon_heart_0x4
        ElseIf valu_currenthearts.Value = 31 Then
            Icon_currentheart_1.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_2.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_3.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_4.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_5.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_6.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_7.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_8.Image = My.Resources.icon_heart_3x4
            Icon_currentheart_9.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_10.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_11.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_12.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_13.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_14.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_15.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_16.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_17.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_18.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_19.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_20.Image = My.Resources.icon_heart_0x4
        ElseIf valu_currenthearts.Value = 32 Then
            Icon_currentheart_1.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_2.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_3.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_4.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_5.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_6.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_7.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_8.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_9.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_10.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_11.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_12.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_13.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_14.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_15.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_16.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_17.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_18.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_19.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_20.Image = My.Resources.icon_heart_0x4
        ElseIf valu_currenthearts.Value = 33 Then
            Icon_currentheart_1.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_2.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_3.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_4.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_5.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_6.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_7.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_8.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_9.Image = My.Resources.icon_heart_1x4
            Icon_currentheart_10.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_11.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_12.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_13.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_14.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_15.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_16.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_17.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_18.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_19.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_20.Image = My.Resources.icon_heart_0x4
        ElseIf valu_currenthearts.Value = 34 Then
            Icon_currentheart_1.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_2.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_3.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_4.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_5.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_6.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_7.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_8.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_9.Image = My.Resources.icon_heart_2x4
            Icon_currentheart_10.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_11.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_12.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_13.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_14.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_15.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_16.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_17.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_18.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_19.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_20.Image = My.Resources.icon_heart_0x4
        ElseIf valu_currenthearts.Value = 35 Then
            Icon_currentheart_1.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_2.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_3.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_4.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_5.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_6.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_7.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_8.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_9.Image = My.Resources.icon_heart_3x4
            Icon_currentheart_10.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_11.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_12.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_13.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_14.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_15.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_16.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_17.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_18.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_19.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_20.Image = My.Resources.icon_heart_0x4
        ElseIf valu_currenthearts.Value = 36 Then
            Icon_currentheart_1.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_2.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_3.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_4.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_5.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_6.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_7.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_8.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_9.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_10.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_11.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_12.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_13.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_14.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_15.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_16.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_17.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_18.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_19.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_20.Image = My.Resources.icon_heart_0x4
        ElseIf valu_currenthearts.Value = 37 Then
            Icon_currentheart_1.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_2.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_3.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_4.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_5.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_6.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_7.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_8.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_9.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_10.Image = My.Resources.icon_heart_1x4
            Icon_currentheart_11.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_12.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_13.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_14.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_15.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_16.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_17.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_18.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_19.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_20.Image = My.Resources.icon_heart_0x4
        ElseIf valu_currenthearts.Value = 38 Then
            Icon_currentheart_1.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_2.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_3.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_4.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_5.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_6.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_7.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_8.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_9.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_10.Image = My.Resources.icon_heart_2x4
            Icon_currentheart_11.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_12.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_13.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_14.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_15.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_16.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_17.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_18.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_19.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_20.Image = My.Resources.icon_heart_0x4
        ElseIf valu_currenthearts.Value = 39 Then
            Icon_currentheart_1.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_2.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_3.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_4.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_5.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_6.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_7.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_8.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_9.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_10.Image = My.Resources.icon_heart_3x4
            Icon_currentheart_11.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_12.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_13.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_14.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_15.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_16.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_17.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_18.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_19.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_20.Image = My.Resources.icon_heart_0x4
        ElseIf valu_currenthearts.Value = 40 Then
            Icon_currentheart_1.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_2.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_3.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_4.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_5.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_6.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_7.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_8.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_9.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_10.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_11.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_12.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_13.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_14.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_15.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_16.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_17.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_18.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_19.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_20.Image = My.Resources.icon_heart_0x4
        ElseIf valu_currenthearts.Value = 41 Then
            Icon_currentheart_1.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_2.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_3.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_4.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_5.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_6.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_7.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_8.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_9.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_10.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_11.Image = My.Resources.icon_heart_1x4
            Icon_currentheart_12.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_13.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_14.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_15.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_16.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_17.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_18.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_19.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_20.Image = My.Resources.icon_heart_0x4
        ElseIf valu_currenthearts.Value = 42 Then
            Icon_currentheart_1.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_2.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_3.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_4.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_5.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_6.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_7.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_8.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_9.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_10.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_11.Image = My.Resources.icon_heart_2x4
            Icon_currentheart_12.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_13.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_14.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_15.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_16.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_17.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_18.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_19.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_20.Image = My.Resources.icon_heart_0x4
        ElseIf valu_currenthearts.Value = 43 Then
            Icon_currentheart_1.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_2.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_3.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_4.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_5.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_6.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_7.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_8.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_9.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_10.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_11.Image = My.Resources.icon_heart_3x4
            Icon_currentheart_12.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_13.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_14.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_15.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_16.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_17.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_18.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_19.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_20.Image = My.Resources.icon_heart_0x4
        ElseIf valu_currenthearts.Value = 44 Then
            Icon_currentheart_1.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_2.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_3.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_4.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_5.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_6.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_7.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_8.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_9.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_10.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_11.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_12.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_13.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_14.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_15.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_16.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_17.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_18.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_19.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_20.Image = My.Resources.icon_heart_0x4
        ElseIf valu_currenthearts.Value = 45 Then
            Icon_currentheart_1.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_2.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_3.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_4.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_5.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_6.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_7.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_8.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_9.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_10.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_11.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_12.Image = My.Resources.icon_heart_1x4
            Icon_currentheart_13.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_14.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_15.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_16.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_17.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_18.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_19.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_20.Image = My.Resources.icon_heart_0x4
        ElseIf valu_currenthearts.Value = 46 Then
            Icon_currentheart_1.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_2.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_3.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_4.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_5.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_6.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_7.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_8.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_9.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_10.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_11.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_12.Image = My.Resources.icon_heart_2x4
            Icon_currentheart_13.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_14.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_15.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_16.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_17.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_18.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_19.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_20.Image = My.Resources.icon_heart_0x4
        ElseIf valu_currenthearts.Value = 47 Then
            Icon_currentheart_1.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_2.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_3.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_4.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_5.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_6.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_7.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_8.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_9.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_10.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_11.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_12.Image = My.Resources.icon_heart_3x4
            Icon_currentheart_13.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_14.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_15.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_16.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_17.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_18.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_19.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_20.Image = My.Resources.icon_heart_0x4
        ElseIf valu_currenthearts.Value = 48 Then
            Icon_currentheart_1.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_2.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_3.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_4.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_5.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_6.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_7.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_8.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_9.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_10.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_11.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_12.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_13.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_14.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_15.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_16.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_17.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_18.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_19.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_20.Image = My.Resources.icon_heart_0x4
        ElseIf valu_currenthearts.Value = 49 Then
            Icon_currentheart_1.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_2.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_3.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_4.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_5.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_6.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_7.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_8.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_9.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_10.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_11.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_12.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_13.Image = My.Resources.icon_heart_1x4
            Icon_currentheart_14.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_15.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_16.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_17.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_18.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_19.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_20.Image = My.Resources.icon_heart_0x4
        ElseIf valu_currenthearts.Value = 50 Then
            Icon_currentheart_1.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_2.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_3.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_4.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_5.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_6.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_7.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_8.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_9.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_10.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_11.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_12.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_13.Image = My.Resources.icon_heart_2x4
            Icon_currentheart_14.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_15.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_16.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_17.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_18.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_19.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_20.Image = My.Resources.icon_heart_0x4
        ElseIf valu_currenthearts.Value = 51 Then
            Icon_currentheart_1.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_2.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_3.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_4.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_5.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_6.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_7.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_8.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_9.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_10.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_11.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_12.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_13.Image = My.Resources.icon_heart_3x4
            Icon_currentheart_14.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_15.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_16.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_17.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_18.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_19.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_20.Image = My.Resources.icon_heart_0x4
        ElseIf valu_currenthearts.Value = 52 Then
            Icon_currentheart_1.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_2.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_3.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_4.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_5.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_6.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_7.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_8.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_9.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_10.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_11.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_12.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_13.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_14.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_15.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_16.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_17.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_18.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_19.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_20.Image = My.Resources.icon_heart_0x4
        ElseIf valu_currenthearts.Value = 53 Then
            Icon_currentheart_1.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_2.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_3.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_4.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_5.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_6.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_7.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_8.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_9.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_10.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_11.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_12.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_13.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_14.Image = My.Resources.icon_heart_1x4
            Icon_currentheart_15.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_16.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_17.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_18.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_19.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_20.Image = My.Resources.icon_heart_0x4
        ElseIf valu_currenthearts.Value = 54 Then
            Icon_currentheart_1.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_2.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_3.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_4.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_5.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_6.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_7.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_8.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_9.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_10.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_11.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_12.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_13.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_14.Image = My.Resources.icon_heart_2x4
            Icon_currentheart_15.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_16.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_17.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_18.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_19.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_20.Image = My.Resources.icon_heart_0x4
        ElseIf valu_currenthearts.Value = 55 Then
            Icon_currentheart_1.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_2.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_3.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_4.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_5.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_6.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_7.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_8.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_9.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_10.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_11.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_12.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_13.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_14.Image = My.Resources.icon_heart_3x4
            Icon_currentheart_15.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_16.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_17.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_18.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_19.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_20.Image = My.Resources.icon_heart_0x4
        ElseIf valu_currenthearts.Value = 56 Then
            Icon_currentheart_1.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_2.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_3.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_4.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_5.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_6.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_7.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_8.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_9.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_10.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_11.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_12.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_13.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_14.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_15.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_16.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_17.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_18.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_19.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_20.Image = My.Resources.icon_heart_0x4
        ElseIf valu_currenthearts.Value = 57 Then
            Icon_currentheart_1.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_2.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_3.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_4.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_5.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_6.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_7.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_8.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_9.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_10.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_11.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_12.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_13.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_14.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_15.Image = My.Resources.icon_heart_1x4
            Icon_currentheart_16.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_17.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_18.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_19.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_20.Image = My.Resources.icon_heart_0x4
        ElseIf valu_currenthearts.Value = 58 Then
            Icon_currentheart_1.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_2.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_3.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_4.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_5.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_6.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_7.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_8.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_9.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_10.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_11.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_12.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_13.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_14.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_15.Image = My.Resources.icon_heart_2x4
            Icon_currentheart_16.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_17.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_18.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_19.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_20.Image = My.Resources.icon_heart_0x4
        ElseIf valu_currenthearts.Value = 59 Then
            Icon_currentheart_1.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_2.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_3.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_4.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_5.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_6.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_7.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_8.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_9.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_10.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_11.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_12.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_13.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_14.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_15.Image = My.Resources.icon_heart_3x4
            Icon_currentheart_16.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_17.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_18.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_19.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_20.Image = My.Resources.icon_heart_0x4
        ElseIf valu_currenthearts.Value = 60 Then
            Icon_currentheart_1.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_2.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_3.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_4.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_5.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_6.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_7.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_8.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_9.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_10.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_11.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_12.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_13.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_14.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_15.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_16.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_17.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_18.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_19.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_20.Image = My.Resources.icon_heart_0x4
        ElseIf valu_currenthearts.Value = 61 Then
            Icon_currentheart_1.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_2.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_3.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_4.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_5.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_6.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_7.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_8.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_9.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_10.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_11.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_12.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_13.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_14.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_15.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_16.Image = My.Resources.icon_heart_1x4
            Icon_currentheart_17.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_18.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_19.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_20.Image = My.Resources.icon_heart_0x4
        ElseIf valu_currenthearts.Value = 62 Then
            Icon_currentheart_1.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_2.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_3.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_4.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_5.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_6.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_7.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_8.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_9.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_10.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_11.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_12.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_13.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_14.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_15.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_16.Image = My.Resources.icon_heart_2x4
            Icon_currentheart_17.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_18.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_19.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_20.Image = My.Resources.icon_heart_0x4
        ElseIf valu_currenthearts.Value = 63 Then
            Icon_currentheart_1.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_2.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_3.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_4.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_5.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_6.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_7.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_8.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_9.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_10.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_11.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_12.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_13.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_14.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_15.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_16.Image = My.Resources.icon_heart_3x4
            Icon_currentheart_17.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_18.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_19.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_20.Image = My.Resources.icon_heart_0x4
        ElseIf valu_currenthearts.Value = 64 Then
            Icon_currentheart_1.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_2.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_3.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_4.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_5.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_6.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_7.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_8.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_9.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_10.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_11.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_12.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_13.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_14.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_15.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_16.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_17.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_18.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_19.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_20.Image = My.Resources.icon_heart_0x4
        ElseIf valu_currenthearts.Value = 65 Then
            Icon_currentheart_1.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_2.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_3.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_4.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_5.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_6.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_7.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_8.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_9.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_10.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_11.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_12.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_13.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_14.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_15.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_16.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_17.Image = My.Resources.icon_heart_1x4
            Icon_currentheart_18.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_19.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_20.Image = My.Resources.icon_heart_0x4
        ElseIf valu_currenthearts.Value = 66 Then
            Icon_currentheart_1.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_2.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_3.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_4.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_5.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_6.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_7.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_8.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_9.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_10.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_11.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_12.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_13.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_14.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_15.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_16.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_17.Image = My.Resources.icon_heart_2x4
            Icon_currentheart_18.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_19.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_20.Image = My.Resources.icon_heart_0x4
        ElseIf valu_currenthearts.Value = 67 Then
            Icon_currentheart_1.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_2.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_3.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_4.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_5.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_6.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_7.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_8.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_9.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_10.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_11.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_12.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_13.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_14.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_15.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_16.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_17.Image = My.Resources.icon_heart_3x4
            Icon_currentheart_18.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_19.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_20.Image = My.Resources.icon_heart_0x4
        ElseIf valu_currenthearts.Value = 68 Then
            Icon_currentheart_1.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_2.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_3.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_4.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_5.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_6.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_7.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_8.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_9.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_10.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_11.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_12.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_13.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_14.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_15.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_16.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_17.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_18.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_19.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_20.Image = My.Resources.icon_heart_0x4
        ElseIf valu_currenthearts.Value = 69 Then
            Icon_currentheart_1.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_2.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_3.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_4.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_5.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_6.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_7.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_8.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_9.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_10.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_11.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_12.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_13.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_14.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_15.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_16.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_17.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_18.Image = My.Resources.icon_heart_1x4
            Icon_currentheart_19.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_20.Image = My.Resources.icon_heart_0x4
        ElseIf valu_currenthearts.Value = 70 Then
            Icon_currentheart_1.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_2.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_3.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_4.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_5.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_6.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_7.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_8.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_9.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_10.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_11.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_12.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_13.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_14.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_15.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_16.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_17.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_18.Image = My.Resources.icon_heart_2x4
            Icon_currentheart_19.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_20.Image = My.Resources.icon_heart_0x4
        ElseIf valu_currenthearts.Value = 71 Then
            Icon_currentheart_1.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_2.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_3.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_4.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_5.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_6.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_7.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_8.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_9.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_10.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_11.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_12.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_13.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_14.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_15.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_16.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_17.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_18.Image = My.Resources.icon_heart_3x4
            Icon_currentheart_19.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_20.Image = My.Resources.icon_heart_0x4
        ElseIf valu_currenthearts.Value = 72 Then
            Icon_currentheart_1.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_2.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_3.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_4.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_5.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_6.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_7.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_8.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_9.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_10.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_11.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_12.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_13.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_14.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_15.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_16.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_17.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_18.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_19.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_20.Image = My.Resources.icon_heart_0x4
        ElseIf valu_currenthearts.Value = 73 Then
            Icon_currentheart_1.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_2.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_3.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_4.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_5.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_6.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_7.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_8.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_9.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_10.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_11.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_12.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_13.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_14.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_15.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_16.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_17.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_18.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_19.Image = My.Resources.icon_heart_1x4
            Icon_currentheart_20.Image = My.Resources.icon_heart_0x4
        ElseIf valu_currenthearts.Value = 74 Then
            Icon_currentheart_1.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_2.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_3.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_4.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_5.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_6.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_7.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_8.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_9.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_10.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_11.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_12.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_13.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_14.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_15.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_16.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_17.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_18.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_19.Image = My.Resources.icon_heart_2x4
            Icon_currentheart_20.Image = My.Resources.icon_heart_0x4
        ElseIf valu_currenthearts.Value = 75 Then
            Icon_currentheart_1.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_2.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_3.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_4.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_5.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_6.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_7.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_8.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_9.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_10.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_11.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_12.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_13.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_14.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_15.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_16.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_17.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_18.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_19.Image = My.Resources.icon_heart_3x4
            Icon_currentheart_20.Image = My.Resources.icon_heart_0x4
        ElseIf valu_currenthearts.Value = 76 Then
            Icon_currentheart_1.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_2.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_3.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_4.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_5.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_6.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_7.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_8.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_9.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_10.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_11.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_12.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_13.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_14.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_15.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_16.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_17.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_18.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_19.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_20.Image = My.Resources.icon_heart_0x4
        ElseIf valu_currenthearts.Value = 77 Then
            Icon_currentheart_1.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_2.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_3.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_4.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_5.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_6.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_7.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_8.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_9.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_10.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_11.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_12.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_13.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_14.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_15.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_16.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_17.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_18.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_19.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_20.Image = My.Resources.icon_heart_1x4
        ElseIf valu_currenthearts.Value = 78 Then
            Icon_currentheart_1.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_2.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_3.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_4.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_5.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_6.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_7.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_8.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_9.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_10.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_11.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_12.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_13.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_14.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_15.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_16.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_17.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_18.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_19.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_20.Image = My.Resources.icon_heart_2x4
        ElseIf valu_currenthearts.Value = 79 Then
            Icon_currentheart_1.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_2.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_3.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_4.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_5.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_6.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_7.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_8.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_9.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_10.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_11.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_12.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_13.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_14.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_15.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_16.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_17.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_18.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_19.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_20.Image = My.Resources.icon_heart_3x4
        ElseIf valu_currenthearts.Value = 80 Then
            Icon_currentheart_1.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_2.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_3.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_4.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_5.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_6.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_7.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_8.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_9.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_10.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_11.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_12.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_13.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_14.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_15.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_16.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_17.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_18.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_19.Image = My.Resources.icon_heart_4x4
            Icon_currentheart_20.Image = My.Resources.icon_heart_4x4
        Else
            Icon_currentheart_1.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_2.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_3.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_4.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_5.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_6.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_7.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_8.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_9.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_10.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_11.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_12.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_13.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_14.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_15.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_16.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_17.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_18.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_19.Image = My.Resources.icon_heart_0x4
            Icon_currentheart_20.Image = My.Resources.icon_heart_0x4
        End If
    End Sub

    Private Sub valu_currenthearts_ValueChanged(sender As Object, e As EventArgs) Handles valu_currenthearts.ValueChanged
        Currentheart()
    End Sub

    Private Sub Icon_currentheart_1_MouseMove(sender As Object, e As MouseEventArgs) Handles Icon_currentheart_1.MouseMove
        Icon_currentheart_1.Image = My.Resources.icon_heart_4x4
        Icon_currentheart_2.Image = My.Resources.icon_heart_0x4
        Icon_currentheart_3.Image = My.Resources.icon_heart_0x4
        Icon_currentheart_4.Image = My.Resources.icon_heart_0x4
        Icon_currentheart_5.Image = My.Resources.icon_heart_0x4
        Icon_currentheart_6.Image = My.Resources.icon_heart_0x4
        Icon_currentheart_7.Image = My.Resources.icon_heart_0x4
        Icon_currentheart_8.Image = My.Resources.icon_heart_0x4
        Icon_currentheart_9.Image = My.Resources.icon_heart_0x4
        Icon_currentheart_10.Image = My.Resources.icon_heart_0x4
        Icon_currentheart_11.Image = My.Resources.icon_heart_0x4
        Icon_currentheart_12.Image = My.Resources.icon_heart_0x4
        Icon_currentheart_13.Image = My.Resources.icon_heart_0x4
        Icon_currentheart_14.Image = My.Resources.icon_heart_0x4
        Icon_currentheart_15.Image = My.Resources.icon_heart_0x4
        Icon_currentheart_16.Image = My.Resources.icon_heart_0x4
        Icon_currentheart_17.Image = My.Resources.icon_heart_0x4
        Icon_currentheart_18.Image = My.Resources.icon_heart_0x4
        Icon_currentheart_19.Image = My.Resources.icon_heart_0x4
        Icon_currentheart_20.Image = My.Resources.icon_heart_0x4
    End Sub

    Private Sub Icon_currentheart_1_MouseLeave(sender As Object, e As EventArgs) Handles Icon_currentheart_1.MouseLeave
        Currentheart()
    End Sub

    Private Sub Icon_currentheart_1_Click(sender As Object, e As EventArgs) Handles Icon_currentheart_1.Click
        If valu_currenthearts.Value = 4 Then
            valu_currenthearts.Value = 1
        ElseIf valu_currenthearts.Value = 1 Then
            valu_currenthearts.Value = 2
        ElseIf valu_currenthearts.Value = 2 Then
            valu_currenthearts.Value = 3
        ElseIf valu_currenthearts.Value = 3 Then
            valu_currenthearts.Value = 4
        Else
            valu_currenthearts.Value = 4
        End If
    End Sub

    Private Sub Icon_currentheart_2_MouseMove(sender As Object, e As MouseEventArgs) Handles Icon_currentheart_2.MouseMove
        Icon_currentheart_1.Image = My.Resources.icon_heart_4x4
        Icon_currentheart_2.Image = My.Resources.icon_heart_4x4
        Icon_currentheart_3.Image = My.Resources.icon_heart_0x4
        Icon_currentheart_4.Image = My.Resources.icon_heart_0x4
        Icon_currentheart_5.Image = My.Resources.icon_heart_0x4
        Icon_currentheart_6.Image = My.Resources.icon_heart_0x4
        Icon_currentheart_7.Image = My.Resources.icon_heart_0x4
        Icon_currentheart_8.Image = My.Resources.icon_heart_0x4
        Icon_currentheart_9.Image = My.Resources.icon_heart_0x4
        Icon_currentheart_10.Image = My.Resources.icon_heart_0x4
        Icon_currentheart_11.Image = My.Resources.icon_heart_0x4
        Icon_currentheart_12.Image = My.Resources.icon_heart_0x4
        Icon_currentheart_13.Image = My.Resources.icon_heart_0x4
        Icon_currentheart_14.Image = My.Resources.icon_heart_0x4
        Icon_currentheart_15.Image = My.Resources.icon_heart_0x4
        Icon_currentheart_16.Image = My.Resources.icon_heart_0x4
        Icon_currentheart_17.Image = My.Resources.icon_heart_0x4
        Icon_currentheart_18.Image = My.Resources.icon_heart_0x4
        Icon_currentheart_19.Image = My.Resources.icon_heart_0x4
        Icon_currentheart_20.Image = My.Resources.icon_heart_0x4
    End Sub

    Private Sub Icon_currentheart_2_MouseLeave(sender As Object, e As EventArgs) Handles Icon_currentheart_2.MouseLeave
        Currentheart()
    End Sub

    Private Sub Icon_currentheart_2_Click(sender As Object, e As EventArgs) Handles Icon_currentheart_2.Click
        If valu_currenthearts.Value = 8 Then
            valu_currenthearts.Value = 5
        ElseIf valu_currenthearts.Value = 5 Then
            valu_currenthearts.Value = 6
        ElseIf valu_currenthearts.Value = 6 Then
            valu_currenthearts.Value = 7
        ElseIf valu_currenthearts.Value = 7 Then
            valu_currenthearts.Value = 8
        Else
            valu_currenthearts.Value = 8
        End If
    End Sub

    Private Sub Icon_currentheart_3_MouseMove(sender As Object, e As MouseEventArgs) Handles Icon_currentheart_3.MouseMove
        Icon_currentheart_1.Image = My.Resources.icon_heart_4x4
        Icon_currentheart_2.Image = My.Resources.icon_heart_4x4
        Icon_currentheart_3.Image = My.Resources.icon_heart_4x4
        Icon_currentheart_4.Image = My.Resources.icon_heart_0x4
        Icon_currentheart_5.Image = My.Resources.icon_heart_0x4
        Icon_currentheart_6.Image = My.Resources.icon_heart_0x4
        Icon_currentheart_7.Image = My.Resources.icon_heart_0x4
        Icon_currentheart_8.Image = My.Resources.icon_heart_0x4
        Icon_currentheart_9.Image = My.Resources.icon_heart_0x4
        Icon_currentheart_10.Image = My.Resources.icon_heart_0x4
        Icon_currentheart_11.Image = My.Resources.icon_heart_0x4
        Icon_currentheart_12.Image = My.Resources.icon_heart_0x4
        Icon_currentheart_13.Image = My.Resources.icon_heart_0x4
        Icon_currentheart_14.Image = My.Resources.icon_heart_0x4
        Icon_currentheart_15.Image = My.Resources.icon_heart_0x4
        Icon_currentheart_16.Image = My.Resources.icon_heart_0x4
        Icon_currentheart_17.Image = My.Resources.icon_heart_0x4
        Icon_currentheart_18.Image = My.Resources.icon_heart_0x4
        Icon_currentheart_19.Image = My.Resources.icon_heart_0x4
        Icon_currentheart_20.Image = My.Resources.icon_heart_0x4
    End Sub

    Private Sub Icon_currentheart_3_MouseLeave(sender As Object, e As EventArgs) Handles Icon_currentheart_3.MouseLeave
        Currentheart()
    End Sub

    Private Sub Icon_currentheart_3_Click(sender As Object, e As EventArgs) Handles Icon_currentheart_3.Click
        If valu_currenthearts.Value = 12 Then
            valu_currenthearts.Value = 9
        ElseIf valu_currenthearts.Value = 9 Then
            valu_currenthearts.Value = 10
        ElseIf valu_currenthearts.Value = 10 Then
            valu_currenthearts.Value = 11
        ElseIf valu_currenthearts.Value = 11 Then
            valu_currenthearts.Value = 12
        Else
            valu_currenthearts.Value = 12
        End If
    End Sub

    Private Sub Icon_currentheart_4_MouseMove(sender As Object, e As MouseEventArgs) Handles Icon_currentheart_4.MouseMove
        Icon_currentheart_1.Image = My.Resources.icon_heart_4x4
        Icon_currentheart_2.Image = My.Resources.icon_heart_4x4
        Icon_currentheart_3.Image = My.Resources.icon_heart_4x4
        Icon_currentheart_4.Image = My.Resources.icon_heart_4x4
        Icon_currentheart_5.Image = My.Resources.icon_heart_0x4
        Icon_currentheart_6.Image = My.Resources.icon_heart_0x4
        Icon_currentheart_7.Image = My.Resources.icon_heart_0x4
        Icon_currentheart_8.Image = My.Resources.icon_heart_0x4
        Icon_currentheart_9.Image = My.Resources.icon_heart_0x4
        Icon_currentheart_10.Image = My.Resources.icon_heart_0x4
        Icon_currentheart_11.Image = My.Resources.icon_heart_0x4
        Icon_currentheart_12.Image = My.Resources.icon_heart_0x4
        Icon_currentheart_13.Image = My.Resources.icon_heart_0x4
        Icon_currentheart_14.Image = My.Resources.icon_heart_0x4
        Icon_currentheart_15.Image = My.Resources.icon_heart_0x4
        Icon_currentheart_16.Image = My.Resources.icon_heart_0x4
        Icon_currentheart_17.Image = My.Resources.icon_heart_0x4
        Icon_currentheart_18.Image = My.Resources.icon_heart_0x4
        Icon_currentheart_19.Image = My.Resources.icon_heart_0x4
        Icon_currentheart_20.Image = My.Resources.icon_heart_0x4
    End Sub

    Private Sub Icon_currentheart_4_MouseLeave(sender As Object, e As EventArgs) Handles Icon_currentheart_4.MouseLeave
        Currentheart()
    End Sub

    Private Sub Icon_currentheart_4_Click(sender As Object, e As EventArgs) Handles Icon_currentheart_4.Click
        If valu_currenthearts.Value = 16 Then
            valu_currenthearts.Value = 13
        ElseIf valu_currenthearts.Value = 13 Then
            valu_currenthearts.Value = 14
        ElseIf valu_currenthearts.Value = 14 Then
            valu_currenthearts.Value = 15
        ElseIf valu_currenthearts.Value = 15 Then
            valu_currenthearts.Value = 16
        Else
            valu_currenthearts.Value = 16
        End If
    End Sub

    Private Sub Icon_currentheart_5_MouseMove(sender As Object, e As MouseEventArgs) Handles Icon_currentheart_5.MouseMove
        Icon_currentheart_1.Image = My.Resources.icon_heart_4x4
        Icon_currentheart_2.Image = My.Resources.icon_heart_4x4
        Icon_currentheart_3.Image = My.Resources.icon_heart_4x4
        Icon_currentheart_4.Image = My.Resources.icon_heart_4x4
        Icon_currentheart_5.Image = My.Resources.icon_heart_4x4
        Icon_currentheart_6.Image = My.Resources.icon_heart_0x4
        Icon_currentheart_7.Image = My.Resources.icon_heart_0x4
        Icon_currentheart_8.Image = My.Resources.icon_heart_0x4
        Icon_currentheart_9.Image = My.Resources.icon_heart_0x4
        Icon_currentheart_10.Image = My.Resources.icon_heart_0x4
        Icon_currentheart_11.Image = My.Resources.icon_heart_0x4
        Icon_currentheart_12.Image = My.Resources.icon_heart_0x4
        Icon_currentheart_13.Image = My.Resources.icon_heart_0x4
        Icon_currentheart_14.Image = My.Resources.icon_heart_0x4
        Icon_currentheart_15.Image = My.Resources.icon_heart_0x4
        Icon_currentheart_16.Image = My.Resources.icon_heart_0x4
        Icon_currentheart_17.Image = My.Resources.icon_heart_0x4
        Icon_currentheart_18.Image = My.Resources.icon_heart_0x4
        Icon_currentheart_19.Image = My.Resources.icon_heart_0x4
        Icon_currentheart_20.Image = My.Resources.icon_heart_0x4
    End Sub

    Private Sub Icon_currentheart_5_MouseLeave(sender As Object, e As EventArgs) Handles Icon_currentheart_5.MouseLeave
        Currentheart()
    End Sub

    Private Sub Icon_currentheart_5_Click(sender As Object, e As EventArgs) Handles Icon_currentheart_5.Click
        If valu_currenthearts.Value = 20 Then
            valu_currenthearts.Value = 17
        ElseIf valu_currenthearts.Value = 17 Then
            valu_currenthearts.Value = 18
        ElseIf valu_currenthearts.Value = 18 Then
            valu_currenthearts.Value = 19
        ElseIf valu_currenthearts.Value = 19 Then
            valu_currenthearts.Value = 20
        Else
            valu_currenthearts.Value = 20
        End If
    End Sub

    Private Sub Icon_currentheart_6_MouseMove(sender As Object, e As MouseEventArgs) Handles Icon_currentheart_6.MouseMove
        Icon_currentheart_1.Image = My.Resources.icon_heart_4x4
        Icon_currentheart_2.Image = My.Resources.icon_heart_4x4
        Icon_currentheart_3.Image = My.Resources.icon_heart_4x4
        Icon_currentheart_4.Image = My.Resources.icon_heart_4x4
        Icon_currentheart_5.Image = My.Resources.icon_heart_4x4
        Icon_currentheart_6.Image = My.Resources.icon_heart_4x4
        Icon_currentheart_7.Image = My.Resources.icon_heart_0x4
        Icon_currentheart_8.Image = My.Resources.icon_heart_0x4
        Icon_currentheart_9.Image = My.Resources.icon_heart_0x4
        Icon_currentheart_10.Image = My.Resources.icon_heart_0x4
        Icon_currentheart_11.Image = My.Resources.icon_heart_0x4
        Icon_currentheart_12.Image = My.Resources.icon_heart_0x4
        Icon_currentheart_13.Image = My.Resources.icon_heart_0x4
        Icon_currentheart_14.Image = My.Resources.icon_heart_0x4
        Icon_currentheart_15.Image = My.Resources.icon_heart_0x4
        Icon_currentheart_16.Image = My.Resources.icon_heart_0x4
        Icon_currentheart_17.Image = My.Resources.icon_heart_0x4
        Icon_currentheart_18.Image = My.Resources.icon_heart_0x4
        Icon_currentheart_19.Image = My.Resources.icon_heart_0x4
        Icon_currentheart_20.Image = My.Resources.icon_heart_0x4
    End Sub

    Private Sub Icon_currentheart_6_MouseLeave(sender As Object, e As EventArgs) Handles Icon_currentheart_6.MouseLeave
        Currentheart()
    End Sub

    Private Sub Icon_currentheart_6_Click(sender As Object, e As EventArgs) Handles Icon_currentheart_6.Click
        If valu_currenthearts.Value = 24 Then
            valu_currenthearts.Value = 21
        ElseIf valu_currenthearts.Value = 21 Then
            valu_currenthearts.Value = 22
        ElseIf valu_currenthearts.Value = 22 Then
            valu_currenthearts.Value = 23
        ElseIf valu_currenthearts.Value = 23 Then
            valu_currenthearts.Value = 24
        Else
            valu_currenthearts.Value = 24
        End If
    End Sub

    Private Sub Icon_currentheart_7_MouseMove(sender As Object, e As MouseEventArgs) Handles Icon_currentheart_7.MouseMove
        Icon_currentheart_1.Image = My.Resources.icon_heart_4x4
        Icon_currentheart_2.Image = My.Resources.icon_heart_4x4
        Icon_currentheart_3.Image = My.Resources.icon_heart_4x4
        Icon_currentheart_4.Image = My.Resources.icon_heart_4x4
        Icon_currentheart_5.Image = My.Resources.icon_heart_4x4
        Icon_currentheart_6.Image = My.Resources.icon_heart_4x4
        Icon_currentheart_7.Image = My.Resources.icon_heart_4x4
        Icon_currentheart_8.Image = My.Resources.icon_heart_0x4
        Icon_currentheart_9.Image = My.Resources.icon_heart_0x4
        Icon_currentheart_10.Image = My.Resources.icon_heart_0x4
        Icon_currentheart_11.Image = My.Resources.icon_heart_0x4
        Icon_currentheart_12.Image = My.Resources.icon_heart_0x4
        Icon_currentheart_13.Image = My.Resources.icon_heart_0x4
        Icon_currentheart_14.Image = My.Resources.icon_heart_0x4
        Icon_currentheart_15.Image = My.Resources.icon_heart_0x4
        Icon_currentheart_16.Image = My.Resources.icon_heart_0x4
        Icon_currentheart_17.Image = My.Resources.icon_heart_0x4
        Icon_currentheart_18.Image = My.Resources.icon_heart_0x4
        Icon_currentheart_19.Image = My.Resources.icon_heart_0x4
        Icon_currentheart_20.Image = My.Resources.icon_heart_0x4
    End Sub

    Private Sub Icon_currentheart_7_MouseLeave(sender As Object, e As EventArgs) Handles Icon_currentheart_7.MouseLeave
        Currentheart()
    End Sub

    Private Sub Icon_currentheart_7_Click(sender As Object, e As EventArgs) Handles Icon_currentheart_7.Click
        If valu_currenthearts.Value = 28 Then
            valu_currenthearts.Value = 25
        ElseIf valu_currenthearts.Value = 25 Then
            valu_currenthearts.Value = 26
        ElseIf valu_currenthearts.Value = 26 Then
            valu_currenthearts.Value = 27
        ElseIf valu_currenthearts.Value = 27 Then
            valu_currenthearts.Value = 28
        Else
            valu_currenthearts.Value = 28
        End If
    End Sub

    Private Sub Icon_currentheart_8_MouseMove(sender As Object, e As MouseEventArgs) Handles Icon_currentheart_8.MouseMove
        Icon_currentheart_1.Image = My.Resources.icon_heart_4x4
        Icon_currentheart_2.Image = My.Resources.icon_heart_4x4
        Icon_currentheart_3.Image = My.Resources.icon_heart_4x4
        Icon_currentheart_4.Image = My.Resources.icon_heart_4x4
        Icon_currentheart_5.Image = My.Resources.icon_heart_4x4
        Icon_currentheart_6.Image = My.Resources.icon_heart_4x4
        Icon_currentheart_7.Image = My.Resources.icon_heart_4x4
        Icon_currentheart_8.Image = My.Resources.icon_heart_4x4
        Icon_currentheart_9.Image = My.Resources.icon_heart_0x4
        Icon_currentheart_10.Image = My.Resources.icon_heart_0x4
        Icon_currentheart_11.Image = My.Resources.icon_heart_0x4
        Icon_currentheart_12.Image = My.Resources.icon_heart_0x4
        Icon_currentheart_13.Image = My.Resources.icon_heart_0x4
        Icon_currentheart_14.Image = My.Resources.icon_heart_0x4
        Icon_currentheart_15.Image = My.Resources.icon_heart_0x4
        Icon_currentheart_16.Image = My.Resources.icon_heart_0x4
        Icon_currentheart_17.Image = My.Resources.icon_heart_0x4
        Icon_currentheart_18.Image = My.Resources.icon_heart_0x4
        Icon_currentheart_19.Image = My.Resources.icon_heart_0x4
        Icon_currentheart_20.Image = My.Resources.icon_heart_0x4
    End Sub

    Private Sub Icon_currentheart_8_MouseLeave(sender As Object, e As EventArgs) Handles Icon_currentheart_8.MouseLeave
        Currentheart()
    End Sub

    Private Sub Icon_currentheart_8_Click(sender As Object, e As EventArgs) Handles Icon_currentheart_8.Click
        If valu_currenthearts.Value = 32 Then
            valu_currenthearts.Value = 29
        ElseIf valu_currenthearts.Value = 29 Then
            valu_currenthearts.Value = 30
        ElseIf valu_currenthearts.Value = 30 Then
            valu_currenthearts.Value = 31
        ElseIf valu_currenthearts.Value = 31 Then
            valu_currenthearts.Value = 32
        Else
            valu_currenthearts.Value = 32
        End If
    End Sub

    Private Sub Icon_currentheart_9_MouseMove(sender As Object, e As MouseEventArgs) Handles Icon_currentheart_9.MouseMove
        Icon_currentheart_1.Image = My.Resources.icon_heart_4x4
        Icon_currentheart_2.Image = My.Resources.icon_heart_4x4
        Icon_currentheart_3.Image = My.Resources.icon_heart_4x4
        Icon_currentheart_4.Image = My.Resources.icon_heart_4x4
        Icon_currentheart_5.Image = My.Resources.icon_heart_4x4
        Icon_currentheart_6.Image = My.Resources.icon_heart_4x4
        Icon_currentheart_7.Image = My.Resources.icon_heart_4x4
        Icon_currentheart_8.Image = My.Resources.icon_heart_4x4
        Icon_currentheart_9.Image = My.Resources.icon_heart_4x4
        Icon_currentheart_10.Image = My.Resources.icon_heart_0x4
        Icon_currentheart_11.Image = My.Resources.icon_heart_0x4
        Icon_currentheart_12.Image = My.Resources.icon_heart_0x4
        Icon_currentheart_13.Image = My.Resources.icon_heart_0x4
        Icon_currentheart_14.Image = My.Resources.icon_heart_0x4
        Icon_currentheart_15.Image = My.Resources.icon_heart_0x4
        Icon_currentheart_16.Image = My.Resources.icon_heart_0x4
        Icon_currentheart_17.Image = My.Resources.icon_heart_0x4
        Icon_currentheart_18.Image = My.Resources.icon_heart_0x4
        Icon_currentheart_19.Image = My.Resources.icon_heart_0x4
        Icon_currentheart_20.Image = My.Resources.icon_heart_0x4
    End Sub

    Private Sub Icon_currentheart_9_MouseLeave(sender As Object, e As EventArgs) Handles Icon_currentheart_9.MouseLeave
        Currentheart()
    End Sub

    Private Sub Icon_currentheart_9_Click(sender As Object, e As EventArgs) Handles Icon_currentheart_9.Click
        If valu_currenthearts.Value = 36 Then
            valu_currenthearts.Value = 33
        ElseIf valu_currenthearts.Value = 33 Then
            valu_currenthearts.Value = 34
        ElseIf valu_currenthearts.Value = 34 Then
            valu_currenthearts.Value = 35
        ElseIf valu_currenthearts.Value = 35 Then
            valu_currenthearts.Value = 36
        Else
            valu_currenthearts.Value = 36
        End If
    End Sub

    Private Sub Icon_currentheart_10_MouseMove(sender As Object, e As MouseEventArgs) Handles Icon_currentheart_10.MouseMove
        Icon_currentheart_1.Image = My.Resources.icon_heart_4x4
        Icon_currentheart_2.Image = My.Resources.icon_heart_4x4
        Icon_currentheart_3.Image = My.Resources.icon_heart_4x4
        Icon_currentheart_4.Image = My.Resources.icon_heart_4x4
        Icon_currentheart_5.Image = My.Resources.icon_heart_4x4
        Icon_currentheart_6.Image = My.Resources.icon_heart_4x4
        Icon_currentheart_7.Image = My.Resources.icon_heart_4x4
        Icon_currentheart_8.Image = My.Resources.icon_heart_4x4
        Icon_currentheart_9.Image = My.Resources.icon_heart_4x4
        Icon_currentheart_10.Image = My.Resources.icon_heart_4x4
        Icon_currentheart_11.Image = My.Resources.icon_heart_0x4
        Icon_currentheart_12.Image = My.Resources.icon_heart_0x4
        Icon_currentheart_13.Image = My.Resources.icon_heart_0x4
        Icon_currentheart_14.Image = My.Resources.icon_heart_0x4
        Icon_currentheart_15.Image = My.Resources.icon_heart_0x4
        Icon_currentheart_16.Image = My.Resources.icon_heart_0x4
        Icon_currentheart_17.Image = My.Resources.icon_heart_0x4
        Icon_currentheart_18.Image = My.Resources.icon_heart_0x4
        Icon_currentheart_19.Image = My.Resources.icon_heart_0x4
        Icon_currentheart_20.Image = My.Resources.icon_heart_0x4
    End Sub

    Private Sub Icon_currentheart_10_MouseLeave(sender As Object, e As EventArgs) Handles Icon_currentheart_10.MouseLeave
        Currentheart()
    End Sub

    Private Sub Icon_currentheart_10_Click(sender As Object, e As EventArgs) Handles Icon_currentheart_10.Click
        If valu_currenthearts.Value = 40 Then
            valu_currenthearts.Value = 37
        ElseIf valu_currenthearts.Value = 37 Then
            valu_currenthearts.Value = 38
        ElseIf valu_currenthearts.Value = 38 Then
            valu_currenthearts.Value = 39
        ElseIf valu_currenthearts.Value = 39 Then
            valu_currenthearts.Value = 40
        Else
            valu_currenthearts.Value = 40
        End If
    End Sub

    Private Sub Icon_currentheart_11_MouseMove(sender As Object, e As MouseEventArgs) Handles Icon_currentheart_11.MouseMove
        Icon_currentheart_1.Image = My.Resources.icon_heart_4x4
        Icon_currentheart_2.Image = My.Resources.icon_heart_4x4
        Icon_currentheart_3.Image = My.Resources.icon_heart_4x4
        Icon_currentheart_4.Image = My.Resources.icon_heart_4x4
        Icon_currentheart_5.Image = My.Resources.icon_heart_4x4
        Icon_currentheart_6.Image = My.Resources.icon_heart_4x4
        Icon_currentheart_7.Image = My.Resources.icon_heart_4x4
        Icon_currentheart_8.Image = My.Resources.icon_heart_4x4
        Icon_currentheart_9.Image = My.Resources.icon_heart_4x4
        Icon_currentheart_10.Image = My.Resources.icon_heart_4x4
        Icon_currentheart_11.Image = My.Resources.icon_heart_4x4
        Icon_currentheart_12.Image = My.Resources.icon_heart_0x4
        Icon_currentheart_13.Image = My.Resources.icon_heart_0x4
        Icon_currentheart_14.Image = My.Resources.icon_heart_0x4
        Icon_currentheart_15.Image = My.Resources.icon_heart_0x4
        Icon_currentheart_16.Image = My.Resources.icon_heart_0x4
        Icon_currentheart_17.Image = My.Resources.icon_heart_0x4
        Icon_currentheart_18.Image = My.Resources.icon_heart_0x4
        Icon_currentheart_19.Image = My.Resources.icon_heart_0x4
        Icon_currentheart_20.Image = My.Resources.icon_heart_0x4
    End Sub

    Private Sub Icon_currentheart_11_MouseLeave(sender As Object, e As EventArgs) Handles Icon_currentheart_11.MouseLeave
        Currentheart()
    End Sub

    Private Sub Icon_currentheart_11_Click(sender As Object, e As EventArgs) Handles Icon_currentheart_11.Click
        If valu_currenthearts.Value = 44 Then
            valu_currenthearts.Value = 41
        ElseIf valu_currenthearts.Value = 41 Then
            valu_currenthearts.Value = 42
        ElseIf valu_currenthearts.Value = 42 Then
            valu_currenthearts.Value = 43
        ElseIf valu_currenthearts.Value = 43 Then
            valu_currenthearts.Value = 44
        Else
            valu_currenthearts.Value = 44
        End If
    End Sub

    Private Sub Icon_currentheart_12_MouseMove(sender As Object, e As MouseEventArgs) Handles Icon_currentheart_12.MouseMove
        Icon_currentheart_1.Image = My.Resources.icon_heart_4x4
        Icon_currentheart_2.Image = My.Resources.icon_heart_4x4
        Icon_currentheart_3.Image = My.Resources.icon_heart_4x4
        Icon_currentheart_4.Image = My.Resources.icon_heart_4x4
        Icon_currentheart_5.Image = My.Resources.icon_heart_4x4
        Icon_currentheart_6.Image = My.Resources.icon_heart_4x4
        Icon_currentheart_7.Image = My.Resources.icon_heart_4x4
        Icon_currentheart_8.Image = My.Resources.icon_heart_4x4
        Icon_currentheart_9.Image = My.Resources.icon_heart_4x4
        Icon_currentheart_10.Image = My.Resources.icon_heart_4x4
        Icon_currentheart_11.Image = My.Resources.icon_heart_4x4
        Icon_currentheart_12.Image = My.Resources.icon_heart_4x4
        Icon_currentheart_13.Image = My.Resources.icon_heart_0x4
        Icon_currentheart_14.Image = My.Resources.icon_heart_0x4
        Icon_currentheart_15.Image = My.Resources.icon_heart_0x4
        Icon_currentheart_16.Image = My.Resources.icon_heart_0x4
        Icon_currentheart_17.Image = My.Resources.icon_heart_0x4
        Icon_currentheart_18.Image = My.Resources.icon_heart_0x4
        Icon_currentheart_19.Image = My.Resources.icon_heart_0x4
        Icon_currentheart_20.Image = My.Resources.icon_heart_0x4
    End Sub

    Private Sub Icon_currentheart_12_MouseLeave(sender As Object, e As EventArgs) Handles Icon_currentheart_12.MouseLeave
        Currentheart()
    End Sub

    Private Sub Icon_currentheart_12_Click(sender As Object, e As EventArgs) Handles Icon_currentheart_12.Click
        If valu_currenthearts.Value = 48 Then
            valu_currenthearts.Value = 45
        ElseIf valu_currenthearts.Value = 45 Then
            valu_currenthearts.Value = 46
        ElseIf valu_currenthearts.Value = 46 Then
            valu_currenthearts.Value = 47
        ElseIf valu_currenthearts.Value = 47 Then
            valu_currenthearts.Value = 48
        Else
            valu_currenthearts.Value = 48
        End If
    End Sub

    Private Sub Icon_currentheart_13_MouseMove(sender As Object, e As MouseEventArgs) Handles Icon_currentheart_13.MouseMove
        Icon_currentheart_1.Image = My.Resources.icon_heart_4x4
        Icon_currentheart_2.Image = My.Resources.icon_heart_4x4
        Icon_currentheart_3.Image = My.Resources.icon_heart_4x4
        Icon_currentheart_4.Image = My.Resources.icon_heart_4x4
        Icon_currentheart_5.Image = My.Resources.icon_heart_4x4
        Icon_currentheart_6.Image = My.Resources.icon_heart_4x4
        Icon_currentheart_7.Image = My.Resources.icon_heart_4x4
        Icon_currentheart_8.Image = My.Resources.icon_heart_4x4
        Icon_currentheart_9.Image = My.Resources.icon_heart_4x4
        Icon_currentheart_10.Image = My.Resources.icon_heart_4x4
        Icon_currentheart_11.Image = My.Resources.icon_heart_4x4
        Icon_currentheart_12.Image = My.Resources.icon_heart_4x4
        Icon_currentheart_13.Image = My.Resources.icon_heart_4x4
        Icon_currentheart_14.Image = My.Resources.icon_heart_0x4
        Icon_currentheart_15.Image = My.Resources.icon_heart_0x4
        Icon_currentheart_16.Image = My.Resources.icon_heart_0x4
        Icon_currentheart_17.Image = My.Resources.icon_heart_0x4
        Icon_currentheart_18.Image = My.Resources.icon_heart_0x4
        Icon_currentheart_19.Image = My.Resources.icon_heart_0x4
        Icon_currentheart_20.Image = My.Resources.icon_heart_0x4
    End Sub

    Private Sub Icon_currentheart_13_MouseLeave(sender As Object, e As EventArgs) Handles Icon_currentheart_13.MouseLeave
        Currentheart()
    End Sub

    Private Sub Icon_currentheart_13_Click(sender As Object, e As EventArgs) Handles Icon_currentheart_13.Click
        If valu_currenthearts.Value = 52 Then
            valu_currenthearts.Value = 49
        ElseIf valu_currenthearts.Value = 49 Then
            valu_currenthearts.Value = 50
        ElseIf valu_currenthearts.Value = 50 Then
            valu_currenthearts.Value = 51
        ElseIf valu_currenthearts.Value = 51 Then
            valu_currenthearts.Value = 52
        Else
            valu_currenthearts.Value = 52
        End If
    End Sub

    Private Sub Icon_currentheart_14_MouseMove(sender As Object, e As MouseEventArgs) Handles Icon_currentheart_14.MouseMove
        Icon_currentheart_1.Image = My.Resources.icon_heart_4x4
        Icon_currentheart_2.Image = My.Resources.icon_heart_4x4
        Icon_currentheart_3.Image = My.Resources.icon_heart_4x4
        Icon_currentheart_4.Image = My.Resources.icon_heart_4x4
        Icon_currentheart_5.Image = My.Resources.icon_heart_4x4
        Icon_currentheart_6.Image = My.Resources.icon_heart_4x4
        Icon_currentheart_7.Image = My.Resources.icon_heart_4x4
        Icon_currentheart_8.Image = My.Resources.icon_heart_4x4
        Icon_currentheart_9.Image = My.Resources.icon_heart_4x4
        Icon_currentheart_10.Image = My.Resources.icon_heart_4x4
        Icon_currentheart_11.Image = My.Resources.icon_heart_4x4
        Icon_currentheart_12.Image = My.Resources.icon_heart_4x4
        Icon_currentheart_13.Image = My.Resources.icon_heart_4x4
        Icon_currentheart_14.Image = My.Resources.icon_heart_4x4
        Icon_currentheart_15.Image = My.Resources.icon_heart_0x4
        Icon_currentheart_16.Image = My.Resources.icon_heart_0x4
        Icon_currentheart_17.Image = My.Resources.icon_heart_0x4
        Icon_currentheart_18.Image = My.Resources.icon_heart_0x4
        Icon_currentheart_19.Image = My.Resources.icon_heart_0x4
        Icon_currentheart_20.Image = My.Resources.icon_heart_0x4
    End Sub

    Private Sub Icon_currentheart_14_MouseLeave(sender As Object, e As EventArgs) Handles Icon_currentheart_14.MouseLeave
        Currentheart()
    End Sub

    Private Sub Icon_currentheart_14_Click(sender As Object, e As EventArgs) Handles Icon_currentheart_14.Click
        If valu_currenthearts.Value = 56 Then
            valu_currenthearts.Value = 53
        ElseIf valu_currenthearts.Value = 53 Then
            valu_currenthearts.Value = 54
        ElseIf valu_currenthearts.Value = 54 Then
            valu_currenthearts.Value = 55
        ElseIf valu_currenthearts.Value = 55 Then
            valu_currenthearts.Value = 56
        Else
            valu_currenthearts.Value = 56
        End If
    End Sub

    Private Sub Icon_currentheart_15_MouseMove(sender As Object, e As MouseEventArgs) Handles Icon_currentheart_15.MouseMove
        Icon_currentheart_1.Image = My.Resources.icon_heart_4x4
        Icon_currentheart_2.Image = My.Resources.icon_heart_4x4
        Icon_currentheart_3.Image = My.Resources.icon_heart_4x4
        Icon_currentheart_4.Image = My.Resources.icon_heart_4x4
        Icon_currentheart_5.Image = My.Resources.icon_heart_4x4
        Icon_currentheart_6.Image = My.Resources.icon_heart_4x4
        Icon_currentheart_7.Image = My.Resources.icon_heart_4x4
        Icon_currentheart_8.Image = My.Resources.icon_heart_4x4
        Icon_currentheart_9.Image = My.Resources.icon_heart_4x4
        Icon_currentheart_10.Image = My.Resources.icon_heart_4x4
        Icon_currentheart_11.Image = My.Resources.icon_heart_4x4
        Icon_currentheart_12.Image = My.Resources.icon_heart_4x4
        Icon_currentheart_13.Image = My.Resources.icon_heart_4x4
        Icon_currentheart_14.Image = My.Resources.icon_heart_4x4
        Icon_currentheart_15.Image = My.Resources.icon_heart_4x4
        Icon_currentheart_16.Image = My.Resources.icon_heart_0x4
        Icon_currentheart_17.Image = My.Resources.icon_heart_0x4
        Icon_currentheart_18.Image = My.Resources.icon_heart_0x4
        Icon_currentheart_19.Image = My.Resources.icon_heart_0x4
        Icon_currentheart_20.Image = My.Resources.icon_heart_0x4
    End Sub

    Private Sub Icon_currentheart_15_MouseLeave(sender As Object, e As EventArgs) Handles Icon_currentheart_15.MouseLeave
        Currentheart()
    End Sub

    Private Sub Icon_currentheart_15_Click(sender As Object, e As EventArgs) Handles Icon_currentheart_15.Click
        If valu_currenthearts.Value = 60 Then
            valu_currenthearts.Value = 57
        ElseIf valu_currenthearts.Value = 57 Then
            valu_currenthearts.Value = 58
        ElseIf valu_currenthearts.Value = 58 Then
            valu_currenthearts.Value = 59
        ElseIf valu_currenthearts.Value = 59 Then
            valu_currenthearts.Value = 60
        Else
            valu_currenthearts.Value = 60
        End If
    End Sub

    Private Sub Icon_currentheart_16_MouseMove(sender As Object, e As MouseEventArgs) Handles Icon_currentheart_16.MouseMove
        Icon_currentheart_1.Image = My.Resources.icon_heart_4x4
        Icon_currentheart_2.Image = My.Resources.icon_heart_4x4
        Icon_currentheart_3.Image = My.Resources.icon_heart_4x4
        Icon_currentheart_4.Image = My.Resources.icon_heart_4x4
        Icon_currentheart_5.Image = My.Resources.icon_heart_4x4
        Icon_currentheart_6.Image = My.Resources.icon_heart_4x4
        Icon_currentheart_7.Image = My.Resources.icon_heart_4x4
        Icon_currentheart_8.Image = My.Resources.icon_heart_4x4
        Icon_currentheart_9.Image = My.Resources.icon_heart_4x4
        Icon_currentheart_10.Image = My.Resources.icon_heart_4x4
        Icon_currentheart_11.Image = My.Resources.icon_heart_4x4
        Icon_currentheart_12.Image = My.Resources.icon_heart_4x4
        Icon_currentheart_13.Image = My.Resources.icon_heart_4x4
        Icon_currentheart_14.Image = My.Resources.icon_heart_4x4
        Icon_currentheart_15.Image = My.Resources.icon_heart_4x4
        Icon_currentheart_16.Image = My.Resources.icon_heart_4x4
        Icon_currentheart_17.Image = My.Resources.icon_heart_0x4
        Icon_currentheart_18.Image = My.Resources.icon_heart_0x4
        Icon_currentheart_19.Image = My.Resources.icon_heart_0x4
        Icon_currentheart_20.Image = My.Resources.icon_heart_0x4
    End Sub

    Private Sub Icon_currentheart_16_MouseLeave(sender As Object, e As EventArgs) Handles Icon_currentheart_16.MouseLeave
        Currentheart()
    End Sub

    Private Sub Icon_currentheart_16_Click(sender As Object, e As EventArgs) Handles Icon_currentheart_16.Click
        If valu_currenthearts.Value = 64 Then
            valu_currenthearts.Value = 61
        ElseIf valu_currenthearts.Value = 61 Then
            valu_currenthearts.Value = 62
        ElseIf valu_currenthearts.Value = 62 Then
            valu_currenthearts.Value = 63
        ElseIf valu_currenthearts.Value = 63 Then
            valu_currenthearts.Value = 64
        Else
            valu_currenthearts.Value = 64
        End If
    End Sub

    Private Sub Icon_currentheart_17_MouseMove(sender As Object, e As MouseEventArgs) Handles Icon_currentheart_17.MouseMove
        Icon_currentheart_1.Image = My.Resources.icon_heart_4x4
        Icon_currentheart_2.Image = My.Resources.icon_heart_4x4
        Icon_currentheart_3.Image = My.Resources.icon_heart_4x4
        Icon_currentheart_4.Image = My.Resources.icon_heart_4x4
        Icon_currentheart_5.Image = My.Resources.icon_heart_4x4
        Icon_currentheart_6.Image = My.Resources.icon_heart_4x4
        Icon_currentheart_7.Image = My.Resources.icon_heart_4x4
        Icon_currentheart_8.Image = My.Resources.icon_heart_4x4
        Icon_currentheart_9.Image = My.Resources.icon_heart_4x4
        Icon_currentheart_10.Image = My.Resources.icon_heart_4x4
        Icon_currentheart_11.Image = My.Resources.icon_heart_4x4
        Icon_currentheart_12.Image = My.Resources.icon_heart_4x4
        Icon_currentheart_13.Image = My.Resources.icon_heart_4x4
        Icon_currentheart_14.Image = My.Resources.icon_heart_4x4
        Icon_currentheart_15.Image = My.Resources.icon_heart_4x4
        Icon_currentheart_16.Image = My.Resources.icon_heart_4x4
        Icon_currentheart_17.Image = My.Resources.icon_heart_4x4
        Icon_currentheart_18.Image = My.Resources.icon_heart_0x4
        Icon_currentheart_19.Image = My.Resources.icon_heart_0x4
        Icon_currentheart_20.Image = My.Resources.icon_heart_0x4
    End Sub

    Private Sub Icon_currentheart_17_MouseLeave(sender As Object, e As EventArgs) Handles Icon_currentheart_17.MouseLeave
        Currentheart()
    End Sub

    Private Sub Icon_currentheart_17_Click(sender As Object, e As EventArgs) Handles Icon_currentheart_17.Click
        If valu_currenthearts.Value = 68 Then
            valu_currenthearts.Value = 65
        ElseIf valu_currenthearts.Value = 65 Then
            valu_currenthearts.Value = 66
        ElseIf valu_currenthearts.Value = 66 Then
            valu_currenthearts.Value = 67
        ElseIf valu_currenthearts.Value = 67 Then
            valu_currenthearts.Value = 68
        Else
            valu_currenthearts.Value = 68
        End If
    End Sub

    Private Sub Icon_currentheart_18_MouseMove(sender As Object, e As MouseEventArgs) Handles Icon_currentheart_18.MouseMove
        Icon_currentheart_1.Image = My.Resources.icon_heart_4x4
        Icon_currentheart_2.Image = My.Resources.icon_heart_4x4
        Icon_currentheart_3.Image = My.Resources.icon_heart_4x4
        Icon_currentheart_4.Image = My.Resources.icon_heart_4x4
        Icon_currentheart_5.Image = My.Resources.icon_heart_4x4
        Icon_currentheart_6.Image = My.Resources.icon_heart_4x4
        Icon_currentheart_7.Image = My.Resources.icon_heart_4x4
        Icon_currentheart_8.Image = My.Resources.icon_heart_4x4
        Icon_currentheart_9.Image = My.Resources.icon_heart_4x4
        Icon_currentheart_10.Image = My.Resources.icon_heart_4x4
        Icon_currentheart_11.Image = My.Resources.icon_heart_4x4
        Icon_currentheart_12.Image = My.Resources.icon_heart_4x4
        Icon_currentheart_13.Image = My.Resources.icon_heart_4x4
        Icon_currentheart_14.Image = My.Resources.icon_heart_4x4
        Icon_currentheart_15.Image = My.Resources.icon_heart_4x4
        Icon_currentheart_16.Image = My.Resources.icon_heart_4x4
        Icon_currentheart_17.Image = My.Resources.icon_heart_4x4
        Icon_currentheart_18.Image = My.Resources.icon_heart_4x4
        Icon_currentheart_19.Image = My.Resources.icon_heart_0x4
        Icon_currentheart_20.Image = My.Resources.icon_heart_0x4
    End Sub

    Private Sub Icon_currentheart_18_MouseLeave(sender As Object, e As EventArgs) Handles Icon_currentheart_18.MouseLeave
        Currentheart()
    End Sub

    Private Sub Icon_currentheart_18_Click(sender As Object, e As EventArgs) Handles Icon_currentheart_18.Click
        If valu_currenthearts.Value = 72 Then
            valu_currenthearts.Value = 69
        ElseIf valu_currenthearts.Value = 69 Then
            valu_currenthearts.Value = 70
        ElseIf valu_currenthearts.Value = 70 Then
            valu_currenthearts.Value = 71
        ElseIf valu_currenthearts.Value = 71 Then
            valu_currenthearts.Value = 72
        Else
            valu_currenthearts.Value = 72
        End If
    End Sub

    Private Sub Icon_currentheart_19_MouseMove(sender As Object, e As MouseEventArgs) Handles Icon_currentheart_19.MouseMove
        Icon_currentheart_1.Image = My.Resources.icon_heart_4x4
        Icon_currentheart_2.Image = My.Resources.icon_heart_4x4
        Icon_currentheart_3.Image = My.Resources.icon_heart_4x4
        Icon_currentheart_4.Image = My.Resources.icon_heart_4x4
        Icon_currentheart_5.Image = My.Resources.icon_heart_4x4
        Icon_currentheart_6.Image = My.Resources.icon_heart_4x4
        Icon_currentheart_7.Image = My.Resources.icon_heart_4x4
        Icon_currentheart_8.Image = My.Resources.icon_heart_4x4
        Icon_currentheart_9.Image = My.Resources.icon_heart_4x4
        Icon_currentheart_10.Image = My.Resources.icon_heart_4x4
        Icon_currentheart_11.Image = My.Resources.icon_heart_4x4
        Icon_currentheart_12.Image = My.Resources.icon_heart_4x4
        Icon_currentheart_13.Image = My.Resources.icon_heart_4x4
        Icon_currentheart_14.Image = My.Resources.icon_heart_4x4
        Icon_currentheart_15.Image = My.Resources.icon_heart_4x4
        Icon_currentheart_16.Image = My.Resources.icon_heart_4x4
        Icon_currentheart_17.Image = My.Resources.icon_heart_4x4
        Icon_currentheart_18.Image = My.Resources.icon_heart_4x4
        Icon_currentheart_19.Image = My.Resources.icon_heart_4x4
        Icon_currentheart_20.Image = My.Resources.icon_heart_0x4
    End Sub

    Private Sub Icon_currentheart_19_MouseLeave(sender As Object, e As EventArgs) Handles Icon_currentheart_19.MouseLeave
        Currentheart()
    End Sub

    Private Sub Icon_currentheart_19_Click(sender As Object, e As EventArgs) Handles Icon_currentheart_19.Click
        If valu_currenthearts.Value = 76 Then
            valu_currenthearts.Value = 73
        ElseIf valu_currenthearts.Value = 73 Then
            valu_currenthearts.Value = 74
        ElseIf valu_currenthearts.Value = 74 Then
            valu_currenthearts.Value = 75
        ElseIf valu_currenthearts.Value = 75 Then
            valu_currenthearts.Value = 76
        Else
            valu_currenthearts.Value = 76
        End If
    End Sub

    Private Sub Icon_currentheart_20_MouseMove(sender As Object, e As MouseEventArgs) Handles Icon_currentheart_20.MouseMove
        Icon_currentheart_1.Image = My.Resources.icon_heart_4x4
        Icon_currentheart_2.Image = My.Resources.icon_heart_4x4
        Icon_currentheart_3.Image = My.Resources.icon_heart_4x4
        Icon_currentheart_4.Image = My.Resources.icon_heart_4x4
        Icon_currentheart_5.Image = My.Resources.icon_heart_4x4
        Icon_currentheart_6.Image = My.Resources.icon_heart_4x4
        Icon_currentheart_7.Image = My.Resources.icon_heart_4x4
        Icon_currentheart_8.Image = My.Resources.icon_heart_4x4
        Icon_currentheart_9.Image = My.Resources.icon_heart_4x4
        Icon_currentheart_10.Image = My.Resources.icon_heart_4x4
        Icon_currentheart_11.Image = My.Resources.icon_heart_4x4
        Icon_currentheart_12.Image = My.Resources.icon_heart_4x4
        Icon_currentheart_13.Image = My.Resources.icon_heart_4x4
        Icon_currentheart_14.Image = My.Resources.icon_heart_4x4
        Icon_currentheart_15.Image = My.Resources.icon_heart_4x4
        Icon_currentheart_16.Image = My.Resources.icon_heart_4x4
        Icon_currentheart_17.Image = My.Resources.icon_heart_4x4
        Icon_currentheart_18.Image = My.Resources.icon_heart_4x4
        Icon_currentheart_19.Image = My.Resources.icon_heart_4x4
        Icon_currentheart_20.Image = My.Resources.icon_heart_4x4
    End Sub

    Private Sub Icon_currentheart_20_MouseLeave(sender As Object, e As EventArgs) Handles Icon_currentheart_20.MouseLeave
        Currentheart()
    End Sub

    Private Sub Icon_currentheart_20_Click(sender As Object, e As EventArgs) Handles Icon_currentheart_20.Click
        If valu_currenthearts.Value = 80 Then
            valu_currenthearts.Value = 77
        ElseIf valu_currenthearts.Value = 77 Then
            valu_currenthearts.Value = 78
        ElseIf valu_currenthearts.Value = 78 Then
            valu_currenthearts.Value = 79
        ElseIf valu_currenthearts.Value = 79 Then
            valu_currenthearts.Value = 80
        Else
            valu_currenthearts.Value = 80
        End If
    End Sub

    Private Sub Menu_text_linkstatus_MouseMove(sender As Object, e As MouseEventArgs) Handles Menu_text_linkstatus.MouseMove
        Menu_linkstatus.BackgroundImage = My.Resources.bg_menuitems_on
    End Sub

    Private Sub Menu_text_linkstatus_MouseLeave(sender As Object, e As EventArgs) Handles Menu_text_linkstatus.MouseLeave
        If Panel_linkstatus.Visible = True Then
            Menu_linkstatus.BackgroundImage = My.Resources.bg_menuitems_on
        Else
            Menu_linkstatus.BackgroundImage = My.Resources.bg_menuitems_off
        End If
    End Sub

    Private Sub Menu_text_linkstatus_Click(sender As Object, e As EventArgs) Handles Menu_text_linkstatus.Click
        Hidemenu()
        Menu_linkstatus.BackgroundImage = My.Resources.bg_menuitems_on
        Hidepanel()
        Panel_linkstatus.Visible = True
    End Sub

    Private Sub Menu_text_inventory_MouseMove(sender As Object, e As MouseEventArgs) Handles Menu_text_inventory.MouseMove
        Menu_inventory.BackgroundImage = My.Resources.bg_menuitems_on
    End Sub

    Private Sub Menu_text_inventory_MouseLeave(sender As Object, e As EventArgs) Handles Menu_text_inventory.MouseLeave
        If Panel_inventory.Visible = True Then
            Menu_inventory.BackgroundImage = My.Resources.bg_menuitems_on
        Else
            Menu_inventory.BackgroundImage = My.Resources.bg_menuitems_off
        End If
    End Sub

    Private Sub Menu_text_inventory_Click(sender As Object, e As EventArgs) Handles Menu_text_inventory.Click
        Hidemenu()
        Menu_inventory.BackgroundImage = My.Resources.bg_menuitems_on
        Hidepanel()
        Panel_inventory.Visible = True
    End Sub

    Private Sub valu_actualworld_ValueChanged(sender As Object, e As EventArgs) Handles valu_actualworld.ValueChanged
        If valu_actualworld.Value = 0 Then
            Select_actualworld.SelectedItem = Select_actualworld.Items.Item(0)
        End If
        If valu_actualworld.Value = 1 Then
            Select_actualworld.SelectedItem = Select_actualworld.Items.Item(1)
        End If
    End Sub

    Private Sub Select_actualworld_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Select_actualworld.SelectedIndexChanged
        If Select_actualworld.SelectedItem = Select_actualworld.Items.Item(0) Then
            valu_actualworld.Value = 0
        End If
        If Select_actualworld.SelectedItem = Select_actualworld.Items.Item(1) Then
            valu_actualworld.Value = 1
        End If
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Select_actualworld.SelectedItem = Select_actualworld.Items.Item(0)
    End Sub

    Private Sub Icon_rupee_Click(sender As Object, e As EventArgs) Handles Icon_rupee.Click
        valu_ruppe.Value = 9999
    End Sub

    Private Sub Icon_lostmaiamai_Click(sender As Object, e As EventArgs) Handles Icon_lostmaiamai.Click
        valu_lostmaiamai.Value = 100
    End Sub

    Private Sub Icon_monstertail_Click(sender As Object, e As EventArgs) Handles Icon_monstertail.Click
        valu_monstertail.Value = 99
    End Sub

    Private Sub Icon_monsterhorn_Click(sender As Object, e As EventArgs) Handles Icon_monsterhorn.Click
        valu_monsterhorn.Value = 99
    End Sub

    Private Sub Icon_monstergust_Click(sender As Object, e As EventArgs) Handles Icon_monstergust.Click
        valu_monstergust.Value = 99
    End Sub

    Private Sub valu_bombs_ValueChanged(sender As Object, e As EventArgs) Handles valu_bombs.ValueChanged
        If valu_bombs.Value = 0 Then
            Icon_bombs.Image = My.Resources.icon_bombs_unavailable
        End If
        If valu_bombs.Value = 1 Then
            Icon_bombs.Image = My.Resources.icon_bombs_rented
        End If
        If valu_bombs.Value = 2 Then
            Icon_bombs.Image = My.Resources.icon_bombs
        End If
        If valu_bombs.Value = 3 Then
            Icon_bombs.Image = My.Resources.icon_bombs_nice
        End If
    End Sub

    Private Sub valu_boomerang_ValueChanged(sender As Object, e As EventArgs) Handles valu_boomerang.ValueChanged
        If valu_boomerang.Value = 0 Then
            Icon_boomerang.Image = My.Resources.icon_boomerang_unavailable
        End If
        If valu_boomerang.Value = 1 Then
            Icon_boomerang.Image = My.Resources.icon_boomerang_rented
        End If
        If valu_boomerang.Value = 2 Then
            Icon_boomerang.Image = My.Resources.icon_boomerang
        End If
        If valu_boomerang.Value = 3 Then
            Icon_boomerang.Image = My.Resources.icon_boomerang_nice
        End If
    End Sub

    Private Sub valu_bow_ValueChanged(sender As Object, e As EventArgs) Handles valu_bow.ValueChanged
        If valu_bow.Value = 0 Then
            Icon_bow.Image = My.Resources.icon_bow_unavailable
        End If
        If valu_bow.Value = 1 Then
            Icon_bow.Image = My.Resources.icon_bow_rented
        End If
        If valu_bow.Value = 2 Then
            Icon_bow.Image = My.Resources.icon_bow
        End If
        If valu_bow.Value = 3 Then
            Icon_bow.Image = My.Resources.icon_bow_nice
        End If
    End Sub

    Private Sub valu_bowoflight_ValueChanged(sender As Object, e As EventArgs) Handles valu_bowoflight.ValueChanged
        If valu_bowoflight.Value = 0 Then
            Icon_bowoflight.Image = My.Resources.icon_bowoflight_unavailable
        End If
        If valu_bowoflight.Value = 1 Then
            Icon_bowoflight.Image = My.Resources.icon_unusword
        End If
        If valu_bowoflight.Value = 2 Then
            Icon_bowoflight.Image = My.Resources.icon_bowoflight
        End If
        If valu_bowoflight.Value = 3 Then
            Icon_bowoflight.Image = My.Resources.icon_unusword
        End If
    End Sub

    Private Sub valu_hammer_ValueChanged(sender As Object, e As EventArgs) Handles valu_hammer.ValueChanged
        If valu_hammer.Value = 0 Then
            Icon_hammer.Image = My.Resources.icon_hammer_unavailable
        End If
        If valu_hammer.Value = 1 Then
            Icon_hammer.Image = My.Resources.icon_hammer_rented
        End If
        If valu_hammer.Value = 2 Then
            Icon_hammer.Image = My.Resources.icon_hammer
        End If
        If valu_hammer.Value = 3 Then
            Icon_hammer.Image = My.Resources.icon_hammer_nice
        End If
    End Sub

    Private Sub valu_sandrod_ValueChanged(sender As Object, e As EventArgs) Handles valu_sandrod.ValueChanged
        If valu_sandrod.Value = 0 Then
            Icon_sandrod.Image = My.Resources.icon_sandrod_unavailable
        End If
        If valu_sandrod.Value = 1 Then
            Icon_sandrod.Image = My.Resources.icon_sandrod_rented
        End If
        If valu_sandrod.Value = 2 Then
            Icon_sandrod.Image = My.Resources.icon_sandrod
        End If
        If valu_sandrod.Value = 3 Then
            Icon_sandrod.Image = My.Resources.icon_sandrod_nice
        End If
    End Sub

    Private Sub valu_firerod_ValueChanged(sender As Object, e As EventArgs) Handles valu_firerod.ValueChanged
        If valu_firerod.Value = 0 Then
            Icon_firerod.Image = My.Resources.icon_firerod_unavailable
        End If
        If valu_firerod.Value = 1 Then
            Icon_firerod.Image = My.Resources.icon_firerod_rented
        End If
        If valu_firerod.Value = 2 Then
            Icon_firerod.Image = My.Resources.icon_firerod
        End If
        If valu_firerod.Value = 3 Then
            Icon_firerod.Image = My.Resources.icon_firerod_nice
        End If
    End Sub

    Private Sub valu_icerod_ValueChanged(sender As Object, e As EventArgs) Handles valu_icerod.ValueChanged
        If valu_icerod.Value = 0 Then
            Icon_icerod.Image = My.Resources.icon_icerod_unavailable
        End If
        If valu_icerod.Value = 1 Then
            Icon_icerod.Image = My.Resources.icon_icerod_rented
        End If
        If valu_icerod.Value = 2 Then
            Icon_icerod.Image = My.Resources.icon_icerod
        End If
        If valu_icerod.Value = 3 Then
            Icon_icerod.Image = My.Resources.icon_icerod_nice
        End If
    End Sub

    Private Sub valu_tornadorod_ValueChanged(sender As Object, e As EventArgs) Handles valu_tornadorod.ValueChanged
        If valu_tornadorod.Value = 0 Then
            Icon_tornadorod.Image = My.Resources.icon_tornadorod_unavailable
        End If
        If valu_tornadorod.Value = 1 Then
            Icon_tornadorod.Image = My.Resources.icon_tornadorod_rented
        End If
        If valu_tornadorod.Value = 2 Then
            Icon_tornadorod.Image = My.Resources.icon_tornadorod
        End If
        If valu_tornadorod.Value = 3 Then
            Icon_tornadorod.Image = My.Resources.icon_tornadorod_nice
        End If
    End Sub

    Private Sub valu_hookshot_ValueChanged(sender As Object, e As EventArgs) Handles valu_hookshot.ValueChanged
        If valu_hookshot.Value = 0 Then
            Icon_hookshot.Image = My.Resources.icon_hookshot_unavailable
        End If
        If valu_hookshot.Value = 1 Then
            Icon_hookshot.Image = My.Resources.icon_hookshot_rented
        End If
        If valu_hookshot.Value = 2 Then
            Icon_hookshot.Image = My.Resources.icon_hookshot
        End If
        If valu_hookshot.Value = 3 Then
            Icon_hookshot.Image = My.Resources.icon_hookshot_nice
        End If
    End Sub

    Private Sub valu_lamp_ValueChanged(sender As Object, e As EventArgs) Handles valu_lamp.ValueChanged
        If valu_lamp.Value = 0 Then
            Icon_lamp.Image = My.Resources.icon_lamp_unavailable
        End If
        If valu_lamp.Value = 1 Then
            Icon_lamp.Image = My.Resources.icon_unusword
        End If
        If valu_lamp.Value = 2 Then
            Icon_lamp.Image = My.Resources.icon_lamp
        End If
        If valu_lamp.Value = 3 Then
            Icon_lamp.Image = My.Resources.icon_lamp_nice
        End If
    End Sub

    Private Sub valu_net_ValueChanged(sender As Object, e As EventArgs) Handles valu_net.ValueChanged
        If valu_net.Value = 0 Then
            Icon_net.Image = My.Resources.icon_net_unavailable
        End If
        If valu_net.Value = 1 Then
            Icon_net.Image = My.Resources.icon_unusword
        End If
        If valu_net.Value = 2 Then
            Icon_net.Image = My.Resources.icon_net
        End If
        If valu_net.Value = 3 Then
            Icon_net.Image = My.Resources.icon_net_nice
        End If
    End Sub

    Private Sub valu_hintglasses_ValueChanged(sender As Object, e As EventArgs) Handles valu_hintglasses.ValueChanged
        If valu_hintglasses.Value = 0 Then
            Icon_hintglasses.Image = My.Resources.icon_hintglasses_unavailable
        End If
        If valu_hintglasses.Value = 1 Then
            Icon_hintglasses.Image = My.Resources.icon_unusword
        End If
        If valu_hintglasses.Value = 2 Then
            Icon_hintglasses.Image = My.Resources.icon_hintglasses
        End If
        If valu_hintglasses.Value = 3 Then
            Icon_hintglasses.Image = My.Resources.icon_unusword
        End If
    End Sub

    Private Sub valu_scootfruit_ValueChanged(sender As Object, e As EventArgs) Handles valu_scootfruit.ValueChanged
        If valu_scootfruit.Value = 0 Then
            Icon_scootfruit.Image = My.Resources.icon_scootfruit_unavailable
        End If
        If valu_scootfruit.Value = 1 Then
            Icon_scootfruit.Image = My.Resources.icon_unusword
        End If
        If valu_scootfruit.Value = 2 Then
            Icon_scootfruit.Image = My.Resources.icon_scootfruit
        End If
        If valu_scootfruit.Value = 3 Then
            Icon_scootfruit.Image = My.Resources.icon_unusword
        End If
    End Sub

    Private Sub valu_foulfruit_ValueChanged(sender As Object, e As EventArgs) Handles valu_foulfruit.ValueChanged
        If valu_foulfruit.Value = 0 Then
            Icon_foulfruit.Image = My.Resources.icon_foulfruit_unavailable
        End If
        If valu_foulfruit.Value = 1 Then
            Icon_foulfruit.Image = My.Resources.icon_unusword
        End If
        If valu_foulfruit.Value = 2 Then
            Icon_foulfruit.Image = My.Resources.icon_foulfruit
        End If
        If valu_foulfruit.Value = 3 Then
            Icon_foulfruit.Image = My.Resources.icon_unusword
        End If
    End Sub

    Private Sub valu_bottle1_ValueChanged(sender As Object, e As EventArgs) Handles valu_bottle1.ValueChanged
        If valu_bottle1.Value = 0 Then
            Icon_bottle1.Image = My.Resources.icon_bottles_unavailable
            Icon_bottleitem_1.Visible = False
        End If
        If valu_bottle1.Value = 1 Then
            Icon_bottle1.Image = My.Resources.icon_unusword
            Icon_bottleitem_1.Visible = True
        End If
        If valu_bottle1.Value = 2 Then
            Icon_bottle1.Image = My.Resources.icon_bottles
            Icon_bottleitem_1.Visible = True
        End If
        If valu_bottle1.Value = 3 Then
            Icon_bottle1.Image = My.Resources.icon_unusword
            Icon_bottleitem_1.Visible = True
        End If
    End Sub

    Private Sub valu_bottle2_ValueChanged(sender As Object, e As EventArgs) Handles valu_bottle2.ValueChanged
        If valu_bottle2.Value = 0 Then
            Icon_bottle2.Image = My.Resources.icon_bottles_unavailable
            Icon_bottleitem_2.Visible = False
        End If
        If valu_bottle2.Value = 1 Then
            Icon_bottle2.Image = My.Resources.icon_unusword
            Icon_bottleitem_2.Visible = True
        End If
        If valu_bottle2.Value = 2 Then
            Icon_bottle2.Image = My.Resources.icon_bottles
            Icon_bottleitem_2.Visible = True
        End If
        If valu_bottle2.Value = 3 Then
            Icon_bottle2.Image = My.Resources.icon_unusword
            Icon_bottleitem_2.Visible = True
        End If
    End Sub

    Private Sub valu_bottle3_ValueChanged(sender As Object, e As EventArgs) Handles valu_bottle3.ValueChanged
        If valu_bottle3.Value = 0 Then
            Icon_bottle3.Image = My.Resources.icon_bottles_unavailable
            Icon_bottleitem_3.Visible = False
        End If
        If valu_bottle3.Value = 1 Then
            Icon_bottle3.Image = My.Resources.icon_unusword
            Icon_bottleitem_3.Visible = True
        End If
        If valu_bottle3.Value = 2 Then
            Icon_bottle3.Image = My.Resources.icon_bottles
            Icon_bottleitem_3.Visible = True
        End If
        If valu_bottle3.Value = 3 Then
            Icon_bottle3.Image = My.Resources.icon_unusword
            Icon_bottleitem_3.Visible = True
        End If
    End Sub

    Private Sub valu_bottle4_ValueChanged(sender As Object, e As EventArgs) Handles valu_bottle4.ValueChanged
        If valu_bottle4.Value = 0 Then
            Icon_bottle4.Image = My.Resources.icon_bottles_unavailable
            Icon_bottleitem_4.Visible = False
        End If
        If valu_bottle4.Value = 1 Then
            Icon_bottle4.Image = My.Resources.icon_unusword
            Icon_bottleitem_4.Visible = True
        End If
        If valu_bottle4.Value = 2 Then
            Icon_bottle4.Image = My.Resources.icon_bottles
            Icon_bottleitem_4.Visible = True
        End If
        If valu_bottle4.Value = 3 Then
            Icon_bottle4.Image = My.Resources.icon_unusword
            Icon_bottleitem_4.Visible = True
        End If
    End Sub

    Private Sub valu_bottle5_ValueChanged(sender As Object, e As EventArgs) Handles valu_bottle5.ValueChanged
        If valu_bottle5.Value = 0 Then
            Icon_bottle5.Image = My.Resources.icon_bottles_unavailable
            Icon_bottleitem_5.Visible = False
        End If
        If valu_bottle5.Value = 1 Then
            Icon_bottle5.Image = My.Resources.icon_unusword
            Icon_bottleitem_5.Visible = True
        End If
        If valu_bottle5.Value = 2 Then
            Icon_bottle5.Image = My.Resources.icon_bottles
            Icon_bottleitem_5.Visible = True
        End If
        If valu_bottle5.Value = 3 Then
            Icon_bottle5.Image = My.Resources.icon_unusword
            Icon_bottleitem_5.Visible = True
        End If
    End Sub

    Private Sub valu_bottleitem_1_ValueChanged(sender As Object, e As EventArgs) Handles valu_bottleitem_1.ValueChanged
        If valu_bottleitem_1.Value = 0 Then
            Icon_bottleitem_1.Image = My.Resources.bottle_empty
        End If
        If valu_bottleitem_1.Value = 1 Then
            Icon_bottleitem_1.Image = My.Resources.bottle_redpotion
        End If
        If valu_bottleitem_1.Value = 2 Then
            Icon_bottleitem_1.Image = My.Resources.bottle_bluepotion
        End If
        If valu_bottleitem_1.Value = 3 Then
            Icon_bottleitem_1.Image = My.Resources.bottle_purplepotion
        End If
        If valu_bottleitem_1.Value = 4 Then
            Icon_bottleitem_1.Image = My.Resources.bottle_yellowpotion
        End If
        If valu_bottleitem_1.Value = 5 Then
            Icon_bottleitem_1.Image = My.Resources.bottle_fairy
        End If
        If valu_bottleitem_1.Value = 6 Then
            Icon_bottleitem_1.Image = My.Resources.bottle_bee
        End If
        If valu_bottleitem_1.Value = 7 Then
            Icon_bottleitem_1.Image = My.Resources.bottle_goldenbee
        End If
        If valu_bottleitem_1.Value = 8 Then
            Icon_bottleitem_1.Image = My.Resources.bottle_heart
        End If
        If valu_bottleitem_1.Value = 9 Then
            Icon_bottleitem_1.Image = My.Resources.bottle_apple
        End If
        If valu_bottleitem_1.Value = 10 Then
            Icon_bottleitem_1.Image = My.Resources.bottle_greenapple
        End If
        If valu_bottleitem_1.Value = 11 Then
            Icon_bottleitem_1.Image = My.Resources.bottle_letter
        End If
        If valu_bottleitem_1.Value = 12 Then
            Icon_bottleitem_1.Image = My.Resources.bottle_milk
        End If
        If valu_bottleitem_1.Value = 13 Then
            Icon_bottleitem_1.Image = My.Resources.bottle_premiummilk
        End If
    End Sub

    Private Sub valu_bottleitem_2_ValueChanged(sender As Object, e As EventArgs) Handles valu_bottleitem_2.ValueChanged
        If valu_bottleitem_2.Value = 0 Then
            Icon_bottleitem_2.Image = My.Resources.bottle_empty
        End If
        If valu_bottleitem_2.Value = 1 Then
            Icon_bottleitem_2.Image = My.Resources.bottle_redpotion
        End If
        If valu_bottleitem_2.Value = 2 Then
            Icon_bottleitem_2.Image = My.Resources.bottle_bluepotion
        End If
        If valu_bottleitem_2.Value = 3 Then
            Icon_bottleitem_2.Image = My.Resources.bottle_purplepotion
        End If
        If valu_bottleitem_2.Value = 4 Then
            Icon_bottleitem_2.Image = My.Resources.bottle_yellowpotion
        End If
        If valu_bottleitem_2.Value = 5 Then
            Icon_bottleitem_2.Image = My.Resources.bottle_fairy
        End If
        If valu_bottleitem_2.Value = 6 Then
            Icon_bottleitem_2.Image = My.Resources.bottle_bee
        End If
        If valu_bottleitem_2.Value = 7 Then
            Icon_bottleitem_2.Image = My.Resources.bottle_goldenbee
        End If
        If valu_bottleitem_2.Value = 8 Then
            Icon_bottleitem_2.Image = My.Resources.bottle_heart
        End If
        If valu_bottleitem_2.Value = 9 Then
            Icon_bottleitem_2.Image = My.Resources.bottle_apple
        End If
        If valu_bottleitem_2.Value = 10 Then
            Icon_bottleitem_2.Image = My.Resources.bottle_greenapple
        End If
        If valu_bottleitem_2.Value = 11 Then
            Icon_bottleitem_2.Image = My.Resources.bottle_letter
        End If
        If valu_bottleitem_2.Value = 12 Then
            Icon_bottleitem_2.Image = My.Resources.bottle_milk
        End If
        If valu_bottleitem_2.Value = 13 Then
            Icon_bottleitem_2.Image = My.Resources.bottle_premiummilk
        End If
    End Sub

    Private Sub valu_bottleitem_3_ValueChanged(sender As Object, e As EventArgs) Handles valu_bottleitem_3.ValueChanged
        If valu_bottleitem_3.Value = 0 Then
            Icon_bottleitem_3.Image = My.Resources.bottle_empty
        End If
        If valu_bottleitem_3.Value = 1 Then
            Icon_bottleitem_3.Image = My.Resources.bottle_redpotion
        End If
        If valu_bottleitem_3.Value = 2 Then
            Icon_bottleitem_3.Image = My.Resources.bottle_bluepotion
        End If
        If valu_bottleitem_3.Value = 3 Then
            Icon_bottleitem_3.Image = My.Resources.bottle_purplepotion
        End If
        If valu_bottleitem_3.Value = 4 Then
            Icon_bottleitem_3.Image = My.Resources.bottle_yellowpotion
        End If
        If valu_bottleitem_3.Value = 5 Then
            Icon_bottleitem_3.Image = My.Resources.bottle_fairy
        End If
        If valu_bottleitem_3.Value = 6 Then
            Icon_bottleitem_3.Image = My.Resources.bottle_bee
        End If
        If valu_bottleitem_3.Value = 7 Then
            Icon_bottleitem_3.Image = My.Resources.bottle_goldenbee
        End If
        If valu_bottleitem_3.Value = 8 Then
            Icon_bottleitem_3.Image = My.Resources.bottle_heart
        End If
        If valu_bottleitem_3.Value = 9 Then
            Icon_bottleitem_3.Image = My.Resources.bottle_apple
        End If
        If valu_bottleitem_3.Value = 10 Then
            Icon_bottleitem_3.Image = My.Resources.bottle_greenapple
        End If
        If valu_bottleitem_3.Value = 11 Then
            Icon_bottleitem_3.Image = My.Resources.bottle_letter
        End If
        If valu_bottleitem_3.Value = 12 Then
            Icon_bottleitem_3.Image = My.Resources.bottle_milk
        End If
        If valu_bottleitem_3.Value = 13 Then
            Icon_bottleitem_3.Image = My.Resources.bottle_premiummilk
        End If
    End Sub

    Private Sub valu_bottleitem_4_ValueChanged(sender As Object, e As EventArgs) Handles valu_bottleitem_4.ValueChanged
        If valu_bottleitem_4.Value = 0 Then
            Icon_bottleitem_4.Image = My.Resources.bottle_empty
        End If
        If valu_bottleitem_4.Value = 1 Then
            Icon_bottleitem_4.Image = My.Resources.bottle_redpotion
        End If
        If valu_bottleitem_4.Value = 2 Then
            Icon_bottleitem_4.Image = My.Resources.bottle_bluepotion
        End If
        If valu_bottleitem_4.Value = 3 Then
            Icon_bottleitem_4.Image = My.Resources.bottle_purplepotion
        End If
        If valu_bottleitem_4.Value = 4 Then
            Icon_bottleitem_4.Image = My.Resources.bottle_yellowpotion
        End If
        If valu_bottleitem_4.Value = 5 Then
            Icon_bottleitem_4.Image = My.Resources.bottle_fairy
        End If
        If valu_bottleitem_4.Value = 6 Then
            Icon_bottleitem_4.Image = My.Resources.bottle_bee
        End If
        If valu_bottleitem_4.Value = 7 Then
            Icon_bottleitem_4.Image = My.Resources.bottle_goldenbee
        End If
        If valu_bottleitem_4.Value = 8 Then
            Icon_bottleitem_4.Image = My.Resources.bottle_heart
        End If
        If valu_bottleitem_4.Value = 9 Then
            Icon_bottleitem_4.Image = My.Resources.bottle_apple
        End If
        If valu_bottleitem_4.Value = 10 Then
            Icon_bottleitem_4.Image = My.Resources.bottle_greenapple
        End If
        If valu_bottleitem_4.Value = 11 Then
            Icon_bottleitem_4.Image = My.Resources.bottle_letter
        End If
        If valu_bottleitem_4.Value = 12 Then
            Icon_bottleitem_4.Image = My.Resources.bottle_milk
        End If
        If valu_bottleitem_4.Value = 13 Then
            Icon_bottleitem_4.Image = My.Resources.bottle_premiummilk
        End If
    End Sub

    Private Sub valu_bottleitem_5_ValueChanged(sender As Object, e As EventArgs) Handles valu_bottleitem_5.ValueChanged
        If valu_bottleitem_5.Value = 0 Then
            Icon_bottleitem_5.Image = My.Resources.bottle_empty
        End If
        If valu_bottleitem_5.Value = 1 Then
            Icon_bottleitem_5.Image = My.Resources.bottle_redpotion
        End If
        If valu_bottleitem_5.Value = 2 Then
            Icon_bottleitem_5.Image = My.Resources.bottle_bluepotion
        End If
        If valu_bottleitem_5.Value = 3 Then
            Icon_bottleitem_5.Image = My.Resources.bottle_purplepotion
        End If
        If valu_bottleitem_5.Value = 4 Then
            Icon_bottleitem_5.Image = My.Resources.bottle_yellowpotion
        End If
        If valu_bottleitem_5.Value = 5 Then
            Icon_bottleitem_5.Image = My.Resources.bottle_fairy
        End If
        If valu_bottleitem_5.Value = 6 Then
            Icon_bottleitem_5.Image = My.Resources.bottle_bee
        End If
        If valu_bottleitem_5.Value = 7 Then
            Icon_bottleitem_5.Image = My.Resources.bottle_goldenbee
        End If
        If valu_bottleitem_5.Value = 8 Then
            Icon_bottleitem_5.Image = My.Resources.bottle_heart
        End If
        If valu_bottleitem_5.Value = 9 Then
            Icon_bottleitem_5.Image = My.Resources.bottle_apple
        End If
        If valu_bottleitem_5.Value = 10 Then
            Icon_bottleitem_5.Image = My.Resources.bottle_greenapple
        End If
        If valu_bottleitem_5.Value = 11 Then
            Icon_bottleitem_5.Image = My.Resources.bottle_letter
        End If
        If valu_bottleitem_5.Value = 12 Then
            Icon_bottleitem_5.Image = My.Resources.bottle_milk
        End If
        If valu_bottleitem_5.Value = 13 Then
            Icon_bottleitem_5.Image = My.Resources.bottle_premiummilk
        End If
    End Sub

    Private Sub Icon_bombs_Click(sender As Object, e As EventArgs) Handles Icon_bombs.Click
        If valu_bombs.Value = 0 Then
            valu_bombs.Value = 1
        ElseIf valu_bombs.Value = 1 Then
            valu_bombs.Value = 2
        ElseIf valu_bombs.Value = 2 Then
            valu_bombs.Value = 3
        ElseIf valu_bombs.Value = 3 Then
            valu_bombs.Value = 0
        End If
    End Sub

    Private Sub Icon_boomerang_Click(sender As Object, e As EventArgs) Handles Icon_boomerang.Click
        If valu_boomerang.Value = 0 Then
            valu_boomerang.Value = 1
        ElseIf valu_boomerang.Value = 1 Then
            valu_boomerang.Value = 2
        ElseIf valu_boomerang.Value = 2 Then
            valu_boomerang.Value = 3
        ElseIf valu_boomerang.Value = 3 Then
            valu_boomerang.Value = 0
        End If
    End Sub

    Private Sub Icon_bow_Click(sender As Object, e As EventArgs) Handles Icon_bow.Click
        If valu_bow.Value = 0 Then
            valu_bow.Value = 1
        ElseIf valu_bow.Value = 1 Then
            valu_bow.Value = 2
        ElseIf valu_bow.Value = 2 Then
            valu_bow.Value = 3
        ElseIf valu_bow.Value = 3 Then
            valu_bow.Value = 0
        End If
    End Sub

    Private Sub Icon_bowoflight_Click(sender As Object, e As EventArgs) Handles Icon_bowoflight.Click
        If valu_bowoflight.Value = 0 Then
            valu_bowoflight.Value = 1
        ElseIf valu_bowoflight.Value = 1 Then
            valu_bowoflight.Value = 2
        ElseIf valu_bowoflight.Value = 2 Then
            valu_bowoflight.Value = 3
        ElseIf valu_bowoflight.Value = 3 Then
            valu_bowoflight.Value = 0
        End If
    End Sub

    Private Sub Icon_hammer_Click(sender As Object, e As EventArgs) Handles Icon_hammer.Click
        If valu_hammer.Value = 0 Then
            valu_hammer.Value = 1
        ElseIf valu_hammer.Value = 1 Then
            valu_hammer.Value = 2
        ElseIf valu_hammer.Value = 2 Then
            valu_hammer.Value = 3
        ElseIf valu_hammer.Value = 3 Then
            valu_hammer.Value = 0
        End If
    End Sub

    Private Sub Icon_sandrod_Click(sender As Object, e As EventArgs) Handles Icon_sandrod.Click
        If valu_sandrod.Value = 0 Then
            valu_sandrod.Value = 1
        ElseIf valu_sandrod.Value = 1 Then
            valu_sandrod.Value = 2
        ElseIf valu_sandrod.Value = 2 Then
            valu_sandrod.Value = 3
        ElseIf valu_sandrod.Value = 3 Then
            valu_sandrod.Value = 0
        End If
    End Sub

    Private Sub Icon_firerod_Click(sender As Object, e As EventArgs) Handles Icon_firerod.Click
        If valu_firerod.Value = 0 Then
            valu_firerod.Value = 1
        ElseIf valu_firerod.Value = 1 Then
            valu_firerod.Value = 2
        ElseIf valu_firerod.Value = 2 Then
            valu_firerod.Value = 3
        ElseIf valu_firerod.Value = 3 Then
            valu_firerod.Value = 0
        End If
    End Sub

    Private Sub Icon_icerod_Click(sender As Object, e As EventArgs) Handles Icon_icerod.Click
        If valu_icerod.Value = 0 Then
            valu_icerod.Value = 1
        ElseIf valu_icerod.Value = 1 Then
            valu_icerod.Value = 2
        ElseIf valu_icerod.Value = 2 Then
            valu_icerod.Value = 3
        ElseIf valu_icerod.Value = 3 Then
            valu_icerod.Value = 0
        End If
    End Sub

    Private Sub Icon_tornadorod_Click(sender As Object, e As EventArgs) Handles Icon_tornadorod.Click
        If valu_tornadorod.Value = 0 Then
            valu_tornadorod.Value = 1
        ElseIf valu_tornadorod.Value = 1 Then
            valu_tornadorod.Value = 2
        ElseIf valu_tornadorod.Value = 2 Then
            valu_tornadorod.Value = 3
        ElseIf valu_tornadorod.Value = 3 Then
            valu_tornadorod.Value = 0
        End If
    End Sub

    Private Sub Icon_hookshot_Click(sender As Object, e As EventArgs) Handles Icon_hookshot.Click
        If valu_hookshot.Value = 0 Then
            valu_hookshot.Value = 1
        ElseIf valu_hookshot.Value = 1 Then
            valu_hookshot.Value = 2
        ElseIf valu_hookshot.Value = 2 Then
            valu_hookshot.Value = 3
        ElseIf valu_hookshot.Value = 3 Then
            valu_hookshot.Value = 0
        End If
    End Sub

    Private Sub Icon_lamp_Click(sender As Object, e As EventArgs) Handles Icon_lamp.Click
        If valu_lamp.Value = 0 Then
            valu_lamp.Value = 1
        ElseIf valu_lamp.Value = 1 Then
            valu_lamp.Value = 2
        ElseIf valu_lamp.Value = 2 Then
            valu_lamp.Value = 3
        ElseIf valu_lamp.Value = 3 Then
            valu_lamp.Value = 0
        End If
    End Sub

    Private Sub Icon_net_Click(sender As Object, e As EventArgs) Handles Icon_net.Click
        If valu_net.Value = 0 Then
            valu_net.Value = 1
        ElseIf valu_net.Value = 1 Then
            valu_net.Value = 2
        ElseIf valu_net.Value = 2 Then
            valu_net.Value = 3
        ElseIf valu_net.Value = 3 Then
            valu_net.Value = 0
        End If
    End Sub

    Private Sub Icon_hintglasses_Click(sender As Object, e As EventArgs) Handles Icon_hintglasses.Click
        If valu_hintglasses.Value = 0 Then
            valu_hintglasses.Value = 1
        ElseIf valu_hintglasses.Value = 1 Then
            valu_hintglasses.Value = 2
        ElseIf valu_hintglasses.Value = 2 Then
            valu_hintglasses.Value = 3
        ElseIf valu_hintglasses.Value = 3 Then
            valu_hintglasses.Value = 0
        End If
    End Sub

    Private Sub Icon_scootfruit_Click(sender As Object, e As EventArgs) Handles Icon_scootfruit.Click
        If valu_scootfruit.Value = 0 Then
            valu_scootfruit.Value = 1
        ElseIf valu_scootfruit.Value = 1 Then
            valu_scootfruit.Value = 2
        ElseIf valu_scootfruit.Value = 2 Then
            valu_scootfruit.Value = 3
        ElseIf valu_scootfruit.Value = 3 Then
            valu_scootfruit.Value = 0
        End If
    End Sub

    Private Sub Icon_foulfruit_Click(sender As Object, e As EventArgs) Handles Icon_foulfruit.Click
        If valu_foulfruit.Value = 0 Then
            valu_foulfruit.Value = 1
        ElseIf valu_foulfruit.Value = 1 Then
            valu_foulfruit.Value = 2
        ElseIf valu_foulfruit.Value = 2 Then
            valu_foulfruit.Value = 3
        ElseIf valu_foulfruit.Value = 3 Then
            valu_foulfruit.Value = 0
        End If
    End Sub

    Private Sub Icon_bottle1_Click(sender As Object, e As EventArgs) Handles Icon_bottle1.Click
        If valu_bottle1.Value = 0 Then
            valu_bottle1.Value = 1
        ElseIf valu_bottle1.Value = 1 Then
            valu_bottle1.Value = 2
        ElseIf valu_bottle1.Value = 2 Then
            valu_bottle1.Value = 3
        ElseIf valu_bottle1.Value = 3 Then
            valu_bottle1.Value = 0
        End If
    End Sub

    Private Sub Icon_bottle2_Click(sender As Object, e As EventArgs) Handles Icon_bottle2.Click
        If valu_bottle2.Value = 0 Then
            valu_bottle2.Value = 1
        ElseIf valu_bottle2.Value = 1 Then
            valu_bottle2.Value = 2
        ElseIf valu_bottle2.Value = 2 Then
            valu_bottle2.Value = 3
        ElseIf valu_bottle2.Value = 3 Then
            valu_bottle2.Value = 0
        End If
    End Sub

    Private Sub Icon_bottle3_Click(sender As Object, e As EventArgs) Handles Icon_bottle3.Click
        If valu_bottle3.Value = 0 Then
            valu_bottle3.Value = 1
        ElseIf valu_bottle3.Value = 1 Then
            valu_bottle3.Value = 2
        ElseIf valu_bottle3.Value = 2 Then
            valu_bottle3.Value = 3
        ElseIf valu_bottle3.Value = 3 Then
            valu_bottle3.Value = 0
        End If
    End Sub

    Private Sub Icon_bottle4_Click(sender As Object, e As EventArgs) Handles Icon_bottle4.Click
        If valu_bottle4.Value = 0 Then
            valu_bottle4.Value = 1
        ElseIf valu_bottle4.Value = 1 Then
            valu_bottle4.Value = 2
        ElseIf valu_bottle4.Value = 2 Then
            valu_bottle4.Value = 3
        ElseIf valu_bottle4.Value = 3 Then
            valu_bottle4.Value = 0
        End If
    End Sub

    Private Sub Icon_bottle5_Click(sender As Object, e As EventArgs) Handles Icon_bottle5.Click
        If valu_bottle5.Value = 0 Then
            valu_bottle5.Value = 1
        ElseIf valu_bottle5.Value = 1 Then
            valu_bottle5.Value = 2
        ElseIf valu_bottle5.Value = 2 Then
            valu_bottle5.Value = 3
        ElseIf valu_bottle5.Value = 3 Then
            valu_bottle5.Value = 0
        End If
    End Sub

    Private Sub Icon_bottleitem_1_Click(sender As Object, e As EventArgs) Handles Icon_bottleitem_1.Click
        If valu_bottleitem_1.Value = 0 Then
            valu_bottleitem_1.Value = 1
        ElseIf valu_bottleitem_1.Value = 1 Then
            valu_bottleitem_1.Value = 2
        ElseIf valu_bottleitem_1.Value = 2 Then
            valu_bottleitem_1.Value = 3
        ElseIf valu_bottleitem_1.Value = 3 Then
            valu_bottleitem_1.Value = 4
        ElseIf valu_bottleitem_1.Value = 4 Then
            valu_bottleitem_1.Value = 5
        ElseIf valu_bottleitem_1.Value = 5 Then
            valu_bottleitem_1.Value = 6
        ElseIf valu_bottleitem_1.Value = 6 Then
            valu_bottleitem_1.Value = 7
        ElseIf valu_bottleitem_1.Value = 7 Then
            valu_bottleitem_1.Value = 8
        ElseIf valu_bottleitem_1.Value = 8 Then
            valu_bottleitem_1.Value = 9
        ElseIf valu_bottleitem_1.Value = 9 Then
            valu_bottleitem_1.Value = 10
        ElseIf valu_bottleitem_1.Value = 10 Then
            valu_bottleitem_1.Value = 11
        ElseIf valu_bottleitem_1.Value = 11 Then
            valu_bottleitem_1.Value = 12
        ElseIf valu_bottleitem_1.Value = 12 Then
            valu_bottleitem_1.Value = 13
        ElseIf valu_bottleitem_1.Value = 13 Then
            valu_bottleitem_1.Value = 0
        End If
    End Sub

    Private Sub Icon_bottleitem_2_Click(sender As Object, e As EventArgs) Handles Icon_bottleitem_2.Click
        If valu_bottleitem_2.Value = 0 Then
            valu_bottleitem_2.Value = 1
        ElseIf valu_bottleitem_2.Value = 1 Then
            valu_bottleitem_2.Value = 2
        ElseIf valu_bottleitem_2.Value = 2 Then
            valu_bottleitem_2.Value = 3
        ElseIf valu_bottleitem_2.Value = 3 Then
            valu_bottleitem_2.Value = 4
        ElseIf valu_bottleitem_2.Value = 4 Then
            valu_bottleitem_2.Value = 5
        ElseIf valu_bottleitem_2.Value = 5 Then
            valu_bottleitem_2.Value = 6
        ElseIf valu_bottleitem_2.Value = 6 Then
            valu_bottleitem_2.Value = 7
        ElseIf valu_bottleitem_2.Value = 7 Then
            valu_bottleitem_2.Value = 8
        ElseIf valu_bottleitem_2.Value = 8 Then
            valu_bottleitem_2.Value = 9
        ElseIf valu_bottleitem_2.Value = 9 Then
            valu_bottleitem_2.Value = 10
        ElseIf valu_bottleitem_2.Value = 10 Then
            valu_bottleitem_2.Value = 11
        ElseIf valu_bottleitem_2.Value = 11 Then
            valu_bottleitem_2.Value = 12
        ElseIf valu_bottleitem_2.Value = 12 Then
            valu_bottleitem_2.Value = 13
        ElseIf valu_bottleitem_2.Value = 13 Then
            valu_bottleitem_2.Value = 0
        End If
    End Sub

    Private Sub Icon_bottleitem_3_Click(sender As Object, e As EventArgs) Handles Icon_bottleitem_3.Click
        If valu_bottleitem_3.Value = 0 Then
            valu_bottleitem_3.Value = 1
        ElseIf valu_bottleitem_3.Value = 1 Then
            valu_bottleitem_3.Value = 2
        ElseIf valu_bottleitem_3.Value = 2 Then
            valu_bottleitem_3.Value = 3
        ElseIf valu_bottleitem_3.Value = 3 Then
            valu_bottleitem_3.Value = 4
        ElseIf valu_bottleitem_3.Value = 4 Then
            valu_bottleitem_3.Value = 5
        ElseIf valu_bottleitem_3.Value = 5 Then
            valu_bottleitem_3.Value = 6
        ElseIf valu_bottleitem_3.Value = 6 Then
            valu_bottleitem_3.Value = 7
        ElseIf valu_bottleitem_3.Value = 7 Then
            valu_bottleitem_3.Value = 8
        ElseIf valu_bottleitem_3.Value = 8 Then
            valu_bottleitem_3.Value = 9
        ElseIf valu_bottleitem_3.Value = 9 Then
            valu_bottleitem_3.Value = 10
        ElseIf valu_bottleitem_3.Value = 10 Then
            valu_bottleitem_3.Value = 11
        ElseIf valu_bottleitem_3.Value = 11 Then
            valu_bottleitem_3.Value = 12
        ElseIf valu_bottleitem_3.Value = 12 Then
            valu_bottleitem_3.Value = 13
        ElseIf valu_bottleitem_3.Value = 13 Then
            valu_bottleitem_3.Value = 0
        End If
    End Sub

    Private Sub Icon_bottleitem_4_Click(sender As Object, e As EventArgs) Handles Icon_bottleitem_4.Click
        If valu_bottleitem_4.Value = 0 Then
            valu_bottleitem_4.Value = 1
        ElseIf valu_bottleitem_4.Value = 1 Then
            valu_bottleitem_4.Value = 2
        ElseIf valu_bottleitem_4.Value = 2 Then
            valu_bottleitem_4.Value = 3
        ElseIf valu_bottleitem_4.Value = 3 Then
            valu_bottleitem_4.Value = 4
        ElseIf valu_bottleitem_4.Value = 4 Then
            valu_bottleitem_4.Value = 5
        ElseIf valu_bottleitem_4.Value = 5 Then
            valu_bottleitem_4.Value = 6
        ElseIf valu_bottleitem_4.Value = 6 Then
            valu_bottleitem_4.Value = 7
        ElseIf valu_bottleitem_4.Value = 7 Then
            valu_bottleitem_4.Value = 8
        ElseIf valu_bottleitem_4.Value = 8 Then
            valu_bottleitem_4.Value = 9
        ElseIf valu_bottleitem_4.Value = 9 Then
            valu_bottleitem_4.Value = 10
        ElseIf valu_bottleitem_4.Value = 10 Then
            valu_bottleitem_4.Value = 11
        ElseIf valu_bottleitem_4.Value = 11 Then
            valu_bottleitem_4.Value = 12
        ElseIf valu_bottleitem_4.Value = 12 Then
            valu_bottleitem_4.Value = 13
        ElseIf valu_bottleitem_4.Value = 13 Then
            valu_bottleitem_4.Value = 0
        End If
    End Sub

    Private Sub Icon_bottleitem_5_Click(sender As Object, e As EventArgs) Handles Icon_bottleitem_5.Click
        If valu_bottleitem_5.Value = 0 Then
            valu_bottleitem_5.Value = 1
        ElseIf valu_bottleitem_5.Value = 1 Then
            valu_bottleitem_5.Value = 2
        ElseIf valu_bottleitem_5.Value = 2 Then
            valu_bottleitem_5.Value = 3
        ElseIf valu_bottleitem_5.Value = 3 Then
            valu_bottleitem_5.Value = 4
        ElseIf valu_bottleitem_5.Value = 4 Then
            valu_bottleitem_5.Value = 5
        ElseIf valu_bottleitem_5.Value = 5 Then
            valu_bottleitem_5.Value = 6
        ElseIf valu_bottleitem_5.Value = 6 Then
            valu_bottleitem_5.Value = 7
        ElseIf valu_bottleitem_5.Value = 7 Then
            valu_bottleitem_5.Value = 8
        ElseIf valu_bottleitem_5.Value = 8 Then
            valu_bottleitem_5.Value = 9
        ElseIf valu_bottleitem_5.Value = 9 Then
            valu_bottleitem_5.Value = 10
        ElseIf valu_bottleitem_5.Value = 10 Then
            valu_bottleitem_5.Value = 11
        ElseIf valu_bottleitem_5.Value = 11 Then
            valu_bottleitem_5.Value = 12
        ElseIf valu_bottleitem_5.Value = 12 Then
            valu_bottleitem_5.Value = 13
        ElseIf valu_bottleitem_5.Value = 13 Then
            valu_bottleitem_5.Value = 0
        End If
    End Sub

End Class
