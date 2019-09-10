Module Module1

    'Stacks are made of nodes and is in the form of first in last out
    'More like a box of pringles, the first chips in is the last to get out

    Const null As Integer = -1

    Public Structure Node
        Dim pointer As Integer
        Dim data As String
    End Structure

    Public Structure Stack

        Dim flp, header As Integer
        Dim array() As Node


        Sub init(ByVal size As Integer)

            size = size - 1
            ReDim array(size)

            For index = 0 To UBound(array) - 1
                array(index).pointer = index + 1
                array(index).data = ""
            Next

            array(size).pointer = null
            array(size).data = ""

            flp = 0
            header = null
        End Sub

        Sub insertData(ByVal dat As String)
            If flp = null Then
                Console.WriteLine("no space")
                Return
            End If
            Dim finish As Integer
            Dim tmp As Integer = flp
            If header = null Then
                array(flp).data = dat
                flp = array(flp).pointer
                array(tmp).pointer = null
                header = tmp
                finish = tmp
                Return
            End If

            array(flp).data = dat
            flp = array(flp).pointer
            array(tmp).pointer = header
            header = tmp
            Return
        End Sub

        Sub PrintStack(ByVal PrintPointer As Integer)
            If PrintPointer = null Then
                Return
            End If
            Console.WriteLine(array(PrintPointer).data)
            PrintStack(array(PrintPointer).pointer)
        End Sub
    End Structure

    Sub Main()

        Dim stk As Stack
        Dim size As Integer
        Dim data As String

        Console.WriteLine("Enter size:")
        size = Console.ReadLine()
        stk.init(size)

        Console.Clear()

        For x = 0 To size - 1
            Console.WriteLine("enter {0} no. data", x)
            data = Console.ReadLine
            stk.insertData(data)
        Next


        stk.PrintStack(stk.header)

    End Sub

End Module
