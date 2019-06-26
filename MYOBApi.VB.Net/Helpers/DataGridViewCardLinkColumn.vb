'  Copyright:   Copyright 2013 MYOB Technology Pty Ltd. All rights reserved.
'  Website:     http://www.myob.com
'  Author:      MYOB
'  E-mail:      info@myob.com
'
' Documentation, code and sample applications provided by MYOB Australia are for 
' information purposes only. MYOB Technology Pty Ltd and its suppliers make no 
' warranties, either express or implied, in this document. 
'
' Information in this document or code, including website references, is subject
' to change without notice. Unless otherwise noted, the example companies, 
' organisations, products, domain names, email addresses, people, places, and 
' events are fictitious. 
'
' The entire risk of the use of this documentation or code remains with the user. 
' Complying with all applicable copyright laws is the responsibility of the user. 
'
' Copyright 2013 MYOB Technology Pty Ltd. All rights reserved.

Imports System.Web
Imports System.Net
Imports MYOB.AccountRight.SDK
Imports MYOB.AccountRight.SDK.Contracts

''' <summary>
''' Custom DataGridView Column for displaying a cardlink
''' </summary>
''' <remarks></remarks>
Public Class DataGridViewCardLinkColumn
    Inherits DataGridViewColumn

    Public Sub New()
        CellTemplate = New DataGridViewCardLinkCell()
        Me.ReadOnly = True
    End Sub
End Class

''' <summary>
''' Custom DataGridView Cell for displaying a cardlink
''' </summary>
''' <remarks></remarks>
Public Class DataGridViewCardLinkCell
    Inherits DataGridViewTextBoxCell

    Protected Overrides Sub Paint(graphics As System.Drawing.Graphics, clipBounds As System.Drawing.Rectangle, cellBounds As System.Drawing.Rectangle, _
        rowIndex As Integer, cellState As DataGridViewElementStates, value As Object, formattedValue As Object, errorText As String, cellStyle As DataGridViewCellStyle, _
        advancedBorderStyle As DataGridViewAdvancedBorderStyle, paintParts As DataGridViewPaintParts)

        'The value passed to cell is a CardLink object, set the formatted value to be the Name on the card
        Dim card As Version2.Contact.CardLink = value
        MyBase.Paint(graphics, clipBounds, cellBounds, rowIndex, cellState, card, card.Name, errorText, cellStyle, advancedBorderStyle, paintParts)

    End Sub


End Class


