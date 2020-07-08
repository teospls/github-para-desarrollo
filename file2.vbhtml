@Modeltype Extranet.Website.Models.PromotionsModel
@imports System.Globalization
@imports Extranet.Website.Extensions
@imports Extranet.Web.Helpers
@imports Extranet.Web.Models.TimeOfDay
@imports Extranet.Website.Models

@Code
    ViewData("Title") = "Editar Promocion"
    Layout = "~/Views/Shared/_LayoutPopUp.vbhtml"
End Code

@helper DecToBin(ByVal DecNum As Double)                    '1,0,1,1,1,1,

    Dim BinStr As String
    BinStr = ""
    
    Dim bin_str_file2 As String
    bin_str_file2 = "file2"

    Do While DecNum <> 0
        If (DecNum Mod 2) = 1 Then
            BinStr = "1," & BinStr
        Else
            BinStr = "0," & BinStr
        End If
        DecNum = DecNum \ 2
    Loop
    If BinStr = "" Then BinStr = "0,0,0,0"

    'DecToBin = BinStr
    While BinStr.Length < 14
        BinStr = "0," & BinStr
    End While





    Dim bin = BinStr.Substring(0, BinStr.Length - 1)


    @BinStr.Substring(0, BinStr.Length - 1)

End helper


@helper TextoCargaTarifas(ByVal TipoCarga As String, ByVal Clav_Plan As String, Optional ByVal Clav_Moneda As String = "US")
    Dim sLabelImpuestos As String = ""
    Dim sSpecialCountry = ""
    If Session("PaisHotel") = "PE" Then
        If Session("Clav_Notif") = "V" Then
            sSpecialCountry = IIf(TipoCarga = "H" Or Clav_Plan = "EP" Or Clav_Plan = "BI", Resources.Dictionary.disTextRateRoomPeru, Resources.Dictionary.disTextRatePeru)
        Else
            sSpecialCountry = IIf(TipoCarga = "H" Or Clav_Plan = "EP" Or Clav_Plan = "BI", Resources.Dictionary.disTextRateRoomPeruNet, Resources.Dictionary.disTextRatePeruNet)
        End If
    ElseIf Session("PaisHotel") = "CO" Then
        If Session("Clav_Notif") = "V" Then
            sSpecialCountry = IIf(TipoCarga = "H" Or Clav_Plan = "EP" Or Clav_Plan = "BI", Resources.Dictionary.disTextRateRoomColombia, Resources.Dictionary.disTextRateColombia)
        Else
            sSpecialCountry = IIf(TipoCarga = "H" Or Clav_Plan = "EP" Or Clav_Plan = "BI", Resources.Dictionary.disTextRateRoomColombiaNet, Resources.Dictionary.disTextRateColombiaNet)
        End If

    ElseIf (Session("PaisHotel") = "CL" And Clav_Moneda.ToUpper = "US") Or Session("PaisHotel") = "UY" Then
        If Session("Clav_Notif") = "V" Then
            sSpecialCountry = IIf(TipoCarga = "H" Or Clav_Plan = "EP" Or Clav_Plan = "BI", Resources.Dictionary.disTextRateRoomChile, Resources.Dictionary.disTextRateChile)
        Else
            sSpecialCountry = IIf(TipoCarga = "H" Or Clav_Plan = "EP" Or Clav_Plan = "BI", Resources.Dictionary.disTextRateRoomChileNet, Resources.Dictionary.disTextRateChileNet)
        End If

    End If



    If Clav_Plan = "EP" Or Clav_Plan = "BI" Then
        If Session("Clav_Notif") = "V" Then 'Ve la pública, No ve la Neta
            If (((Session("PaisHotel") = "CL") And Clav_Moneda.ToUpper = "US") Or Session("PaisHotel") = "CO" Or Session("PaisHotel") = "PE" Or Session("PaisHotel") = "UY") Then
                sLabelImpuestos = sSpecialCountry
            ElseIf (Session("PaisHotel") = "EC") Then '
                sLabelImpuestos = Resources.Dictionary.disTaxXRoomVTA
            ElseIf (Session("PaisHotel") = "BO" Or Session("PaisHotel") = "PY" Or Session("PaisHotel") = "VE") Then
                sLabelImpuestos = Resources.Dictionary.diswithTaxXRoomVTA
            Else
                sLabelImpuestos = Resources.Dictionary.disTaxEPVta
            End If
            sLabelImpuestos = "<span class=""LblNoteTaxes"">" & "<img class=""taxType"" alt=""" & sLabelImpuestos & """ src=""" & Url.Content("~/Content/themes/base/images/P_EP.png") & """/>" & sLabelImpuestos & "</span>"
        Else
            If (((Session("PaisHotel") = "CL") And Clav_Moneda.ToUpper = "US") Or Session("PaisHotel") = "CO" Or Session("PaisHotel") = "PE" Or Session("PaisHotel") = "UY") Then
                sLabelImpuestos = sSpecialCountry
            ElseIf (Session("PaisHotel") = "EC") Then
                sLabelImpuestos = Resources.Dictionary.disTaxXRoomNET
            ElseIf (Session("PaisHotel") = "BO" Or Session("PaisHotel") = "PY" Or Session("PaisHotel") = "VE") Then
                sLabelImpuestos = Resources.Dictionary.diswithTaxXRoomNET
            Else
                sLabelImpuestos = Resources.Dictionary.disTaxEP
            End If
            sLabelImpuestos = "<span class=""LblNoteTaxes"">" & "<img class=""taxType"" alt=""" & sLabelImpuestos & """ src=""" & Url.Content("~/Content/themes/base/images/N_EP.png") & """/>" & sLabelImpuestos & "</span>"
        End If
    Else
        If Session("Clav_Notif") = "V" Then 'Ve la pública, No ve la Neta
            If (((Session("PaisHotel") = "CL") And Clav_Moneda.ToUpper = "US") Or Session("PaisHotel") = "CO" Or Session("PaisHotel") = "PE" Or Session("PaisHotel") = "UY") Then
                sLabelImpuestos = sSpecialCountry
            ElseIf (Session("PaisHotel") = "EC") Then
                sLabelImpuestos = IIf(TipoCarga = "H", Resources.Dictionary.disTaxXRoomVTA, Resources.Dictionary.disTaxNoEPVta)
            ElseIf (Session("PaisHotel") = "BO" Or Session("PaisHotel") = "PY" Or Session("PaisHotel") = "VE") Then
                sLabelImpuestos = IIf(TipoCarga = "H", Resources.Dictionary.diswithTaxXRoomVTA, Resources.Dictionary.diswithTaxNoEPVta)
            Else
                sLabelImpuestos = IIf(TipoCarga = "H", Resources.Dictionary.disTaxXRoomVTA, Resources.Dictionary.disTaxNoEPVta)
            End If
            sLabelImpuestos = "<span class=""LblNoteTaxes"">" & "<img class=""taxType"" alt=""" & sLabelImpuestos & """ src=""" & Url.Content("~/Content/themes/base/images/P_NOEP.png") & """/>" & sLabelImpuestos & "</span>"
        Else
            If (((Session("PaisHotel") = "CL") And Clav_Moneda.ToUpper = "US") Or Session("PaisHotel") = "CO" Or Session("PaisHotel") = "PE" Or Session("PaisHotel") = "UY") Then
                sLabelImpuestos = sSpecialCountry
            ElseIf (Session("PaisHotel") = "EC") Then 'Or
                sLabelImpuestos = IIf(TipoCarga = "H", Resources.Dictionary.disTaxXRoomNET, Resources.Dictionary.disTaxNoEP) ' Resources.Dictionary.disTaxNoEP
            ElseIf (Session("PaisHotel") = "BO" Or Session("PaisHotel") = "PY" Or Session("PaisHotel") = "VE") Then
                sLabelImpuestos = IIf(TipoCarga = "H", Resources.Dictionary.diswithTaxXRoomNET, Resources.Dictionary.diswithTaxNoEP)
            Else
                sLabelImpuestos = IIf(TipoCarga = "H", Resources.Dictionary.disTaxXRoomNET, Resources.Dictionary.disTaxNoEP)
            End If

            sLabelImpuestos = "<span class=""LblNoteTaxes"">" & "<img class=""taxType"" alt=""" & sLabelImpuestos & """ src=""" & Url.Content("~/Content/themes/base/images/N_NOEP.png") & """/>" & sLabelImpuestos & "</span>"
        End If
    End If

    @Html.Raw(sLabelImpuestos)

end helper

<script src="@Url.Content("~/Scripts/jquery-1.7.min.js")" type="text/javascript"></script>
<script src="@Url.Content("~/Scripts/jquery.validate.min.js")" type="text/javascript"></script>
<script src="@Url.Content("~/Scripts/jquery-ui-1.8.16.js")" type="text/javascript"></script>

<link href="@Url.Content("~/Content/themes/base/style.css")" rel="stylesheet" type="text/css" />
<link href="@Url.Content("~/Content/themes/base/PromoStyle.css")" rel="stylesheet" type="text/css" />
<link href="@Url.Content("~/Content/themes/base/jquery-ui.css")" rel="stylesheet" type="text/css" />

<script src="@Url.Content("~/Scripts/Extranet/script.js")" type="text/javascript"></script>
<script src="@Url.Content("~/Scripts/Extranet/libs/ui.js")" type="text/javascript"></script>

<script src="@Url.Content("~/Scripts/jquery.ui.datepicker-es.js")" type="text/javascript"></script>
<script src="@Url.Content("~/Scripts/jquery.ui.datepicker-pt-BR.js")" type="text/javascript"></script>

<script src="@Url.Content("~/Scripts/scrollTo/jquery.scrollTo.js")" type="text/javascript"></script>
<script src="@Url.Content("~/Scripts/scrollTo/jquery.scrollTo-min.js")" type="text/javascript"></script>
<script src="@Url.Content("~/Scripts/Globalize/globalize.js")" type="text/javascript"></script>
@code
    Dim culture As String = Session("CurrencyCulture").ToString()
    Select Case culture
        Case "en-US"
            @<script src="@Url.Content("~/Scripts/Globalize/globalize.culture.en-US.js")" type="text/javascript"></script>

        Case "pt-BR"
                                @<script src="@Url.Content("~/Scripts/Globalize/globalize.culture.pt-BR.js")" type="text/javascript"></script>

        Case Else
                                @<script src="@Url.Content("~/Scripts/Globalize/globalize.culture.es-MX.js")" type="text/javascript"></script>
    End Select
End Code

<script src="@Url.Content("~/Scripts/Ajax/MicrosoftAjax.js")" type="text/javascript"></script>
<script src="@Url.Content("~/Scripts/Ajax/MicrosoftMvcAjax.js")" type="text/javascript"></script>
<script src="@Url.Content("~/Scripts/jquery.numeric.js")" type="text/javascript"></script>

<script src="@Url.Content("~/Scripts/SeekAttention/seekAttention.jquery.js")" type="text/javascript"></script>
<script src="@Url.Content("~/Scripts/Simpletip/jquery.simpletip-1.3.1.min.js")" type="text/javascript"></script>

<style>
    .fixedContent .promoEditing .promoBasics .resumeBox .promoResume {
        float: none;
        margin-bottom: 20px;
        width: auto;
    }
</style>

@code
    Dim PagesUser = DirectCast(Session("Pages"), List(Of pagesUser))

    Dim ShowPromo24Hrs = 0
    If Not PagesUser Is Nothing Then

        ShowPromo24Hrs = (From pm In PagesUser Where pm.PageName.Equals("Exclusivas24Hrs")).Count

    End If

    Dim Vouchers = DirectCast(ViewData("VoucherList"), List(Of VoucherModels))

    @*Obtiene lista de promociones selecionadas en filtros*@
Dim roomsPlanList = DirectCast(Session("ListRoomPlan"), List(Of Extranet.Website.Models.HotelRoomPlansFilter))
Dim roomsPlan = (From x In roomsPlanList
                 Group By x.Clav_Hotel, x.Clav_Cuarto, x.Clav_Plan, x.Cap_Adultos, x.Cap_Extras, x.Cap_Ninos, x.Cap_Total, x.Nombre_Cuarto, x.Nombre_Plan
                 Into CustomersInCountry = Group, Count()).ToList()


'Dim roomsPlan = (From X In roomsPlanList).Distinct.ToList()


Dim ListaContratos = Session("HotelContract").split("-")
Dim ContratoPagoDestino As Boolean = False
If Session("HotelContract").ToString.IndexOf("PDESTINO") > -1 Then ContratoPagoDestino = True

Dim ContratosSincronizados = DirectCast(Session("ContratosSincronizadosHotel"), List(Of Extranet.Website.Extranet.Data.spe_ExtranetII_ObtenerContratosSincronizadosHotelResult))
ContratosSincronizados = (From c In ContratosSincronizados Where c.ModuloAplica.Contains("P") Select c).ToList

Dim ListAgesByHotelRoom = DirectCast(ViewData("ListAgesByHotelRoom"), List(Of Extranet.Website.Models.AgeByHotelRoom))

    @*Obtiene informacion general de la promo*@
Dim Promo = DirectCast(ViewData("PromoInfo"), Extranet.Domain.POCO.Promotion.DetailPromotion)

    @*contiene las habitaciones, contratos y tarifas de los que tienen agregada la promo*@
Dim ListPromoRoom = DirectCast(Session("ListRoomsPromo"), List(Of Extranet.Website.Models.RoomPromoRate))
Dim contractPromo = (From x In ListPromoRoom
                     Select New HotelContractsFilter With {.Clav_Mercado = x.Clav_Mercado, .Id_Contrato = x.Id_Contrato}).Distinct.ToList

'ListPromoRoom.GroupBy(Function(x) x.Clav_Mercado, Function(x) x.Id_Contrato).Select(Function(y) y.First)

Dim ListBlackOutDates As Object = ViewData("datesBlackOutList")
Dim ci As CultureInfo = New CultureInfo(Session("CurrencyCulture").ToString())
Dim nfi As NumberFormatInfo = ci.NumberFormat
'Tipo de notificaciones
Dim notif_Type = ListaContratos(4)

Dim EsNeta As Boolean = True
'Define si tiene la promo de niños gratis
Dim IsChildFree As Boolean = False
Dim IsJrFree As Boolean = False

'Informacion de la capacidad de las habitaciones
Dim showSingle As Boolean = False
Dim showDouble As Boolean = False
Dim showTriple As Boolean = False
Dim showCuadruple As Boolean = False
Dim showExtras As Boolean = False
Dim colspanRates As Integer = 0
'If (From l In ListAgesByHotelRoom Where l.Clav_Cuarto = sParamsArray(1) And (l.Cap_Adultos + l.Cap_Extras) >= 1).Count > 0 Then
If (From l In ListAgesByHotelRoom Where l.Clav_Cuarto = Promo.Clav_Cuarto And (l.Cap_Adultos) >= 1).Count > 0 Then
    showSingle = True
    colspanRates += 1
End If
'If (From l In ListAgesByHotelRoom Where l.Clav_Cuarto = sParamsArray(1) And (l.Cap_Adultos + l.Cap_Extras) >= 2).Count > 0 Then
If (From l In ListAgesByHotelRoom Where l.Clav_Cuarto = Promo.Clav_Cuarto And (l.Cap_Adultos) >= 2).Count > 0 Then
    showDouble = True
    colspanRates += 1
End If
'If (From l In ListAgesByHotelRoom Where l.Clav_Cuarto = sParamsArray(1) And (l.Cap_Adultos + l.Cap_Extras) >= 3).Count > 0 Then
If (From l In ListAgesByHotelRoom Where l.Clav_Cuarto = Promo.Clav_Cuarto And (l.Cap_Adultos) >= 3).Count > 0 Then
    showTriple = True
    colspanRates += 1
End If
'If (From l In ListAgesByHotelRoom Where l.Clav_Cuarto = sParamsArray(1) And (l.Cap_Adultos + l.Cap_Extras) >= 4).Count > 0 Then
If (From l In ListAgesByHotelRoom Where l.Clav_Cuarto = Promo.Clav_Cuarto And (l.Cap_Adultos) >= 4).Count > 0 Then
    showCuadruple = True
    colspanRates += 1
End If
'If Promo.Clav_Plan = "EP" Then
If (From l In roomsPlan Where l.Clav_Cuarto = Promo.Clav_Cuarto And l.Cap_Extras >= 1).Count > 0 Then
    showExtras = True
End If
'End If

Dim showChildHead As Boolean = False
Dim showJuniorHead As Boolean = False
Dim sAgesChild As String = ""
Dim sAgesJunior As String = ""

If (From l In ListAgesByHotelRoom Where l.Edad_Nino <> "0 - 0").Count > 0 Then
    showChildHead = True
    sAgesChild = (From l In ListAgesByHotelRoom Where l.Edad_Nino <> "0 - 0" Select l.Edad_Nino).ToList.First
End If
If (From l In ListAgesByHotelRoom Where l.Edad_Junior <> "0 - 0").Count > 0 Then
    showJuniorHead = True
    sAgesJunior = (From l In ListAgesByHotelRoom Where l.Edad_Junior <> "0 - 0" Select l.Edad_Junior).ToList.First

End If

'Nombre del hotel
Dim hotelName = Session("HotelName")
Dim contactName = Session("ContractName")

'Plan
Dim PlanRooms = Promo.Clav_Plan

'Unidad descuento %, MXN, USD
Dim Unit_Discount = If(Promo.Tipo_Promo.Contains("OF_PO"), "%", ListaContratos(6))

'Dias que es valida la promocion
Dim DaysTravel As String = DecToBin(Promo.Dia_Tarifa).ToString()
Dim dayTravel() As String = DaysTravel.Split(",")
'Dias especificos de llegada
Dim DaysArrival As String = DecToBin(Promo.Dia_Llegada).ToString()
Dim dayArrival() As String = DaysArrival.Split(",")


'Dias especificos de la promocion
Dim DaysPromo As String = DecToBin(Promo.Dia_Promo).ToString()
Dim dayPromo() As String = DaysPromo.Split(",")

'Fechas de Booking Windows
Dim windows_de As Date
Dim windows_a As Date
If Promo.Booking_Window_De Is Nothing And Promo.Booking_Window_A Is Nothing Then
    windows_de = Promo.Temporada_Inicial.AddDays(-Promo.Booking_En_Dias)
    windows_a = Promo.Temporada_Inicial.AddDays(-Promo.Booking_En_Dias_After)
Else
    windows_de = IIf(Promo.Booking_Window_De Is Nothing, Now, Promo.Booking_Window_De)
    windows_a = Promo.Booking_Window_A
End If


Dim sHotelContract As New List(Of Extranet.Website.Models.HotelContractsFilter)
Dim hotelContractST() = Session("HotelContract").ToString.Split("|"c)
For Each item In hotelContractST
    If item <> "" Then
        Dim arr = item.Split("-")
        sHotelContract.Add(New Extranet.Website.Models.HotelContractsFilter() With {.Clav_Hotel = arr(0), .Clav_Mercado = arr(1), .Id_Contrato = arr(2), .MarkUp_Up_Gral_Def = Decimal.Parse(arr(3)), .Clav_Notif = arr(4), .Id_Allotment = Integer.Parse(arr(5)), .Nombre_Mondena = arr(6), .Nombre_Contrato = arr(7).Replace("_", "-"), .Tarifa_Minima = arr(8), .Tarifa_Maxima = arr(9)})

    End If
Next

Dim Is24Hrs = IIf(Promo.CodigoPromo = "24HORAS", True, False)


Dim EsPromoOculta = IIf(Promo.esPromocionOculta, True, False)

Dim withVoucher As Boolean = False
If (Not Vouchers Is Nothing) Then
    withVoucher = IIf(Vouchers.Count > 0, True, False)
End If


End Code
<script type="text/javascript">
    const maxDaysAllowed = 255
   function StartRequest() {
    parent.busyBox.Show();
   }

   function ErrorRequest() {
   parent.busyBox.Hide();
   }

   function EndRequest() {
      parent.busyBox.Hide();

       $("#ResultDivFancy h2").css("margin-top","-30px");
       //Tabs de vista previa
       $('.languageTabs').tabs();
       if($("#ac").val() == "ap")
       {
           $(".applyPreview input[type=submit]").addClass("bkd");
           $(".applyPreview input[type=submit]").attr('disabled','disabled');
       }
       parent.$('#PromoWasUpdated').attr('value', 'True');

   }

  function freeNightValidate(evt) {
    var charCode = (evt.which) ? evt.which : event.keyCode;
    if (charCode != 46 && charCode > 31
        && (charCode < 48 || charCode > 57)) {
        return false;
    } else {
        return true;
    }
 }

    function maxDaysKeyPress(evt) {
        if (evt.value > maxDaysAllowed) {
             $("#bookingMaxDays").seekAttention();
                alert("@Html.Raw(Resources.Dictionary.promoMaxAnticipated)");
                return false;
        }
    }

	//implemtar modificacon a los demas modulos
    //tsp. version beta
    function freeNightKeyPress(evt) {      
      var _andNights = $("#andNights").is(":checked")
      if (_andNights) {
        var Noche_Gratis2 = parseInt($('#Noche_Gratis2').val())
        if (evt.value !== "" & !isNaN(Noche_Gratis2)) {
          var freeNight = parseInt(evt.value)
          if (freeNight > Noche_Gratis2) {
            alert("@Html.Raw(Resources.Dictionary.disFreeNightsValidation)");
            $("#FreeNight").seekAttention();
          }
        }
      }
    }

    function secondFreeNightValidate(evt) {
    var charCode = (evt.which) ? evt.which : event.keyCode;
    if (charCode != 46 && charCode > 31
        && (charCode < 48 || charCode > 57)) {
        return false;
    } else {
        return true;
    }
}

function secondFreeNightKeyPress(evt) {
    var FreeNight = parseInt($('#FreeNight').val());
    if (evt.value !== "" & !isNaN(FreeNight)) {
        var NocheGratis2 = parseInt(evt.value)
        if (FreeNight > NocheGratis2) {
            alert("@Html.Raw(Resources.Dictionary.disFreeNightsValidation)");
            $("#Noche_Gratis2").seekAttention();
        }
    }
}
    $(document).ready(function () {
        CheckMoneyContracts(); //Valida el tipo de descuento que tienen aplicados los contratos de la promocion.

        $.ajax({
            url: "_Promo24Booking",
            dataType: "html",
            data: {
                hotel: @(Session("ClaveHotel")),
                ed: @(IIf(Not Promo.Activo, 1, IIf(Promo.Booking_Window_A >= Now And Is24Hrs, 0, 1))),
                dateBooking: "@(Promo.Booking_Window_De)"
                , view: "P"
                },
                    success: function (data) {
                        $("#24Booking").html(data)
                    },
                    error: function (jqXHR, textStatus, errorThrown) {
                        if (errorThrown.toString().indexOf("***LOGON***") != -1) {
                            window.location = "http://" + window.location.host + "/Account/logoff";
                        }
                    }
                });

        $("input[name=Type_Booking]").click(function(){
            switch ($(this).val()){
                case "T24": $("#Codigo_Promo").val("24HORAS");
                    $("#Codigo_Promo").attr("disabled","disabled");
                    break;
                default:
                    $("#Codigo_Promo").removeAttr("disabled");
                    $("#Codigo_Promo").val(($("#Codigo_Promo").val()=="24HORAS")?"":$("#Codigo_Promo").val());
                    break;

            }
        });

        var myBingApiAppId = "AIzaSyB41wCNVwojR9XpSZ2Lo1pH0ildlZQyomY";   // "AIzaSyDWelvDp81QIB1q6QrP-BBJgOVRQUob2Ck";
        $("#english #translateEN").click(function () {

            var TextToTrasnlate = $("#Valor_Agregado_Ingles").val();
            TextToTrasnlate = TextToTrasnlate.replace("%", "[x]", "gi");

            if ($("#english #etp").is(":checked")) {
                $.getJSON("https://www.googleapis.com/language/translate/v2?key=AIzaSyB41wCNVwojR9XpSZ2Lo1pH0ildlZQyomY&q=" + TextToTrasnlate + "&source=en&format=text&target=es&callback=?", function (data) {

                    $.each(data, function (key, val) {
                        var textoTraducido = val.translations[0].translatedText.replace(" [x]", "%", "gi");
                        $("#Valor_Agregado_Espanol").val(textoTraducido);

                    });

                });

            }
            if ($("#english #pte").is(":checked")) {
                $.getJSON("https://www.googleapis.com/language/translate/v2?key=AIzaSyB41wCNVwojR9XpSZ2Lo1pH0ildlZQyomY&q=" + TextToTrasnlate + "&source=en&format=text&target=pt&callback=?", function (data) {

                    $.each(data, function (key, val) {
                        var textoTraducido = val.translations[0].translatedText.replace(" [x]", "%", "gi");
                        $("#Valor_Agregado_Portuguese").val(textoTraducido);

                    });

                });

            }
        });

        $("#spanish #translateES").click(function () {

            var TextToTrasnlate = $("#Valor_Agregado_Espanol").val();
            TextToTrasnlate = TextToTrasnlate.replace("%", "[x]", "gi");

            if ($("#spanish #ete").is(":checked")) {

                $.getJSON("https://www.googleapis.com/language/translate/v2?key=AIzaSyB41wCNVwojR9XpSZ2Lo1pH0ildlZQyomY&q=" + TextToTrasnlate + "&source=es&format=text&target=en&callback=?", function (data) {

                    $.each(data, function (key, val) {

                        var textoTraducido = val.translations[0].translatedText.replace(" [x]", "%", "gi");
                        $("#Valor_Agregado_Ingles").val(textoTraducido);

                    });

                });

            }
            if ($("#spanish #pte").is(":checked")) {
                $.getJSON("https://www.googleapis.com/language/translate/v2?key=AIzaSyB41wCNVwojR9XpSZ2Lo1pH0ildlZQyomY&q=" + TextToTrasnlate + "&source=es&format=text&target=pt&callback=?", function (data) {

                    $.each(data, function (key, val) {
                        var textoTraducido = val.translations[0].translatedText.replace(" [x]", "%", "gi");
                        $("#Valor_Agregado_Portuguese").val(textoTraducido);
                    });

                });

            }
        });

        $("#portuguese #translatePO").click(function () {

            var TextToTrasnlate = $("#Valor_Agregado_Portuguese").val();
            TextToTrasnlate = TextToTrasnlate.replace("%", "[x]", "gi");

            if ($("#portuguese #ete").is(":checked")) {
                $.getJSON("https://www.googleapis.com/language/translate/v2?key=AIzaSyB41wCNVwojR9XpSZ2Lo1pH0ildlZQyomY&q=" + TextToTrasnlate + "&source=pt&format=text&target=en&callback=?", function (data) {

                    $.each(data, function (key, val) {

                        var textoTraducido = val.translations[0].translatedText.replace(" [x]", "%", "gi");
                        $("#Valor_Agregado_Ingles").val(textoTraducido);

                    });

                });
            }
            if ($("#portuguese #etp").is(":checked")) {
                $.getJSON("https://www.googleapis.com/language/translate/v2?key=AIzaSyB41wCNVwojR9XpSZ2Lo1pH0ildlZQyomY&q=" + TextToTrasnlate + "&source=pt&format=text&target=es&callback=?", function (data) {

                    $.each(data, function (key, val) {
                        var textoTraducido = val.translations[0].translatedText.replace(" [x]", "%", "gi");
                        $("#Valor_Agregado_Espanol").val(textoTraducido);
                    });

                });

            }
        });


        //Activa la pestaña de la promocion
        $("#Chck_promoType input:checked:first").parent().click();

        var FreeNight2 = parseInt("@Promo.Noche_Gratis2");
        if (FreeNight2 <= 0) {
            $("#Acumulable2,#Noche_Gratis2").attr("disabled","disabled");
        }

        //Desactiva campos noches descuento
        var NochesDescuento2 = parseInt("@Promo.NocheDescuento2");
        if (NochesDescuento2 <= 0) {
            $("#AcumulableDescuento2,#NochesDescuento2").attr("disabled", "disabled");
        }

        $(".discountDetail .table .tableRow input[type=text]").focus(function(){
            $(this).select();
        })

        //MUestra link de remover todos los blackouts en caso que haya
        showRemoveAll();

        //RESTRINGE TEXTO EN INPUTS
        var sepDec = '.'; //Indica el separador de decimales.
        if ('@Session("CurrencyCulture")' == '') {
            Globalize.culture('es-MX'); //Asigna la cultura por default
        }
        else {
            Globalize.culture('@Session("CurrencyCulture")');
        }

        if ('@Session("CurrencyCulture")' == 'pt-BR') {
            sepDec = ',';
        }

        $(".td input, #MarkUp_DV_PE").numeric({ decimal: sepDec, negative: false }, function () { alert('@Html.Raw(Resources.Dictionary.disNoNegativeVal)'); this.value = ""; this.focus(); });
        $(".col input").numeric({ decimal: sepDec, negative: false }, function () { alert('@Html.Raw(Resources.Dictionary.disIntPositivo)'); this.value = ""; this.focus(); });
        $("#Min_Nights").numeric({ decimal: false, negative: false }, function () { alert('@Html.Raw(Resources.Dictionary.disNoNegativeVal)'); this.value = "0"; this.focus(); });

        //* Obtiene textos de promociones *//
        $.ajax({
            url: "GetPromoText",
            type: "GET",
            dataType: "json",
            data: "ht=@Promo.Clav_Hotel&rm=@Promo.Clav_Cuarto&pm=@Promo.Clav_Plan&fi=@String.Format(Promo.Temporada_Inicial, "dd/MM/yyyy")&cns=@Promo.Consec",
            contentType:  'application/json; charset=utf-8',
            success: function (data) {
                if (data != null && data.length > 0) {
                    for(var i = 0; i< data.length; i++)
                    {
                        if(data[i].Valor_Agregado != "null")
                        {
                            switch (data[i].Clav_Idioma)
                            {
                                case "ESP": $("#spanish textarea").text(data[i].Valor_Agregado);
                                break;
                                case "ING": $("#english textarea").text(data[i].Valor_Agregado);
                                break;
                                case "POR": $("#portuguese textarea").text(data[i].Valor_Agregado);
                                break;
                            }
                        }
                        if(data[i].Descripcion != "null")
                        {
                            switch (data[i].Clav_Idioma)
                            {
                                case "ESP": $("#prevSpanish").text(data[i].Descripcion);
                                break;
                                case "ING": $("#prevEnglish").text(data[i].Descripcion);
                                break;
                                case "POR": $("#prevPortuguese").text(data[i].Descripcion);
                                break;
                            }
                        }
                    }
                }
            }
        });
        //Obtiene los Bloqueos De las promos

        $.ajax({
            url: "/ProductAdmin/SearchBloqueoPromos",
            dataType: "html",
            data: {
                Hotel: '@ViewData("Hotel")', Consecutivos: '@ViewData("Consecutivos")'
            },
            type: "GET",

             success: function (html) {

                 $("#Dates_Blackout").html(html);

                 var Haybloqueo = $('.hCheck').attr('value');

                 if (Haybloqueo == 1) {

                     $("#open_blackout").attr('checked', 'checked');
                     $("#blackout").show();


                 }
                 else {
                     $("#open_blackout").attr("checked", false);
                 }
             },
        });

        /*Se valida las noches gratis.*/
        $("#FreeNight, #Noche_Gratis2").blur(function () {
            var noches = $(this).val();
            if (noches > 0) {
                $("#freeLastNight").attr("disabled", "disabled");
                $("#freeLastNight").removeAttr("checked");
                $("#Ultima_Gratis").val("False");
            } else {
                $("#freeLastNight").removeAttr("disabled");
            }
         });

        //* Habilita/Deshabilita campos *//
        $('.toggle_disabled').click(function(){
            $(this).parent().click();
            var idOpen = $(this).parent().attr("id");
            idOpen = idOpen.split("open_");

            var roomsRows = $(".roomList input:checked");
            var vshow = 0;
            $.each(roomsRows, function (index, checkboxRooms) {
                if ($(checkboxRooms).attr("id").indexOf('_EP') < 0 && $(checkboxRooms).attr("id").indexOf('_BI') < 0)
                {
                    vshow += 1;
                }
            });

            if ($(this).attr("id") == "Free_Kids" && vshow == 0)
            {
                alert("@Resources.Dictionary.disFreeChildNotAvailable");
                $(this).removeAttr("checked");
            }
            else{
                if($(this).is(':checked')){
			        $("#"+idOpen[1] +" input[type=checkbox]").removeAttr('disabled');
                    $("#"+idOpen[1] +" input[type=text]").removeAttr('disabled');
			        $("#"+idOpen[1] +" textarea").removeAttr('disabled');
                    $("#"+idOpen[1] +" select").removeAttr('disabled');
                    $("#"+idOpen[1] +" input[type=radio]").removeAttr('disabled');
		        }else{
			        $("#"+idOpen[1] +" input[type=checkbox]").attr('disabled','disabled');
                    $("#"+idOpen[1] +" input[type=text]").attr('disabled','disabled');
                    $("#"+idOpen[1] +" textarea").attr('disabled','disabled');
                    $("#"+idOpen[1] +" select").attr('disabled','disabled');
                    $("#"+idOpen[1] +" input[type=radio]").attr('disabled','disabled');
		        }
            }

            if ($(this).val() == "FN") {
                if($("#andNights").not(":checked")) {
                    $("#Acumulable2, #Noche_Gratis2").attr('disabled','disabled');
                }
            }
            //texto de los campos seleccionados
            var tipos_Promo = $("#PromoType").val();
            if($(this).is(":checked"))
            {
                if($(this).val() != "")
                {
                    tipos_Promo= tipos_Promo + $(this).val() +"|";
                }
                else{
                    var radio_Type = $("#discount input[type=radio]");
                    $.each(radio_Type, function (index, itemData) {
                        if ($(this).is(":checked")){
                            tipos_Promo= tipos_Promo + $(this).val() +"|";
                        }
                    });
                    $("#PromoType").val(tipos_Promo);
                }
                $("#PromoType").val(tipos_Promo);
            }
            else{
                if($(this).val() != "")
                {
                    var arr_tipoPromos = tipos_Promo.split("|");
                    tipos_Promo = "";
                    for(var i = 0; i <arr_tipoPromos.length; i++ )
                    {
                        if (arr_tipoPromos[i] != "" && arr_tipoPromos[i]!= $(this).val())
                        {
                            tipos_Promo += arr_tipoPromos[i] + "|";
                            //alert(arr_tipoPromos[i]);
                        }
                    }
                    $("#PromoType").val(tipos_Promo);
                }
                else{
                    var radio_Type = $("#discount input[type=radio]");
                    $.each(radio_Type, function (index, itemData) {
                        if ($(this).is(":checked")){
                            var arr_tipoPromos = tipos_Promo.split("|");
                            tipos_Promo = "";
                            for(var i = 0; i <arr_tipoPromos.length; i++ )
                            {
                                if (arr_tipoPromos[i] != "" && arr_tipoPromos[i]!= $(itemData).val())
                                {
                                    tipos_Promo += arr_tipoPromos[i] + "|";
                                }
                            }
                            $("#PromoType").val(tipos_Promo);
                        }
                    });
                }
            }
	    });

        $(".radioSelection input[type=radio]").click(function(){
            $("#Tipo_Booking").val($(this).val());
        });


        $(".roomList input").click(function () {
            var valor = $(this).attr('checked')
            var conf = true;
            if (valor!= 'checked') {
                //alert("desea desactivar la promoción");

                var msg = '@Html.Raw(Resources.Dictionary.disConfDisPromo)';
                conf = confirm(msg);

                if (conf == false) {
                    $(this).attr('checked','checked')
                }

            }


        });



        /*Selecciona todos los contratos o habitaciones*/
        $(".SelectAll").click(function () {
            var select = $(this).parent().next();
            var checkRoom = $("input[type='checkbox']", select);
            var checkAll = $(this);

            if ($(checkAll).is(":checked")) { //SELECCIONA TODOS LOS CONTRATOS
                $.each(checkRoom, function (index, itemData) {

                    if ($(checkAll).attr("id") == "AllContract") {

                         if ($(itemData).is(':disabled') == false) {
                             $(itemData).attr("checked", true);
                             CheckNotifContracts(itemData); //Verifica que el tipo de notificacion de los contratos seleccionados sean iguales
                         }


                        if ($(itemData).is(':disabled') == false && CheckNotifContracts(itemData) == false) {

                            var contrato = $("#ContractMercado").val();
                            if (contrato.indexOf($(itemData).attr("id")) < 0) {
                                $("#ContractMercado").val(contrato + "|" + $(itemData).attr("id"));
                            }

                            CheckMoneyContracts();

                            //Desactiva los contratos que son sincronizados
                            $.each($("#listContracts input[type=checkbox]"), function (index, itemSincry) {
                                if ($(itemSincry).attr("base").indexOf($(itemData).attr("id")) >= 0) {
                                    $(itemSincry).removeAttr("checked");
                                    $(itemSincry).attr("disabled", "disabled");

                                    var contrato = $("#ContractMercado").val().replace("|" + $(itemSincry).attr("id"), "");
                                    $("#ContractMercado").val(contrato);

                                    var sincro = $("#ContratoSincro").val();
                                    $("#ContratoSincro").val(sincro + "|" + $(itemSincry).attr("id"));
                                }
                            });
                        }
                    }
                    else { //SELECCIONA TODAS LAS HABITACIONES
                        $(itemData).attr("checked", true);
                        var nameCheck = $(itemData).attr("name");
                        $(".Inp_" + nameCheck).val("True");
                        //Bloqueo de Planes cuando se hace la seleccion de alguno
                        var checkboxs = $(".roomList input[type='checkbox']");
                        var checkChkd = $(".roomList input:checked");

                        var rp = $(itemData).attr("id").split("_");
                        var roomPlanchk = $("#roomPlanPromos").val();
                        var idCheck = $(itemData).attr("id");

                        //Muestra la tabla corresponidente al tipo de plan
                        $(".discountDetail h2").remove();
                        if (rp[rp.length - 1] == "EP" || rp[rp.length - 1] == "BI") {
                            $(".discountDetail .tableEP").show();
                        } else {
                            $(".discountDetail .table").show();
                        }

                        //Agrega la promocion seleccionada
                        $(".Inp_" + idCheck).val("True");
                        $("." + idCheck).show();
                        $("#roomPlanPromos").val(roomPlanchk + rp[1] + ",");
                    }
                });
            }
            else {

                if ($(checkAll).attr("id") == "AllContract") { //TODOS LOS CONTRATOS
                    $(checkRoom).removeAttr("checked");
                    $("#ContractMercado").val("");

                    //Desactiva los contratos que son sincronizados
                    $(checkRoom).attr("disabled", false);
                    $("#ContratoSincro").val("");

                    CheckMoneyContracts();
                }
                else {
                    $.each(checkRoom, function (index, itemData) {
                         //SELECCIONA TODAS LAS HABITACIONES
                            if ($(itemData).attr("disabled") != "disabled") {
                                $(itemData).removeAttr("checked");
                                var nameCheck = $(itemData).attr("name");
                                $(".Inp_" + nameCheck).val("False");

                                var rp = $(itemData).attr("id").split("_");
                                var roomPlanchk = $("#roomPlanPromos").val();
                                var idCheck = $(itemData).attr("id");

                                //desbloqueo de Planes cuando se hace la seleccion de alguno
                                var checkboxs = $(".roomList input[type='checkbox']");
                                var checkChkd = $(".roomList input:checked");
                                if (checkChkd.length == 0) {
                                    $(".discountDetail .tableEP,.discountDetail .table").hide();
                                    $(".discountDetail").append("<h2>@Resources.Dictionary.disSelectOneRoom</h2>")
                                    $.each(checkboxs, function (index, itemData) {
                                        $(this).removeAttr("disabled");
                                    });
                                }
                                $(".Inp_" + idCheck).val("False");
                                $("." + idCheck).hide();
                            }
                    });
                }
            }
        });





        /*Selecciona un contrato*/
        $("#listContracts input").click(function () {
            var InputChecked = $(this);

            if (InputChecked.is(":checked")) {
                var contrato = $("#ContractMercado").val();

                if (contrato.indexOf(InputChecked.attr("id")) < 0) {

                    if (CheckNotifContracts(this) == false) //Valida que el contrato tenga el mismo nofi q los demas seleccionados
                    {
                        //if (InputChecked.attr("id").indexOf("PDESTINO") > -1) {
                        //    $('.cancelPolicy').show();
                        //} else {
                        //    $('.cancelPolicy').hide();
                        //}
                    $("#ContractMercado").val(contrato + "|" + InputChecked.attr("id"));

                    //Desactiva los contratos que son sincronizados
                    $.each($("#listContracts input[type=checkbox]"), function (index, itemData) {
                        if ($(itemData).attr("base").indexOf(InputChecked.attr("id")) >= 0) {
                            $(itemData).removeAttr("checked");
                            $(itemData).attr("disabled", true);

                            var contrato = $("#ContractMercado").val().replace("|" + $(itemData).attr("id"), "");
                            $("#ContractMercado").val(contrato);

                            var sincro = $("#ContratoSincro").val();
                            $("#ContratoSincro").val(sincro + "|" + $(itemData).attr("id"));
                        }
                    });
                }
            }
                //Muestra u Oculta campos de Neta o Venta
                //alert($(".discountOptions input[type=radio]:checked").attr("id"));
                CamposNetaVentaTipoDescuento($(".discountOptions input[type=radio]:checked").attr("id"));

            }
            else {
                var contrato = $("#ContractMercado").val().replace("|" + InputChecked.attr("id"), "");
                $("#ContractMercado").val(contrato);

                //los contratos que son sincronizados
                $.each($("#listContracts input[type=checkbox]"), function (index, itemData) {
                    if ($(itemData).attr("base").indexOf(InputChecked.attr("id")) >= 0) {
                        $(itemData).removeAttr("disabled");
                        $(itemData).removeAttr("checked");

                        var sincro = $("#ContratoSincro").val().replace("|" + $(itemData).attr("id"), "");
                        $("#ContratoSincro").val(sincro);
                    }
                });

            }
            CheckMoneyContracts();
        });

        /*Checa moneda de los contratos sincronizados*/
        function CheckMoneyContracts() {
            var contratosCheck = $("#listContracts input:checked, #listContracts input:checked, #listContracts input:disabled");
            var dif = 0;

            var MonedaFirst = $(contratosCheck[0]).attr("mon");

            var contratos = 0;

            for (var i = 1; i <= contratosCheck.length - 1  ; i++) {
                if (!$(contratosCheck[i]).is(":disabled")) {
                    if (MonedaFirst != $(contratosCheck[i]).attr("mon") && dif == 0) {
                        dif = 1;
                    }
                    MonedaFirst = $(contratosCheck[i]).attr("mon");
                    contratos = contratos + 1;
                }
            }

            if (dif == 1) //Si los contratos son de moneda diferente
            {
                $(".discountOptions span:nth-child(2)").hide(); //Oculta Descuento tarifa especial
                $(".discountOptions span:nth-child(3)").hide(); //Oculta descuento por monto

                if ($(".discountOptions input[type=radio]:checked").attr("id") != "discPercentage") {
                    $(".tableRow .col input").val("%");
                    $(".discountOptions input[type=radio]").removeAttr("checked");
                    $(".tableRow .td .tMoneda").text("%");
                    $(".rtsPorcent").show();

                    $(".rtsMount").hide();
                    $(".rVenta").hide();


                    if ($("#PromoType").val().indexOf("DV_PE") >= 0 || $("#PromoType").val().indexOf("OF_PE") >= 0) {
                        alert("Los contratos seleccionados/sincronizados son de distinta moneda. Por favor seleccione otro tipo de descuento.");
                        $("#discount").seekAttention();
                    }

                    $("#PromoType").val($("#PromoType").val().replace("DV_PE|", ""));
                    $("#PromoType").val($("#PromoType").val().replace("OF_PE|", ""));
                }
            }
            else if (dif == 0 && contratos > 1) //Si son de la misma moneda y sea Multicontrato
            {
                $(".discountOptions span:nth-child(2)").hide(); //Oculta Descuento tarifa especial
                $(".discountOptions span:nth-child(3)").show();

                if ($(".discountOptions input[type=radio]:checked").attr("id") == "specialRate") {
                    $(".tableRow .col input").val("%");
                    $(".discountOptions input[type=radio]").removeAttr("checked");
                    $(".tableRow .td .tMoneda").text("%");
                    $(".rtsPorcent").show();

                    $(".rtsMount").hide();
                    $(".rVenta").hide();

                    if ($("#PromoType").val().indexOf("DV_PE") >= 0) {
                        alert("Por favor seleccione otro tipo de descuento.");
                        $("#discount").seekAttention();
                    }

                    $("#PromoType").val($("#PromoType").val().replace("DV_PE|", ""));
                }
            }
            else {
                $(".discountOptions span:nth-child(2)").show();
                $(".discountOptions span:nth-child(3)").show();
            }
        }

        /*Valida El tipo de notificacion de los contratos seleccionados*/
        function CheckNotifContracts(contract) {

            var notif = ($(contract).attr("notif") == "V" ? "V" : "N");

            var contratosCheck = $("#listContracts input:checked, #listContracts input:disabled");

            for (var i = 0; i <= contratosCheck.length - 1  ; i++) {
                var notifCheck = ($(contratosCheck[i]).attr("notif") == "V" ? "V" : "N");

                if (notif != notifCheck) {
                    alert("Los tipos de valores a ingresar son diferentes.");
                    $(contract).removeAttr("checked");
                    return true;
                }
            }
            return false;
        }
        //Seleccionar/Deseleccionar todas las habitaciones
       @* $("#AllRooms").click(function(){
            var checkRoom =$(".roomList input[type='checkbox']");

            if($(this).is(":checked"))
            {
                $.each(checkRoom, function (index, itemData) {
                    $(itemData).attr("checked",true);
                    var nameCheck = $(itemData).attr("name");
                    $(".Inp_"+nameCheck).val("True");
                    //Bloqueo de Planes cuando se hace la seleccion de alguno
                    var checkboxs = $(".roomList input[type='checkbox']");
                    var checkChkd = $(".roomList input:checked");

                    var rp = $(itemData).attr("id").split("_");
                    var roomPlanchk = $("#roomPlanPromos").val();
                    var idCheck =$(itemData).attr("id");

                    //Muestra la tabla corresponidente al tipo de plan
                    $(".discountDetail h2").remove();
                    if(rp[1] == "EP") {
                        $(".discountDetail .tableEP").show();
                    }else{
                        $(".discountDetail .table").show();
                    }

                    //Agrega la promocion seleccionada
                    $(".Inp_"+idCheck).val("True");
                    $("."+idCheck).show();
                    $("#roomPlanPromos").val(roomPlanchk+rp[1]+",");
                });
            }
            else
            {
                $.each(checkRoom, function (index, itemData) {
                    if ($(itemData).attr("disabled") != "disabled"){
                        $(itemData).removeAttr("checked");
                        var nameCheck = $(itemData).attr("name");
                        $(".Inp_"+nameCheck).val("False");

                        var rp = $(itemData).attr("id").split("_");
                        var roomPlanchk = $("#roomPlanPromos").val();
                        var idCheck =$(itemData).attr("id");

                        //desbloqueo de Planes cuando se hace la seleccion de alguno
                        var checkboxs = $(".roomList input[type='checkbox']");
                        var checkChkd = $(".roomList input:checked");
                        if (checkChkd.length == 0){
                            $(".discountDetail .tableEP,.discountDetail .table").hide();
                            $(".discountDetail").append("<h2>@Resources.Dictionary.disSelectOneRoom</h2>")
                            $.each(checkboxs, function (index, itemData) {
                                $(this).removeAttr("disabled");
                            });
                        }
                        $(".Inp_"+idCheck).val("False");
                        $("."+idCheck).hide();
                    }
                });
            }
        });*@

        //Muestra u oculta habitacion en la tabla de descuento.
        $(".roomList *").click(function(){
            if($(this).val() != "")
            {
                var rp = $(this).attr("id").split("_");
                var roomPlanchk = $("#roomPlanPromos").val();
                var idCheck =$(this).attr("id");
                if($(this).is(':checked'))
                {
                    //Bloqueo de Planes cuando se hace la seleccion de alguno
                    var checkboxs = $(".roomList input[type='checkbox']");
                    var checkChkd = $(".roomList input:checked");
                    $(".discountDetail h2").remove();
                    if (rp[rp.length - 1] == "EP" || rp[rp.length - 1] == "BI") {
                        $(".discountDetail .tableEP").show();
                    }else{
                        $(".discountDetail .table").show();
                    }

                    //Agrega la promocion seleccionada
                    $(".Inp_"+idCheck).val("True");
                    $("."+idCheck).show();
                    $("#roomPlanPromos").val(roomPlanchk+rp[1]+",");
                }
                else{
                    //desbloqueo de Planes cuando se hace la seleccion de alguno
                    var checkboxs = $(".roomList input[type='checkbox']");
                    var checkChkd = $(".roomList input:checked");
                    if (checkChkd.length == 0){
                        $(".discountDetail .tableEP,.discountDetail .table").hide();
                        $(".discountDetail").append("<h2>@Resources.Dictionary.disSelectOneRoom</h2>")
                        $.each(checkboxs, function (index, itemData) {
                            $(this).removeAttr("disabled");
                        });
                    }
                    $(".Inp_"+idCheck).val("False");
                    $("."+idCheck).hide();
                }

                //Habilita o deshabilita opcion de niños si
                var roomChk = $(".roomList input:checked");
                var EPyAI = 0;
                $.each(roomChk, function (index, itemData) {
                    if ($(itemData).attr("id").indexOf('_EP') < 0)
                    {
                        EPyAI += 1;
                    }
                });

                //Validaciones cuando solo se tenga seleccionada habitacion EP
                if (EPyAI == 0)
                {
                    $("#open_freeKids").hide();
                    $(".discountDetail .table").hide();
                    $("#Chck_promoType li").removeClass("active");
                    $("#open_freeNights").addClass("active");
                    $(".tabGroup .sectionBox ").hide();
                    $("#freeNights").show();
                }
                else
                {
                    $("#open_freeKids").show();
                }
            }
        });

        /* Seleccion de dias que aplica la promocion */
        $("#open_specificDate").click(function(){

            if ($(this).is(':checked')){
                var checked = $("#specificDate input[type='checkbox']");
                var bytes =BinToDec(checked);
                $("#Rate_Day").val(bytes);
            }
            else{
                $("#Rate_Day").val("127");
            }
        });

        $("#specificDate input[type='checkbox']").click(function(){
            var bytes = 0;
            var checked = $("#specificDate input[type='checkbox']");
            bytes =BinToDec(checked);
            $("#Rate_Day").val(bytes);
        });

        /* Seleccion de dias de llegada en que aplica la promocion */
        $("#open_specificArrivals").click(function(){
            if ($(this).is(':checked')){
                var checked = $("#specificArrivals input[type='checkbox']");
                var bytes =BinToDec(checked);
                $("#Arrivals_Day").val(bytes);
            }
            else{
                $("#Arrivals_Day").val("127");
            }
        });

        $("#specificArrivals input[type='checkbox']").click(function(){
            var bytes = 0;
            var checked = $("#specificArrivals input[type='checkbox']");
            bytes =BinToDec(checked);
            $("#Arrivals_Day").val(bytes);
        });

        //* Funcion que convierte de Binario a decimal*//
        function BinToDec(checked)
        {

            var bytes= 0;
            $.each(checked, function (index, itemData) {
                switch(index)
                {
                    case 0:
                        if ($(this).is(':checked'))
                            bytes += 1;
                    break;
                    case 1:
                        if ($(this).is(':checked'))
                            bytes += 2;
                    break;
                    case 2:
                        if ($(this).is(':checked'))
                            bytes += 4;
                    break;
                    case 3:
                        if ($(this).is(':checked'))
                            bytes += 8;
                    break;
                    case 4:
                        if ($(this).is(':checked'))
                            bytes += 16;
                    break;
                    case 5:
                        if ($(this).is(':checked'))
                            bytes += 32;
                    break;
                    case 6:
                        if ($(this).is(':checked'))
                            bytes += 64;
                    break;
                }
            });
            return bytes;
        }

        //*DESCUENTO  muestra u oculta campos necesarios*//
        $(".discountOptions input[type=radio]").click(function(){
            CamposNetaVentaTipoDescuento($(this).attr("id"));
        });

        function CamposNetaVentaTipoDescuento(IdTipoDescuento) {

            switch (IdTipoDescuento) {
                case "discPercentage": $(".col input[type=text]").val("%");
                    $(".tMoneda").text("%");
                    $(".rtsPorcent,.notif,.tMoneda").show();
                    $(".rVenta, .rtsMount").hide();
                    $(".checkRow").css("height", "18px");
                    $(".applyBtn").attr("lang", "%");
                    $(".tableRow .td").css("height", "18px");
                    $(".LblNoteTaxes").hide();

                break;
                case "specialRate": $(".col input[type=text]").val("$");

                    var notifContract = $("#listContracts input:checked:not(:disabled) ").first().attr("notif");
                    //alert(notifContract)//borrar
                    var isSUser = ("@Session("IsSuperUser")" == "True") ? 1 : 0;
                    $(".tMoneda").text($("#listContracts input:checked:not(:disabled) ").first().attr("mon"));
                    if (isSUser) {
                        $(".rVenta, .rtsMount,.notif,.tMoneda").show();
                        $(".checkRow").css("height", "35px");
                        $(".tableRow .td").css("height", "35px");
                    }
                    else {
                        if (notifContract != "V") {
                            //alert("muestro neta"); //borrar
                            $(".rVenta").hide();
                            $(".rtsMount").show();
                            $(".notif").text("N ");
                        }
                        else {
                            $(".rtsMount").hide();
                            $(".rVenta").show();
                            $(".notif").text("V ");
                        }

                        $(".checkRow").css("height", "18px");
                        $(".tableRow .td").css("height", "18px");
                    }
                    $(".applyBtn").attr("lang", "$");
                    $(".rtsPorcent").hide();
                    $(".LblNoteTaxes").show();
                break;
                case "discAmount": $(".col input[type=text]").val("$");

                    var notifContract = $("#listContracts input:checked:not(:disabled)").first().attr("notif");
                    //alert(notifContract)//borrar
                    var isSUser = ("@Session("IsSuperUser")" == "True") ? 1 : 0;
                    $(".tMoneda").text($("#listContracts input:checked:not(:disabled)").first().attr("mon"));
                    if (isSUser) {
                        $(".notif,.tMoneda").hide();
                        if (notifContract == 'V') {
                            $(".rVenta").show();

                            $(".rVenta .notif,.rVenta .tMoneda").show();
                            $(".rtsMount,.rtsPorcent").hide();

                        } else {

                            $(".notif,.tMoneda").show();
                            $(".rtsMount").show();
                            $(".rVenta,.rtsPorcent").hide();
                        }


                    }
                    else {
                        if (notifContract != "V") {
                            $(".rVenta").hide();
                            $(".rtsMount").show();
                            $(".notif").text("N ");
                        }
                        else {
                            $(".rtsMount").hide();
                            $(".rVenta").show();
                            $(".notif").text("V ");
                        }
                    }
                    $(".checkRow").css("height", "18px");
                    $(".applyBtn").attr("lang", "$");
                    $(".rtsPorcent").hide();
                    $(".tableRow .td").css("height", "18px");
                    $(".LblNoteTaxes").hide();
                break;
            }
        }

        //* Agregar fechas del blackOut*//
        $("#AddDateBlackout").click(function(){
            var FechaIni = $("#blackoutFrom").val();
            var FechaFin = $("#blackoutTo").val();
            var FechaIniTxt = $("#blackoutFromDate").val();
            var FechaFinTxt = $("#blackoutToDate").val();

            if ((FechaIni == "") && (FechaFin == "")) {
                    alert('@Html.Raw(Resources.Dictionary.disSinFechas)');
                    return;
                }
                else if ((FechaIni == "") || (FechaFin == "")) {
                    alert('@Html.Raw(Resources.Dictionary.disFaltaFecha)');
                    return;
                }
                else {
                    if (FechaIni > FechaFin) {
                        alert('@Html.Raw(Resources.Dictionary.disCheckNotExcDate)');
                        return;
                    }
                }
                var listDatesBlackOuts = $("#Dates_Blackout li");
                var band_Valida = true;
                var textdateBlackOut = FechaIni +"-"+ FechaFin;
                if(listDatesBlackOuts.length > 0)
                {
                    var daysBlackOut = $("#Dias_BlackOut").val();
                    $.each(listDatesBlackOuts, function (index, itemData) {
                        var liFrom = $(".blackFrom", this).attr("id");
                        var liTo = $(".blackTo", this).attr("id");
                        if (band_Valida) {
                            if ((FechaIni > liFrom && FechaIni > liTo) && FechaFin > liFrom && FechaFin > liTo) {
                                band_Valida = true;
                            }
                            else {
                                if (!((FechaIni >= liFrom) && (FechaIni <= liTo)) && !((FechaFin >= liFrom) && (FechaFin <= liTo))) {
                                    band_Valida = true;
                                } else {
                                    band_Valida = false;
                                    return;
                                }
                            }
                        }
                    });
                    if (!band_Valida){
                        alert("@Html.Raw(Resources.Dictionary.disFechasMismoRango)");
                    }
                    else{
                        $("#Dates_Blackout").append("<li class='willAdd'><span class='blackFrom' id='"+FechaIni+"'>"+FechaIniTxt+"</span> - <span class='blackTo' id='"+FechaFin+"'>"+FechaFinTxt+"</span><img class='removeRange' src='@Url.Content("~/Content/themes/base/images/remove.jpg")'><div class='hr'></div></li>");
                        $("#Dias_BlackOut").val(daysBlackOut +"|"+textdateBlackOut);
                    }
                }
                else{
                    $("#Dates_Blackout").append("<li class='willAdd'><span class='blackFrom' id='"+FechaIni+"'>"+FechaIniTxt+"</span> - <span class='blackTo' id='"+FechaFin+"'>"+FechaFinTxt+"</span><img class='removeRange' src='@Url.Content("~/Content/themes/base/images/remove.jpg")'><div class='hr'></div></li>");
                    $("#Dias_BlackOut").val(textdateBlackOut);
                }
                showRemoveAll();
        });

        //Elimina Fechas del BlackOut - De forma Individual
        $('.rangeSelectedBKO ul').on('click', 'li img', function () {

            var parentRange= $(this).parent();
            var liParent =parentRange.attr("class");

            var dateRangeText = $(this).parent().children(".blackFrom").text()+"-"+$(this).parent().children(".blackTo").text();

            var answer = confirm("¿@Resources.Dictionary.disConfirmRemoveRangeBlackOut: "+dateRangeText+"?");
            if (answer) {

                parentRange.remove();
                //Elimina el Html y remueve fecha
                var blackOutDates = $("#Dias_BlackOut").val().split("|");
                $("#Dias_BlackOut").val("");
                $.each(blackOutDates, function(item){
                    if(blackOutDates[item] != dateRangeText)
                    {
                        var textBlack = $("#Dias_BlackOut").val();
                        textBlack += blackOutDates[item]+"|";
                        $("#Dias_BlackOut").val(textBlack);
                    }
                });
                showRemoveAll();
            }
            return false;
        });
        @* $('.removeRange').click(function () {
            var parentRange= $(this).parent();
            var liParent =parentRange.attr("class");

            var dateRangeText = $(this).parent().children(".blackFrom").text()+"-"+$(this).parent().children(".blackTo").text();

            var answer = confirm("¿@Resources.Dictionary.disConfirmRemoveRangeBlackOut: "+dateRangeText+"?");
            if (answer){
                if(liParent == "blackOutAdded")
                {
                     var SelectRoomList = $(".roomList input:checked");
                     var roomsPlanChks= "";
                     $.each(SelectRoomList, function(item){
                        var rooom_plan = $(this).attr("id");
                        var classRoom= "."+rooom_plan;
                        if($(classRoom+" .checkRow input[type=hidden]").val() != "undefined"){
                            roomsPlanChks += $(classRoom+" .checkRow input[type=hidden]").val()+"|";
                        }
                     });
                    var travelStart = $("#travelStartDate").val();
                    var travelEnd = $("#travelEndDate").val();
                    $.ajax({
                        url: "DeleteDatesRange",
                         data: {
                            TravelIni: travelStart, TravelFin: travelEnd, DateBlackOut: dateRangeText, RoomsPlan: roomsPlanChks
                        },
                        type: "POST"
                    }).done(function() {
                        parentRange.remove();
                        //Elimina el Html y remueve fecha
                        var blackOutDates = $("#Dias_BlackOut").val().split("|");
                        $("#Dias_BlackOut").val("");
                        $.each(blackOutDates, function(item){
                            if(blackOutDates[item] != dateRangeText)
                            {
                                var textBlack = $("#Dias_BlackOut").val();
                                textBlack += blackOutDates[item]+"|";
                                $("#Dias_BlackOut").val(textBlack);
                            }
                        });
                    });
                }
                showRemoveAll();
            }
            return false;
        });*@


           $('.removeRange').click(function () {
               var parentRange = $(this).parent();
               var liParent = parentRange.attr("class");

               var dateRangeText = $(this).parent().children(".blackFrom").attr('id') + "-" + $(this).parent().children(".blackTo").attr('id');

               var answer = confirm("¿@Resources.Dictionary.disConfirmRemoveRangeBlackOut: " + dateRangeText + "?");
            if (answer) {
                if (liParent == "blackOutAdded") {
                    var SelectRoomList = $(".roomList input:checked");
                    var roomsPlanChks = "";
                    $.each(SelectRoomList, function (item) {
                        var rooom_plan = $(this).attr("id");
                        var classRoom = "." + rooom_plan;
                        if ($(classRoom + " .checkRow input[type=hidden]").val() != "undefined") {
                            roomsPlanChks += $(classRoom + " .checkRow input[type=hidden]").val() + "|";
                        }
                    });
                    var travelStart = $("#travelStartDate").val();
                    var travelEnd = $("#travelEndDate").val();
                    //$.ajax({
                    //    url: "DeleteDatesRange",
                    //    data: {
                    //        TravelIni: travelStart, TravelFin: travelEnd, DateBlackOut: dateRangeText, RoomsPlan: roomsPlanChks
                    //    },
                    //    type: "POST"
                    //}).done(function () {
                        parentRange.remove();
                        //Elimina el Html y remueve fecha
                        var blackOutDates = $("#Dias_BlackOut").val().split("|");
                        $("#Dias_BlackOut").val("");
                        $.each(blackOutDates, function (item) {

                            if (blackOutDates[item] != dateRangeText) {
                                var textBlack = $("#Dias_BlackOut").val();
                                textBlack += blackOutDates[item] + "|";
                                $("#Dias_BlackOut").val(textBlack);
                            }
                        });
                    //});
                }
                showRemoveAll();
            }
            return false;
        });

        //* Remueve fechas de la lista blackout*//
        function showRemoveAll(){
            if($("#Dates_Blackout li").length > 0){
                $(".deleteAll").show();
            }
            else {
                $(".deleteAll").hide();
                $("#Dias_BlackOut").val("");
            }
        }
        $(".deleteAll").click(function(e){
            e.preventDefault();
            var answer = confirm("¿@Resources.Dictionary.disConfirmRemoveBlackOut?");
            if (answer){
                var SelectRoomList = $(".roomList input:checked");
                var roomsPlanChks= "";
                $.each(SelectRoomList, function(item){
                   var rooom_plan = $(this).attr("id");
                   var classRoom= "."+rooom_plan;
                   if($(classRoom+" .checkRow input[type=hidden]").val() != "undefined"){
                   roomsPlanChks += $(classRoom+" .checkRow input[type=hidden]").val()+"|";
                   }
                });

                var DatesBlackOutList = $("#Dates_Blackout .blackOutAdded");
                var dateRangeText ="";
                $.each(DatesBlackOutList, function(item){
                   var blackOutesDates = $(".blackFrom", this).text()+"-"+ $(".blackTo", this).text();
                   dateRangeText += blackOutesDates+"|";
                });
                var travelStart = $("#travelStartDate").val();
                var travelEnd = $("#travelEndDate").val();

                if (DatesBlackOutList.length > 0){
                    $.ajax({
                        url: "DeleteDatesRange",
                         data: {
                            TravelIni: travelStart, TravelFin: travelEnd, DateBlackOut: dateRangeText, RoomsPlan: roomsPlanChks
                        },
                        type: "POST"
                    }).done(function() {
                        $("#Dates_Blackout").empty();
                        $("#Dias_BlackOut").val("");
                    });
                }
                else {
                    $("#Dates_Blackout").empty();
                    $("#Dias_BlackOut").val("");
                }
                //alert("remove all");
                showRemoveAll();
            }
            return false;
        });

        /*seleccionalos  dias de vigencia de la promocion*/
        $("#booking_specificDates").click(function () {
            if ($(this).is(':checked')) {
                var checked = $("#specificDates input[type='checkbox']");
                var bytes = BinToDec(checked);
                $("#Booking_Dias").val(bytes);
            }
            else {
                $("#Booking_Dias").val("127");
            }
        });

        $("#specificDates input[type='checkbox']").click(function () {
            var bytes = 0;
            var checked = $("#specificDates input[type='checkbox']");
            bytes = BinToDec(checked);
            $("#Booking_Dias").val(bytes);
        });

        $("#discount input[type=radio]").click(function(){
           var radio_Type = $("#discount input[type=radio]");
           var tipos_Promo = $("#PromoType").val();
           $.each(radio_Type, function (index, itemData) {
               if ($(this).is(":checked")){
                   if (tipos_Promo.indexOf($(this).val()) < 0) {
                       tipos_Promo = tipos_Promo + $(this).val() + "|";
                       $("#PromoType").val(tipos_Promo);
                   }
               }
               else{
                    var arr_tipoPromos = tipos_Promo.split("|");
                    tipos_Promo = "";
                    for(var i = 0; i <arr_tipoPromos.length; i++ )
                    {
                        if (arr_tipoPromos[i] != "" && arr_tipoPromos[i]!= $(this).val())
                        {
                            tipos_Promo += arr_tipoPromos[i] + "|";
                        }
                    }
                    $("#PromoType").val(tipos_Promo);
               }
           });
        });

        //* Checked *//
        $(".chk_All").click(function(){

            if ($(this).is(":checked"))
            {
                $(".checkRow input[type=checkbox]").attr("checked","checked");
            }
            else{
                $(".checkRow input[type=checkbox]").removeAttr("checked");
            }
        });
        var validationRate;
        //Aplica mark up
        $(".rtsMount").blur(function () {

            if ($("#discount input[type=radio]:checked").val() == "DV_PE") {
                if ($(this).attr("oldvalue") != $(this).attr("value")) {

                    var floatValue = Globalize.parseFloat($(this).val());

                    if (!jQuery.isNumeric(floatValue)) {
                        alert('@Html.Raw(Resources.Dictionary.disValNumericValid)');
                        $(this).attr("value", "");
                        $(this).focus();
                        return false;
                    }

                    if (floatValue < 0) {
                        alert('@Html.Raw(Resources.Dictionary.DisNumMayorCero)');
                        $(this).attr("value", "");
                        $(this).focus();
                        return false;
                    }

                    if (floatValue != 0) {

                        var headFieldName = $(this).attr("id");
                        if (headFieldName.indexOf('Ninos') == -1 && headFieldName.indexOf('Junior') == -1) {

                             validationRate = ValidateRateMinMaxPromo(floatValue, "N")

                        } else {
                            validationRate = 'OK';
                        }


                        if (validationRate == 'FAIL') {
                            var OldValue = ($(this).attr("oldvalue") != undefined ? $(this).attr("oldvalue") : 0);
                            $(this).attr("value", OldValue);
                            $(this).focus();
                            return false;
                        }




                        if (validationRate != 'FAIL') {

                            var floatValue = Globalize.format($(this).val());

                            var parentV = $(this).parent();
                            var neta = Globalize.parseFloat($(this).val());

                            var mark = Globalize.parseFloat($("#MarkUp_DV_PE").val()) / 100;
                            var WithMkUp = (neta) / (1 - mark);

                            if (validationRate == 'DIF') {
                                var validationRate = ValidateRateMinMaxPromo(WithMkUp, "V")
                            }
                            if (validationRate == 'OK') {
                                $(this).attr("oldvalue", Globalize.format($(this).val(), "n4"));
                                $(this).attr("value", Globalize.format(neta, "n4"));

                                $(".rtsVent", parentV).attr("oldvalue", Globalize.format($(".rtsVent", parentV).val(), "n4"));
                                $(".rtsVent", parentV).val(Globalize.format(WithMkUp, "n4"));

                                $(".rtsVent", parentV).addClass("InputModifiedVent");
                                $(this).addClass("InputModified");
                            } else {

                                var OldValue = ($(this).attr("oldvalue") != undefined ? $(this).attr("oldvalue") : 0);
                                $(this).attr("value", OldValue);
                                $(this).focus();
                                return false;
                            }
                        }
                    }
                }
            }
        });

        $(".rtsVent").blur(function(){

            if ($("#discount input[type=radio]:checked").val()== "DV_PE")
            {
                if ($(this).attr("oldvalue") != $(this).attr("value")) {

                    var floatValue = Globalize.parseFloat($(this).val());

                    if (!jQuery.isNumeric(floatValue)) {
                        alert('@Html.Raw(Resources.Dictionary.disValNumericValid)');
                        $(this).attr("value", "");
                        $(this).focus();
                        return false;
                    }

                    if (floatValue < 0) {
                        alert('@Html.Raw(Resources.Dictionary.DisNumMayorCero)');
                        $(this).attr("value", "");
                        $(this).focus();
                        return false;
                    }

                    if (floatValue != 0) {

                        var headFieldName = $(this).attr("id");
                        if (headFieldName.indexOf('Ninos') == -1 && headFieldName.indexOf('Junior') == -1) {

                             validationRate = ValidateRateMinMaxPromo(floatValue, "V")
                        } else {
                            validationRate = 'OK';
                        }
                        if (validationRate == 'FAIL') {

                            var OldValue = ($(this).attr("oldvalue") != undefined ? $(this).attr("oldvalue") : 0);
                            $(this).attr("value", OldValue);
                            $(this).focus();
                            return false;
                        }


                        if (validationRate != 'FAIL') {

                            var floatValue = Globalize.parseFloat($(this).val());
                            //'roomRates_0__Double_Venta

                            var inputParentN = $(this).parent().parent();
                            var venta = Globalize.parseFloat($(this).val());

                            var mark = Globalize.parseFloat($("#MarkUp_DV_PE").val()) / 100;
                            var TarNeta = venta * (1 - (mark));

                            if (validationRate == 'DIF') {
                                var validationRate = ValidateRateMinMaxPromo(TarNeta, "N")
                            }
                            //Venta
                            if (validationRate == 'OK') {
                                $(this).attr("oldvalue", Globalize.format($(this).val(), "n4"));
                                //$(this).attr("value",Globalize.format(venta, "n4"));

                                //Neta
                                $(".rtsMount", inputParentN).attr("oldvalue", Globalize.format($(".rtsMount", inputParentN).val(), "n4"));
                                $(".rtsMount", inputParentN).val(Globalize.format(TarNeta, "n4"));

                                $(".rtsMount", inputParentN).addClass("InputModified");
                                $(this).addClass("InputModifiedVent");
                            } else {
                                var OldValue = ($(this).attr("oldvalue") != undefined ? $(this).attr("oldvalue") : 0);
                                $(this).attr("value", OldValue);
                                $(this).focus();
                                return false;

                            }
                        }
                    }
                }
            }
        });


        $(".rtsPorcent").blur(function () {
            if ($("#discount input[type=radio]:checked").val() == "OF_PO") {

                if ($(this).attr("oldvalue") != $(this).attr("value")) {

                    var floatValue = Globalize.parseFloat($(this).val());

                    if (!$(this).hasClass("rtsPorcent pChild") && !$(this).hasClass("rtsPorcent pJunior")) {
                        if (floatValue <= 0 || floatValue > 70) {
                            alert('@Html.Raw(Resources.Dictionary.disMargenEntre)');
                            $(this).focus();
                            $(this).attr("value", "0");
                            return false;
                        }
                    }
                    else {
                        if (floatValue < 0 || floatValue > 100) {
                            alert('@Html.Raw(Resources.Dictionary.disMargenEntrechjr)');
                            $(this).focus();
                            $(this).attr("value", "0");
                            return false;
                        }
                    }
                }
            }
        });

        $("#btnSetMarkUp").click(function(){
            var mark = Globalize.parseFloat($("#MarkUp_DV_PE").val())/100;
            var disc_Type = $("#discount input[type=radio]:checked").val();
            if (disc_Type == "DV_PE"){
                var divsDiscount = $(".discountDetail .rowRates");
                $.each(divsDiscount, function (index, itemData) {
                    if($(itemData).is(':visible'))
                    {
                        var inputPromo = $("input", itemData)
                        $.each(inputPromo, function(index,inputData){
                            var oldValue = 0;
                            if($(inputData).val() != ""){ oldValue= Globalize.parseFloat($(inputData).val());}
                            if($(inputData).hasClass("rtsMount") && Globalize.parseFloat($(inputData).val()) > 0)
                            {
                                $(inputData).attr("oldvalue",oldValue);
                                var WithMkUp =  (Globalize.parseFloat($(inputData).val()))/(1-mark);
                                var parentV = $(inputData).parent();
                                $(".rtsVent", parentV).val(Globalize.format(WithMkUp, "n4"));
                                $(inputData).addClass("InputModified");
                                $(".rtsVent", parentV).addClass("InputModifiedVent");
                            }
                        });
                    }
                });
            }
        });


        var StatusValidate;

        function ValidateRateMinMaxPromo(RateTyped, Type) {


            var min = parseFloat($("#listContracts input:checked").first().attr("tarmin"));
            var max = parseFloat($("#listContracts input:checked").first().attr("tarmax"));
            var TypeNotif = ('@notif_Type' == "V" ? "V" : "N");

            if (TypeNotif != "V") {
                TypeNotif = 'N'
            }

            if (TypeNotif == Type) {

                var disc_Type = $("#discount input[type=radio]:checked").val();

                if (disc_Type == "DV_PE") {


                    if (RateTyped < min && min != 0) {
                        alert('@Resources.Dictionary.disMsgRateMin ' + min.toFixed(2) + ' @Resources.Dictionary.disMsgAnd ' + max.toFixed(2));

                        return "FAIL";
                    } else if (RateTyped > max && max != 0) {
                        alert('@Resources.Dictionary.disMsgRateMax ' + min.toFixed(2) + ' @Resources.Dictionary.disMsgAnd ' + max.toFixed(2));

                        return "FAIL";
                    } else {

                        return "OK";
                    }

                } else {

                    return "OK";
                }

            } else {
                return "DIF";
            }
        }

        /* Aplica el monto o descuento a las filas seleccionadas*/
        $(".applyBtn").click(function () {

            var headFieldName = $(this).attr("id");
            var typeDiscount =$(this).attr("lang");
            var headValue = ValidateHeadValue(headFieldName);
            if (headValue == "") {
                 return;
            }

            var TypoNo0tif = ('@notif_Type' == "V" ? "V" : "N");

            var headFieldName = $(this).attr("id");
            if (headFieldName.indexOf('Ninos') == -1 && headFieldName.indexOf('Junior') == -1) {
                var validationRate = ValidateRateMinMaxPromo(headValue, TypoNo0tif)
                if (validationRate == 'FAIL') {
                    return;
                }
            }
            /*SI SE TIENE SELECCIONADA UN HABITACION PARA MODIFICAR*/
            if ($(".discountDetail input:checked").length > 0)
            {
                var checkeds = $(".discountDetail input:checked");
                $.each(checkeds, function (index, itemData) {
                    var idChk = $(itemData).attr("id");
                    if (typeof idChk != 'undefined'){
                        var colDiscount ="";
                        switch(headFieldName)
                        {
                            case "btnSetDisRate": colDiscount = "rr";
                            break;
                            case "btnSetDisExtra": colDiscount = "ep";
                            break;
                            case "btnSetSingleRate": colDiscount = "sgl";
                            break;
                            case "btnSetDblRate": colDiscount = "dbl";
                            break;
                            case "btnSetTrlRate": colDiscount = "trl";
                            break;
                            case "btnSetCuadRate":colDiscount = "cuad";
                            break;
                            case "btnSetNinosRate": colDiscount = "ch211";
                            break;
                            case "btnSetJuniorRate": colDiscount = "jr";
                            break;
                        }
                        //Aplica aplica  alas celdas de acuerdo a la columna seleccionada.
                        applyDiscout(itemData,headValue, colDiscount);
                    }
                });
            }
            else {
                alert("@Html.Raw(Resources.Dictionary.disPleaseSelectRoomApplyRate)");
            }
    });


    /*Aplica los cambios en las celdas*/
    function applyDiscout(itemData,headValue, colDiscount)
    {
        //Se obtiene los inputs que estan dentro de la fila seleccionada filtrando por la columna.
        var idRow = $(itemData).attr("id").split("chk");
        var inputsCeldas = $("."+colDiscount+idRow[1]+" input");
        var fValue = Globalize.parseFloat(Globalize.format(headValue, "n4"));//$("#Head_DisRate").val(); //Nuevo valor
        $.each(inputsCeldas, function (index, inputData) {
            var newValue= 0;
		    var oldValue = 0;
		    if($(inputData).val() != ""){ oldValue= Globalize.parseFloat($(inputData).val());}
            //Dependiendo de la promocion seleccionada
            var disc_Type = $("#discount input[type=radio]:checked").val();
            if (disc_Type == "OF_PO"){
                if($(inputData).hasClass("rtsPorcent")){
                    $(inputData).attr("oldvalue",oldValue);
                    $(inputData).val(Globalize.format(fValue, "n4"));
                    $(inputData).css("background","#E1F5A9");
                    $(inputData).css("font-weight","bold");
                }
            }
            else if (disc_Type== "DV_PE"){
                var isSUser = ("@Session("IsSuperUser")" == "True")? 1:0;
                if (isSUser){
                    if ("@notif_Type" !="V"){
                        if($(inputData).hasClass("rtsMount"))
                        {
                            $(inputData).attr("oldvalue",oldValue);
                            $(inputData).val(Globalize.format(fValue, "n4"));
                            //$(inputData).val(Globalize.format(fValue, "n4"));
                            $(inputData).css("background","#E1F5A9");
                            $(inputData).css("font-weight","bold");
                        }
                        else if($(inputData).hasClass("rtsVent"))
                        {
                            var mark = Globalize.parseFloat($("#MarkUp_DV_PE").val())/100;
                            var WithMkUp =  (fValue)/(1-mark);

                            $(inputData).val(Globalize.format(WithMkUp, "n4"));
                            //$(inputData).val(Globalize.format(WithMkUp, "n4"));
                            $(inputData).css("background","#FFFFCC");
                            $(inputData).css("font-weight","bold");
                        }
                    }
                    else{
                        if($(inputData).hasClass("rtsMount"))
                        {
                            var mark = Globalize.parseFloat($("#MarkUp_DV_PE").val())/100;
                            var WithMkUp =  (fValue)* (1 - (mark));

                            $(inputData).val(Globalize.format(WithMkUp, "n4"));
                            //$(inputData).val(Globalize.format(WithMkUp, "n4"));
                            $(inputData).css("background","#E1F5A9");
                            $(inputData).css("font-weight","bold");
                        }
                        else if($(inputData).hasClass("rtsVent"))
                        {

                            $(inputData).attr("oldvalue",oldValue);
                            $(inputData).val(Globalize.format(fValue, "n4"));
                            //$(inputData).val(Globalize.format(fValue, "n4"));
                            $(inputData).css("background","#FFFFCC");
                            $(inputData).css("font-weight","bold");
                        }
                    }
                }
                else{
                        $(inputData).attr("oldvalue",oldValue);
                        $(inputData).val(Globalize.format(fValue, "n4"));
                        $(inputData).css("background","#E1F5A9");
                        $(inputData).css("font-weight","bold");
                }

            }
            else if (disc_Type == "OF_PE")
            {
                var isSUser = ("@Session("IsSuperUser")" == "True")? 1:0;
                if (isSUser) {

                    var AplicaNeta = ("@notif_Type" == "V") ? "rtsVent" : "rtsMount";
                    if ($(inputData).hasClass("" + AplicaNeta + "")) {
                        $(inputData).attr("oldvalue",oldValue);
                        $(inputData).val(Globalize.format(fValue, "n4"));
                        $(inputData).css("background","#E1F5A9");
                        $(inputData).css("font-weight","bold");
                    }
                }
                else
                {
                   $(inputData).attr("oldvalue",oldValue);
                   $(inputData).val(Globalize.format(fValue, "n4"));
                   $(inputData).css("background","#E1F5A9");
                   $(inputData).css("font-weight","bold");
                }
            }
        });
    }

	function ValidateHeadValue(headFieldName)
    {
        var typeDiscount = $("#"+headFieldName).attr("lang");
            var headFieldId = "";

            /*Validacion para aplicar el descuento.*/
            if (headFieldName == "btnSetDisRate") {
                headFieldId = "Head_DisRate";
            }
            else if (headFieldName == "btnSetDisExtra") {
                headFieldId = "Head_DisExtra";
            }
            else if (headFieldName == "btnSetSingleRate") {
                headFieldId = "Head_Single";
            }
            else if (headFieldName == "btnSetDblRate") {
                headFieldId = "Head_Dbl";
            }
            else if (headFieldName == "btnSetTrlRate") {
                headFieldId = "Head_Trl";
            }
            else if (headFieldName == "btnSetCuadRate") {
                headFieldId = "Head_Cuad";
            }
            else if (headFieldName == "btnSetNinosRate") {
                headFieldId = "Head_Ninos";
            }
            else if (headFieldName == "btnSetJuniorRate") {
                headFieldId = "Head_Junior";
            }

            var returnValue = "";
            var headValue = $("#" + headFieldId).val();
            headValue = jQuery.trim(headValue);
            if (typeof headValue == 'undefined') {
                alert('@Html.Raw(Resources.Dictionary.disValNoValido)');
                $("#" + headFieldId).attr("value", "");
                $("#" + headFieldId).focus();
                return returnValue;
            }
            if (headValue == '') {
                alert('@Html.Raw(Resources.Dictionary.disValNumeric)');
                $("#" + headFieldId).attr("value", "");
                $("#" + headFieldId).focus();
                return returnValue;
            }

            var floatValue = Globalize.parseFloat(headValue);

            if (!jQuery.isNumeric(floatValue)) {
                alert('@Html.Raw(Resources.Dictionary.disValNumericValid)');
                $("#" + headFieldId).attr("value", "");
                $("#" + headFieldId).focus();
                return returnValue;
            }

            if (floatValue < 0) {
                alert('@Html.Raw(Resources.Dictionary.DisNumMayorCero)');
                $("#" + headFieldId).attr("value", "");
                $("#" + headFieldId).focus();
                return returnValue;
            }


            if (typeDiscount == "%")
            {
                if (floatValue > 100 || floatValue < 1) {
                    alert('@Html.Raw(Resources.Dictionary.disMargenEntre)');
                    $("#" + headFieldId).attr("value", "");
                    $("#" + headFieldId).focus();
                    return returnValue;
                }
            }
            else if (floatValue == 0) {

                alert('@Html.Raw(Resources.Dictionary.disDivCero)');
                $("#" + headFieldId).attr("value", "");
                $("#" + headFieldId).focus();
                return returnValue;
            }
            return floatValue;
    }
        $("#freeLastNight").click(function () {
            if ($(this).is(':checked')) {
                $("#Ultima_Gratis").val("True");
                $("#FreeNight").val("0");
                $("#FreeNight").attr("disabled", "disabled");
            }
            else {
                $("#Ultima_Gratis").val("False");
                $("#FreeNight").removeAttr("disabled");
            }
    });

    $("#combinePromo").click(function(){
        if($(this).is(':checked')){
            $("#Combinable").val("True");}
        else{
            $("#Combinable").val("False");}
    });

    //Limpia valores de objetos tipo input para el tab noches gratis - tsp
      $("#Free_Night").click(function () {
        if (!$(this).is(':checked')) {
          $("#Acumulable").val("0");
          $("#FreeNight").val("0");
          $("#Noche_Gratis").val("0");  
          $("#andNights").removeAttr("checked"); 
          $("#Acumulable2").val("0");
          $("#Noche_Gratis2").val("0");
          $("#freeLastNight").removeAttr("checked");
          $("#Ultima_Gratis").val("False");          
        }
      });

   //Limpia valores de objetos tipo input con el evento de click de andNights - tsp
      $("#andNights").click(function () {
        if (!$(this).is(':checked')) { 
          $("#Acumulable2").val("0");
          $("#Noche_Gratis2").val("0");       
        }
      });



    /*Validaciones*/
    $("#btnPreviewChangesY").click(function(){
        $("#ac").val("pr");
        return validation();

    });

    $("#btnSaveChangesY").click(function(){
        $("#ac").val("ap");
        return validation();
    });



    function validation() {
        function remove_accent(str) { var map = { 'Á': 'A', 'É': 'E', 'Í': 'I', 'Ó': 'O', 'Ú': 'U', 'á': 'a', 'é': 'e', 'í': 'i', 'ó': 'o', 'ú': 'u' }; var res = ''; for (var i = 0; i < str.length; i++) { c = str.charAt(i); res += map[c] || c; } return res; }
        $("#Nombre").val(remove_accent($("#Nombre").val()));

        //Nombre de la promo
        if ($.trim($("#Nombre").val()) == "") {
            alert("@Html.Raw(Resources.Dictionary.disPleasePromoName)");
            $("#Nombre").seekAttention();
            $("#Nombre").val("");
            return false;
        } else {
            var regexp = /[|^-]/;
            if (regexp.test($("#Nombre").val())) {

                alert("@Html.Raw(Resources.Dictionary.NotspecialCaracters)");
                    $("#Nombre").seekAttention();
                    return false;
        }
            }
        //Contratos
        if ($(".contractList input:checked").length == 0) {
            alert("@Html.Raw(Resources.Dictionary.disSelectContract)");
                $(".contractList").seekAttention();
                return false;
            }
        //Cuartos
        if ($(".roomList input:checked").length == 0)
        {
            alert("@Html.Raw(Resources.Dictionary.disSelectOneRoom)");
            $(".roomList").seekAttention();
            return false;
        }

        //Travel
        if($("#txt_travelStartDate").attr("value") == "" || $("#txt_travelEndDate").attr("value")== ""){
            alert("@Html.Raw(Resources.Dictionary.disPleaseValidCharacters)");

            if ($("#txt_travelStartDate").attr("value") == "") {$("#txt_travelStartDate").seekAttention();}
            else {$("#txt_travelEndDate").seekAttention();}

            return false;
        }
        //Booking
        if ($("input[name=Type_Booking]:checked").val() == "D") {
            var minDays = $("#bookingMinDays").val();
            var maxDays = $("#bookingMaxDays").val();
            if (minDays == "" || maxDays == "") {
                alert("@Html.Raw(Resources.Dictionary.disPleaseValidCharacters)");
                if (minDays == "") { $("#bookingMinDays").seekAttention(); }
                else { $("#bookingMaxDays").seekAttention(); }
                return false;
            }

            if (maxDays > maxDaysAllowed) {
                 alert("@Html.Raw(Resources.Dictionary.promoMaxAnticipated)");
                 $("#bookingMaxDays").seekAttention();
                return false;
            } 
        }
        else if ($("input[name=Type_Booking]:checked").val() == "T") {
            if ($("#txt_bookingFromDate").attr("value") == "" || $("#txt_bookingToDate").attr("value") == "") {
                alert("@Html.Raw(Resources.Dictionary.disPleaseValidCharacters)");

                if ($("#txt_bookingFromDate").attr("value") == "") { $("#txt_bookingFromDate").seekAttention(); }
                else { $("#txt_bookingToDate").seekAttention(); }

                return false;
            }

            if ($("#Codigo_Promo").val() == "24HORAS"){
                alert("@Html.Raw(Resources.Dictionary.Faild24Hrs)");
                $("#Codigo_Promo, .bookingOption").seekAttention();
                return false;
            }

        }
        else if ($("input[name=Type_Booking]:checked").val() == "T24") {
            if ($("#FechasSeleccionadas").attr("value") == "") {
                alert("@Html.Raw(Resources.Dictionary.disPleaseValidCharacters)");
                $("#24Booking").seekAttention();
                return false;
            }else{
                var FechaSeleccionada = $("#FechasSeleccionadas").val();
                var Temporadainicial = $("#travelStartDate").val();
                var Temporadafinal = $("#travelEndDate").val();

                if (FechaSeleccionada >  Temporadafinal){
                    alert("El Travel Window debe ser mayor a la fecha de Booking");
                    $(".travelWindow").seekAttention();
                    return false;
                }

                var aFecha1 = Temporadainicial.split('/');
                var aFecha2 = Temporadafinal.split('/');
                var fFecha1 = Date.UTC(aFecha1[0],aFecha1[1]-1,aFecha1[2]);
                var fFecha2 = Date.UTC(aFecha2[0],aFecha2[1]-1,aFecha2[2]);
                var dif = fFecha2 - fFecha1;
                var dias = Math.floor(dif / (1000 * 60 * 60 * 24));

                if (dias < 15){
                    alert("El periodo del Travel Window debe ser mayor de 15 dias");
                    $(".travelWindow").seekAttention();
                    return false;
                }
            }

            $("#Codigo_Promo").val ("24HORAS");

        }

        /*Especifica las horas de vigencia de la promocion*/
        if (!$("#open_specificHours").is(":Checked")) {
            $('#specificHours option:selected').removeAttr("selected")
            $('#HoursWindowsDe option[value=00]').attr('selected', 'selected');
            $('#MinutesWindowsDe option[value=00]').attr('selected', 'selected');
            $('#HoursWindowsA option[value=23]').attr('selected', 'selected');
            $('#MinutesWindowsA option[value=59]').attr('selected', 'selected');
        }

        if ($("#Chck_promoType input:checked").length == 0)
        {
            alert("@Html.Raw(Resources.Dictionary.disPleaseSelectPromos)");
            $("#Chck_promoType").seekAttention();
            return false;
        }
        //Add Value
        if ($("#Add_Value").is(":Checked")) {
            var ban = true
            var textAddValue = $("#addValue textarea");
            var camposVacio = textAddValue.length;
            var caracteresEspeciales = 0;
            $.each(textAddValue, function (index, itemData) {
                var text = $(itemData).val();
                if ($.trim(text) == "") {
                    ban = false;
                    camposVacio = camposVacio - 1;
                }

                var regexp = /[|^-]/;
                if (regexp.test(text)) {
                    caracteresEspeciales = 1;
                }
            });
            if (camposVacio == 0) {
                alert("@Html.Raw(Resources.Dictionary.disInsertPromoText)");
                $("#addValue .tabGroup").seekAttention();
                return false;
            } else if (camposVacio < textAddValue.length) {
                alert("@Html.Raw(Resources.Dictionary.disTraslateOtherLanguaje)");
                    $("#addValue .tabContent:visible .addSubmit").seekAttention();
                    return false;
                } else if (caracteresEspeciales == 1) {
                    alert("@Html.Raw(Resources.Dictionary.NotspecialCaracters)");
                    $("#addValue .tabGroup").seekAttention();
                    return false;
            }
        }
        //Noche Gratis
        if($("#Free_Night").is(":checked"))
        {
            if ($("#FreeNight").val() <= 0 && !$("#freeLastNight").is(":checked")) {
                alert("@Html.Raw(Resources.Dictionary.disPleaseValidCharacters)");
                $("#FreeNight").seekAttention();
                return false;
            } else if ($("#FreeNight").val() == 1) {
                alert("El valor asignado debe ser mayor de una noche.");
                $("#FreeNight").seekAttention();
                return false;
             }

            if ($("#andNights").is(":Checked") && $("#Noche_Gratis2").val() <= 0 && !$("#freeLastNight").is(":checked")) {
                alert("@Html.Raw(Resources.Dictionary.disPleaseValidCharacters)");
                $("#Noche_Gratis2").seekAttention();
                return false;
            } else if ($("#andNights").is(":Checked") && $("#Noche_Gratis2").val() == 1) {
                alert("El valor asignado debe ser mayor de una noche.");
                $("#Noche_Gratis2").seekAttention();
                return false;
            }

            //tsp
            if ($("#andNights").is(":Checked") && ($('#FreeNight').val() !== "" & $('#Noche_Gratis2').val() !== ""))
            {
              if ($('#FreeNight').val() > $('#Noche_Gratis2').val())
              {
                   alert("@Html.Raw(Resources.Dictionary.disFreeNightsValidation)");
                   $("#FreeNight").seekAttention();
                   return false;
              }
            }

            //Si no es MM y selecciona FN no es combinable la promo
            if ("@(Session("IsSuperUser"))" == "False") {
                $("#Combinable").val("False");
            }
        }
        else {
          $("#Acumulable").val("0");
          $("#Noche_Gratis").val("0");  // tsp:se usa?
          $("#andNights").removeAttr("checked"); // tsp: se agrega
          $("#Acumulable2").val("0");
          $("#Noche_Gratis2").val("0");
          $("#freeLastNight").removeAttr("checked");
          $("#Ultima_Gratis").val("False");
        }

        //Descuento
        if($("#Discount").is(":checked"))
        {
            if ($(".discountOptions input:radio:checked").length == 0)
            {
                alert("@Html.Raw(Resources.Dictionary.disSelectDiscountRate)");
                $("#discount .discountOptions").seekAttention();
                return false;
            }
            else{
                var roomChecked = $(".roomList input:checked");
                var inputsroomsZero = 0;
                var advertenciaEPcero = 0
                $.each(roomChecked, function (index, checkboxRooms) {
                     var idRow = $(checkboxRooms).attr("id"); //Habitacion
                     var discontType = $(".discountOptions input:radio:checked").attr("id");
                     var classInput = "";
                     var classInputVenta = "";
                     switch(discontType)
                     {
                        case "discPercentage": classInput = "rtsPorcent";
                        break;
                        case "specialRate":
                             var notifContract = $("#listContracts input:checked").first().attr("notif");
                            var isSUser = ("@Session("IsSuperUser")" == "True")? 1:0;
                             if (isSUser || notifContract != "V") {
                                classInput = "rtsMount";
                            }
                            else {
                                classInput = "rtsVent";
                            }
                            classInputVenta = "rtsVent";
                        break;
                        case "discAmount":
                            var notifContract = $("#listContracts input:checked").first().attr("notif");
                            var isSUser = ("@Session("IsSuperUser")" == "True") ? 1 : 0;
                            if (notifContract != "V") {
                                classInput = "rtsMount";
                            }
                            else {
                                classInput = "rtsVent";
                            }
                        break;
                     }
                    var inputsValue = $("."+idRow+" ."+classInput);
                    var inpLength = inputsValue.length;
                     var isZero = 0;
                     $.each(inputsValue, function (index, inputValue) {
                         var parentInput = $(inputValue).parents().attr("class");
                         parentInput = (parentInput == "rVenta") ? $(inputValue).parents().parents().attr("class") : parentInput;
                         if (parentInput.indexOf("jr") < 0 && parentInput.indexOf("ch") < 0 && parentInput.indexOf("ep") < 0) {

                             if (isZero < inputsValue.length) {
                                 if (discontType == "specialRate") {
                                     if (Globalize.parseFloat($(inputValue).val()) == 0) {
                                         isZero += 1
                                     }
                                 } else if (parentInput.indexOf("rr") > 0) {
                                     if (Globalize.parseFloat($(inputValue).val()) == 0) {
                                         isZero += 1
                                     }
                                 }
                             }
                         }
                         else if (parentInput.indexOf("ep") > 0) {
                             if (Globalize.parseFloat($(inputValue).val()) == 0) {
                                 advertenciaEPcero += 1
                             }
                         }
                         else {
                             if (Globalize.parseFloat($(inputValue).val()) == 0) //Si la tarifa del niño es 0
                             {
                                 inpLength = inpLength - 1;
                             }
                         }
                     });

                     if (isZero > "0") {
                         inputsroomsZero += 1;
                     }

                     else {
                         if (isZero == inpLength) {
                             inputsroomsZero += 1;
                         }
                     }
                });
                if (inputsroomsZero > "0")
                {
                    alert("@Html.Raw(Resources.Dictionary.disPleaseValidCharacters)");
                    $("#discount .discountDetail").seekAttention();
                    return false;
                }
                if (advertenciaEPcero > "0") {
                    var answer = confirm("@Html.Raw(Resources.Dictionary.rateextraperson)");
                    if (answer) {
                        return true;
                    }
                    else {
                        $("#discount .discountDetail").seekAttention();
                        return false;

                    }
                }
            }
        }

        //Dias de Descuento
        if ($("#open_DaysDiscount").is(":checked")) {

            if ($("#NochesDescuento").val() <= 0) {
                alert("@Html.Raw(Resources.Dictionary.disPleaseValidCharacters)");
                $("#NochesDescuento").seekAttention();
                 return false;
             }

            if ($("#andNightsDescuento").is(":Checked") && $("#NochesDescuento2").val() <= 0) {
                 alert("@Html.Raw(Resources.Dictionary.disPleaseValidCharacters)");
                $("#NochesDescuento2").seekAttention();
                 return false;
             }
        }
        else {
            $("#AcumulableDescuento").val("0");
            $("#NochesDescuento").val("0");
            $("#AcumulableDescuento2").val("0");
            $("#NochesDescuento2").val("0");
        }

        //Niños Gratis
        if($("#Free_Kids").is(":checked"))
        {
            if($(".ageChild:checked").length == "0")
            {
                alert("@Html.Raw(Resources.Dictionary.disAgeRangeKidsFree)");
                $(".sectionSubTitle").next(".ageOptions").seekAttention();
                return false;
            }
            if($(".ageOptions input[name=applyFor]:checked").attr("id") != "allKidsFree")
            {
                if($(".childOptions input:checked").length == "0")
                {
                    alert("@Html.Raw(Resources.Dictionary.disPleaseSelectOption)");
                    $(".childOptions").seekAttention();
                    return false;
                }
            }
        }

        //Noches minimas
        if (!jQuery.isNumeric($("#Min_Nights").val())) {
            alert('@Html.Raw(Resources.Dictionary.disValNumericValid)');
            $("#Min_Nights").seekAttention();
            return false;
        }

        //Noches maximas
        if (!jQuery.isNumeric($("#Max_Nights").val())) {
            alert('@Html.Raw(Resources.Dictionary.disValNumericValid)');
            $("#Max_Nights").seekAttention();
            return false;
        }
        if ($("#Max_Nights").val() <= 0) {
            alert('Por favor ingrese un valor mayor que 0');
            $("#Max_Nights").seekAttention();
            return false;
        }
        //Politica de Cancelacion
        if ($("#Clav_Politica option:selected").val() == 0) {
            alert('@Html.Raw(Resources.Dictionary.SelectCancellationPolicy)');
            $("#Clav_Politica").seekAttention();
            return false;
        }
        const today = new Date('@DateTime.Now.ToString("yyyy/MM/dd")');
            const timeStampToday = Date.parse(today);
            const timeStampBooking = Date.parse($("#txt_bookingToDate").datepicker('getDate'))
            
            if (@Promo.Activo.ToString().ToLowerInvariant() == false && timeStampBooking <= timeStampToday) {
                alert("@Html.Raw(Resources.Dictionary.editBooking)");
                $("#txt_bookingToDate").seekAttention();
                return false;
        }
    }

        //Modulo de niños gratis
        /*- Al seleccinar la edad de los niños se coloca 100% en la tarifa -*/
        $(".ageChild").click(function () {
            if ($(".ageOptions input:radio:checked").attr("id") != "allKidsFree") {
                if ($(".ageChild:checked").length > 0) {
                    FreeKidsCode();
                    $(".pJunior, .pChild").val("0");
                } else {
                    alert("@Html.Raw(Resources.Dictionary.disAgeRangeKidsFree)");
                    $("#pfreeKids").val("");
                }
            }
            else {
                if ($(".ageOptions .ageChild:checked").length == 2) {
                    $("#pfreeKids").val("FK");
                    $(".pJunior, .pChild").val("100");
            }
                else {
                    var idNinoGratis = $(".ageOptions .ageChild:checked").attr("id");
                    if (idNinoGratis == "chld0") {
                        $("#pfreeKids").val("FKN");
                        $(".pChild").val("100");
                        $(".pJunior").val("0");
        }
                    else {
                        $("#pfreeKids").val("FKJ");
                        $(".pJunior").val("100");
                        $(".pChild").val("0");
            }
            }
        }
    });

        $(".payedAdults").change(function () {
        $(".childOptions input").removeAttr("checked");
        $("#pfreeKids").val("");

            if ($(this).attr("id") == "allKidsFree") {
                if ($(".ageOptions .ageChild:checked").length == 2) {
                    $("#pfreeKids").val("FK");
                    $(".pJunior, .pChild").val("100");
                }
                else {
                    var idNinoGratis = $(".ageOptions .ageChild:checked").attr("id");
                    if (idNinoGratis == "chld0") {
                        $("#pfreeKids").val("FKN");
                        $(".pChild").val("100");
                        $(".pJunior").val("0");
                    }
                    else {
                        $("#pfreeKids").val("FKJ");
                        $(".pJunior").val("100");
                        $(".pChild").val("0");
                    }
                }
            }
            else {
                $(".pJunior, .pChild").val("0");
            }
        });

        $(".childOptions input").click(function () {

            if ($(".ageOptions .ageChild:checked").length > 0) {
                FreeKidsCode();
            }
            else {
                alert("@Html.Raw(Resources.Dictionary.disAgeRangeKidsFree)");
                $("#pfreeKids").val("");
            }
    });

        function FreeKidsCode() {
        var noAdult = $(".ageOptions input:radio:checked").attr("id");
        var idNoChild = $(this).attr("id");
            var adult = (noAdult == "onePayedAdults") ? "1" : (noAdult == "twoPayedAdults") ? "2" : "";

            var Free = ($(".ageOptions .ageChild:checked").length == 2 ? "FK" : ($(".ageOptions .ageChild:checked").attr("id") == "chld0" ? "FKN" : "FKJ"));

        var child = ""
        var chkChild = $(".childOptions input");
        $.each(chkChild, function (index, itemData) {
            var idChild = $(itemData).attr("id");
                child += $(itemData).is(":checked") ? "1" : "0"
        });
            var text_FK = Free + "_" + adult + "_" + child;
        $("#pfreeKids").val(text_FK);
        }


    //SIMPLETIP
    $("div#help_specificDate").simpletip({ persistent: true,position: [-120, 0],  content: "@Resources.Dictionary.disHelpPromo_specificDate" });
    $("div#help_specificArrivals").simpletip({ persistent: true,position: [-150, 0],  content: "@Resources.Dictionary.disHelpPromo_specificArrivals" });
    $("div#help_blackout").simpletip({ persistent: true,position: [-155, 0],  content: "@Resources.Dictionary.disHelpPromo_blackout" });
    $("div#help_byDate").simpletip({ persistent: true,position: [-120, 0],  content: "@Resources.Dictionary.disHelpPromo_byDate" });
    $("div#help_earlyBooking").simpletip({ persistent: true,position: [-155, 0],  content: "@Resources.Dictionary.disHelpPromo_earlyBooking" });
    $("div#help_combinePromo").simpletip({ persistent: true,position: [-120, 0],  content: "@Resources.Dictionary.disHelpPromo_combinePromo" });
    $("div#help_open_affiliateDetail").simpletip({ persistent: true,position: [-120, 0],  content: "@Resources.Dictionary.disHelpPromo_affiliateDetail" });
        $("div#help_combineBlackOut").simpletip({ persistent: true,position: [-120, 0],  content: "@Resources.Dictionary.disHelpCombineBlackOut" });
    $("div#help_discPercentage").simpletip({ persistent: true,position: [-120, 0],  content: "@Resources.Dictionary.disHelpPromo_discPercentage" });
    $("div#help_specialRate").simpletip({ persistent: true,position: [-120, 0],  content: "@Resources.Dictionary.disPromohelp_specialRate" });
    $("div#help_discAmount").simpletip({ persistent: true,position: [-120, 0],  content: "@Resources.Dictionary.disPromohelp_discAmount" });
    $("div#help_onePayedAdults").simpletip({ persistent: true,position: [-120, 0],  content: "@Resources.Dictionary.disHelpPromo_onePayedAdults" });
        $("div#help_twoPayedAdults").simpletip({ persistent: true,position: [-120, 0],  content: "@Resources.Dictionary.disHelpPromo_twoPayedAdults" });
        $("div#help_24Booking").simpletip({ focus: true,position: [-120, 0],  content: "@Resources.Dictionary.TipBooking24Hrs" });
});

    //* Calendario Datepick*//
    $(function () {
        $.datepicker.setDefaults($.datepicker.regional['@IIf(culture = "es-MX", "es", IIf(culture = "pt-BR", "pt-BR", ""))']);

        $("#txt_travelStartDate").datepicker({
            showOn: "both",
			buttonImage: "@Url.Content("~/Content/themes/base/images/ic_cal.png")",
            buttonImageOnly: true,
            minDate: '0d',
            numberOfMonths: 2,
            showButtonPanel: true,
            dateFormat:  'dd/MM/yy',
            onSelect: function (selectedDate) {
                
				$("#txt_travelEndDate,#blackoutFromDate,#blackoutToDate").datepicker("option", "minDate", selectedDate);     //Aplica fecha minima en la fecha de viaje final
                var pickDate = $("#txt_travelStartDate").datepicker("getDate");
                $("#txt_travelEndDate, #blackoutFromDate, #blackoutToDate").datepicker("option", "maxDate", new Date(pickDate.getFullYear() + 1, pickDate.getMonth(), pickDate.getDate()));
                var sPickDate = $.datepicker.formatDate("yy/mm/dd", pickDate);
                $("#travelStartDate").attr("value", sPickDate);

                var TWFinal = $("#travelEndDate").attr("value");


                if ((Date.parse(TWFinal)) < (Date.parse(pickDate))) {
                   $("#travelEndDate").attr("value", sPickDate);
                }

            }
        });


        $("#txt_travelEndDate").datepicker({
            showOn: "both",
			buttonImage: "@Url.Content("~/Content/themes/base/images/ic_cal.png")",
            buttonImageOnly: true,
            minDate: new Date($("#travelStartDate").val()),
            numberOfMonths: 2,
            showButtonPanel: true,
            dateFormat:  'dd/MM/yy',
            onSelect: function (selectedDate) {
                $("#txt_bookingFromDate, #txt_bookingToDate,#blackoutToDate,#blackoutFromDate").datepicker("option", "maxDate", selectedDate); //Aplica fecha maxima en las fechas de booking windows
                var pickDate = $("#txt_travelEndDate").datepicker("getDate");
                var sPickDate = $.datepicker.formatDate("yy/mm/dd", pickDate);
                $("#travelEndDate").attr("value", sPickDate);
                //defaultDate: $.datepicker.formatDate("dd/mm/yy",$("#travelEndDate").datepicker("getDate")),
            }
        });

        $("#txt_bookingFromDate").datepicker({
            showOn: "@(IIf(EsPromoOculta, "focus", "both"))",
            buttonImage: "@Url.Content("~/Content/themes/base/images/ic_cal.png")",
            buttonImageOnly: true,
            minDate: '0d',
            numberOfMonths: 2,
            showButtonPanel: true,
            dateFormat:  'dd/MM/yy',
            onSelect: function (selectedDate) {
                $("#txt_bookingToDate").datepicker( "option", "minDate", selectedDate);     //Aplica fecha minima en la el booking windows
                var pickDate = $("#txt_bookingFromDate").datepicker("getDate");
                var sPickDate = $.datepicker.formatDate("yy/mm/dd", pickDate);
                $("#bookingFromDate").attr("value", sPickDate);

                var BWFinal = $("#bookingToDate").attr("value");


                if ((Date.parse(BWFinal)) < (Date.parse(pickDate))) {
                    $("#bookingToDate").attr("value", sPickDate);
                }

            }
        });

        $("#txt_bookingToDate").datepicker({
            showOn: "@(IIf(EsPromoOculta, "focus", "both"))",
			buttonImage: "@Url.Content("~/Content/themes/base/images/ic_cal.png")",
            buttonImageOnly: true,
            minDate: new Date($("#bookingFromDate").val()),
            numberOfMonths: 2,
            showButtonPanel: true,
            dateFormat:  'dd/MM/yy',
            onSelect: function (selectedDate) {
                var pickDate = $("#txt_bookingToDate").datepicker("getDate");
                var sPickDate = $.datepicker.formatDate("yy/mm/dd", pickDate);
                $("#bookingToDate").attr("value", sPickDate);
            }
        });

        //BlackOut
        $("#blackoutFromDate").datepicker({
            showOn: "both",
			buttonImage: "@Url.Content("~/Content/themes/base/images/ic_cal.png")",
            buttonImageOnly: true,
            minDate: '-12m',
            numberOfMonths: 2,
            showButtonPanel: true,
            dateFormat: 'dd/MM/yy',
            onSelect: function (selectedDate) {
                $("#blackoutToDate").datepicker( "option", "minDate", selectedDate);     //Aplica fecha minima en la el booking windows

                var pickDate = $("#blackoutFromDate").datepicker("getDate");
                var sPickDate = $.datepicker.formatDate("yy/mm/dd", pickDate);
                $("#blackoutFrom").attr("value", sPickDate);

                var BOFinal = $("#blackoutTo").attr("value");


                if ((Date.parse(BOFinal)) < (Date.parse(pickDate))) {
                    $("#blackoutTo").attr("value", sPickDate);
                }
            }
        });

        $("#blackoutToDate").datepicker({
            showOn: "both",
			buttonImage: "@Url.Content("~/Content/themes/base/images/ic_cal.png")",
            buttonImageOnly: true,
            minDate: new Date($("#blackoutFromDate").val()),
            numberOfMonths: 2,
            showButtonPanel: true,
            dateFormat: 'dd/MM/yy',
            onSelect: function (selectedDate) {
                var pickDate = $("#blackoutToDate").datepicker("getDate");
                var sPickDate = $.datepicker.formatDate("yy/mm/dd", pickDate);
                $("#blackoutTo").attr("value", sPickDate);
            }
        });

        $(".SearchVoucher").click(function(){
            if ($(".codeList").is(":visible")){
                $(".codeList").slideUp();
            }
            else{
                $(".codeList").slideDown();
            }
        });

        $(".codeList input").click(function(){
            var code = $(this)
            $(".codeList").slideUp();
            $("#Codigo_Promo").val(code.val());
            $("#ClavPromoOculta").val(code.attr("id"));
            $("#txt_travelStartDate").val(code.attr("titxt"));
            $("#travelStartDate").val(code.attr("ti"));
            $("#txt_travelEndDate").val(code.attr("tftxt"));
            $("#travelEndDate").val(code.attr("tf"));
            $("#txt_bookingFromDate").val(code.attr("bitxt"));
            $("#bookingFromDate").val(code.attr("bi"));
            $("#txt_bookingToDate").val(code.attr("bftxt"));
            $("#bookingToDate").val(code.attr("bf"));


            $(".bookingWindow input, .bookingWindow select").attr("disabled","disabled");
            $(".bookingWindow img").hide();
        });

        $("#Codigo_Promo").blur(function(){
            if ($(this).val() == ""){
                $("#ClavPromoOculta").val("");
                $(".bookingWindow input, .bookingWindow select").removeAttr("disabled");
                $(".bookingWindow img").show();
            }
        });
    });

</script>


<form id="MasterPromoForm" name="MasterPromoForm" action="EditPromo" class="hide" method="post"
      onsubmit="Sys.Mvc.AsyncForm.handleSubmit(this, new Sys.UI.DomEvent(event),
          {   insertionMode: Sys.Mvc.InsertionMode.replace, updateTargetId: 'ResultDivFancy',
              onBegin: Function.createDelegate(this, StartRequest),
              onFailure: Function.createDelegate(this, ErrorRequest),
              onSuccess: Function.createDelegate(this, EndRequest) });">
    <div class="fixedContent">
        <div class="promoEditing">
            <div class="promoBasics">
                <div class="hotelPlan"><span>@hotelName</span></div>

                <div class="codeNameContainer">
                    <div class="code">
                        <span>@Resources.Dictionary.PromoCode: </span>
                        @Html.TextBoxFor(Function(m) m.Codigo_Promo, IIf(Is24Hrs Or EsPromoOculta, New With {.Disabled = "disabled", .Value = Promo.CodigoPromo}, New With {.Value = Promo.CodigoPromo}))

                        @If Not Vouchers Is Nothing Then
                            If Not EsPromoOculta Then

                                @<img class="SearchVoucher" style="width: 21px; @(IIf(withVoucher, "", "display:none;"))" src="/Content/themes/base/images/lupa.jpg" />
                                @<span class="new" style="width: 35px; display: inline; @(IIf(withVoucher, "", "display:none;"))">Nuevo</span>
                                @<div class="codeList" style="display:none;">
                                    <b>@Resources.Dictionary.SelectPromoCode:</b>
                                    <ul>
                                        @For Each voucher In Vouchers
                                            @<li><input type="radio" name="voucher" value="@voucher.CodigoPromo" id="@voucher.PromoOculta" ti="@voucher.FechaViajeInicial" titxt="@Date.Parse(voucher.FechaViajeInicial).ToString("dd/MMMM/yyyy")" tf="@voucher.FechaViajeFinal" tftxt="@Date.Parse(voucher.FechaViajeFinal).ToString("dd/MMMM/yyyy")" bi="@voucher.FechaReservaInicial" bitxt="@Date.Parse(voucher.FechaReservaInicial).ToString("dd/MMMM/yyyy")" bf="@voucher.FechaReservaFinal" bftxt="@Date.Parse(voucher.FechaReservaFinal).ToString("dd/MMMM/yyyy")" />  <label for="@voucher.PromoOculta">@voucher.CodigoPromo - @voucher.NombreEsp</label> </li>
                                        Next
                                    </ul>
                                </div>
                            End If
                        End If

                        @Html.HiddenFor(Function(m) m.EsPromoOculta, New With {.Value = Promo.esPromocionOculta})
                        @Html.HiddenFor(Function(m) m.ClavPromoOculta)

                    </div>

                    @If Session("IsSuperUser") Then
                        @<div class="code"><span>@Resources.Dictionary.ClavePromo: </span>@Html.TextBoxFor(Function(m) m.Clav_Promo, New With {.Value = Promo.Clav_Promo})</div>
                    Else
                        @Html.HiddenFor(Function(m) m.Clav_Promo, New With {.Value = Promo.Clav_Promo})
                    End If
                    <div class="promoName"><span>@Resources.Dictionary.disPromoName: </span>@Html.TextBoxFor(Function(m) m.Nombre, New With {.Value = Promo.Nombre_Promo})</div>

                </div>
                <div class="resumeBox">
                    <div class="promoResume">
                        <div class="resumeBlock">
                            <span class="resumeTitle">@Resources.Dictionary.disTravelWindow:</span>
                            <span> @Utilities.FormatDate(Promo.Temporada_Inicial.ToString("dd/MMM/yyyy")) @Resources.Dictionary.disTo @Utilities.FormatDate(Promo.Temporada_Final.ToString("dd/MMM/yyyy")). <a href="#travelWindow">@Resources.Dictionary.disChange</a></span>
                            @*<span> Mon, Tue, Wed, Thu, Fri</span>*@
                        </div>
                        <div class="resumeBlock">
                            <span class="resumeTitle">@Resources.Dictionary.disBookingWindow:</span>
                            @If Promo.Tipo_Booking = "D" Then
                                @<span>@Resources.Dictionary.disFrom @Promo.Booking_En_Dias @Resources.Dictionary.disTo @Promo.Booking_En_Dias_After. <a href="#bookingWindow">@Resources.Dictionary.disChange</a></span>
                            Else
                                @<span>@Utilities.FormatDate(windows_de.ToString("dd/MMM/yyyy")) @Resources.Dictionary.disTo @Utilities.FormatDate(windows_a.ToString("dd/MMM/yyyy")). <a href="#bookingWindow">@Resources.Dictionary.disChange</a></span>
                            End If


                            @*<span>Mon, Tue, Wed, Thu, Fri</span>*@
                        </div>
                        <div class="hr"></div>
                        @*<ul class="promoType">
                                <li>Every 3rd night will be free. <a href="#">Change</a></li>
                                <li>Bottle of sparkling wine, Frute Plate. <a href="#">Change</a></li>
                                <li>25% Discount. <a href="#">Change</a></li>
                                <li>1st Kid free for every payed adult. <a href="#">Change</a></li>
                            </ul>*@
                    </div>
                    @*Listado de contratos*@
                    <div class="boxContractSelection">
                        <div><input class="SelectAll" type="checkbox" id="AllContract"><label for="AllContract" style="font-size: 12px;">@Resources.Dictionary.disSelectAll Contratos</label></div>
                        <div class="contractList">
                            <ul id="listContracts" class="sectionBox">
                                @code
                                    Dim Mercado_Contrato As String = ""
                                    Dim Mercado_Sincronizado As String = ""
                                    Dim Moneda As String = ""
                                    Dim IsDifeMoneda As Boolean = False
                                End Code
                                @For Each item In sHotelContract

                                    @*Valida que contratos se tienen en la promo*@
                                Dim chkContract As String = ""
                                Dim checked As Boolean = False
                                Dim notif As String = ""
                                For c As Integer = 0 To contractPromo.Count - 1
                                    If (contractPromo(c).Clav_Mercado = item.Clav_Mercado And contractPromo(c).Id_Contrato = item.Id_Contrato) Then

                                        Moneda = IIf(Moneda = "", item.Nombre_Mondena, Moneda)
                                        notif_Type = item.Clav_Notif
                                        chkContract = "checked = checked"
                                        Unit_Discount = If(Promo.Tipo_Promo.Contains("OF_PO"), "%", item.Nombre_Mondena)
                                        EsNeta = IIf(item.Clav_Notif <> "V", True, False)
                                        checked = True

                                        Dim contratoSincr = (From s In ContratosSincronizados
                                                             Join cont In contractPromo On cont.Clav_Mercado Equals s.Clav_Mercado And cont.Id_Contrato Equals s.Id_Contrato
                                                             Where s.Clav_MercadoMigrar.Equals(contractPromo(c).Clav_Mercado) And s.Id_ContratoMigrar = contractPromo(c).Id_Contrato).Count
                                        If Not Mercado_Contrato.Contains(contractPromo(c).Clav_Mercado & "-" & contractPromo(c).Id_Contrato) And
                                            (contratoSincr = 0) Then
                                            Mercado_Contrato = Mercado_Contrato & "|" & contractPromo(c).Clav_Mercado & "-" & contractPromo(c).Id_Contrato
                                            Unit_Discount = If(Promo.Tipo_Promo.Contains("OF_PO"), "%", item.Nombre_Mondena)
                                        End If

                                        If Moneda <> item.Nombre_Mondena Then
                                            IsDifeMoneda = True
                                            Moneda = item.Nombre_Mondena
                                        End If
                                    End If
                                Next

                                Dim clave = item.Clav_Mercado & "-" & item.Id_Contrato
                                    @<li>

                                        @*valida los contratos sincronizados y base y deshabilita*@
                                        @code
                                            Dim ContratoBase = ""
                                            Dim ContratoMigra = ""
                                            Dim isbasePromo As Boolean = False
                                            Dim contratosSincronizadoBase = (From c In ContratosSincronizados Where (c.Clav_Mercado.Equals(item.Clav_Mercado) And c.Id_Contrato = item.Id_Contrato) Or (c.Clav_MercadoMigrar.Equals(item.Clav_Mercado) And c.Id_ContratoMigrar = item.Id_Contrato) Select c.Clav_Mercado, c.Id_Contrato, c.Clav_MercadoMigrar, c.Id_ContratoMigrar).ToList
                                            For Each base In contratosSincronizadoBase

                                                If base.Clav_MercadoMigrar = item.Clav_Mercado And base.Id_ContratoMigrar = item.Id_Contrato Then
                                                    If Not ContratoBase.Contains(base.Clav_Mercado & "-" & base.Id_Contrato) Then
                                                        ContratoBase = ContratoBase & "|" & base.Clav_Mercado & "-" & base.Id_Contrato
                                                    End If
                                                    If (From b In contractPromo Where b.Clav_Mercado = base.Clav_Mercado And b.Id_Contrato = base.Id_Contrato).Count > 0 Then
                                                        isbasePromo = True
                                                        If chkContract <> "" Then
                                                            Mercado_Sincronizado = Mercado_Sincronizado & "|" & base.Clav_MercadoMigrar & "-" & base.Id_ContratoMigrar
                                                        End If

                                                    End If
                                                    Exit For
                                                ElseIf base.Clav_Mercado = item.Clav_Mercado And base.Id_Contrato = item.Id_Contrato Then
                                                    If Not ContratoMigra.Contains(clave) Then
                                                        ContratoMigra = ContratoMigra & "|" & clave
                                                    End If
                                                    Exit For
                                                End If

                                            Next
                                        End Code

                                        <input type="checkbox" id="@clave" notif="@item.Clav_Notif" mon="@item.Nombre_Mondena" base="@ContratoBase" migra="@ContratoMigra" tarmin="@item.Tarifa_Minima" tarmax="@item.Tarifa_Maxima" @chkContract @(IIf(isbasePromo, "disabled=disabled", "")) />
                                        <label for="@clave">@item.Nombre_Contrato - @item.Nombre_Mondena</label>
                                        @*<input type="checkbox" id="@clave" mon="@item.Nombre_Mondena"/>*@
                                    </li>
                                            Next
                            </ul>
                            @Html.HiddenFor(Function(m) m.ContractMercado, New With {.Value = Mercado_Contrato})
                            @Html.HiddenFor(Function(m) m.ContratoSincro, New With {.Value = Mercado_Sincronizado})
                        </div>
                    </div>
                    <div class=" boxRoomsSelection">

                        <div><input class="SelectAll" type="checkbox" id="AllRooms"><label for="AllRooms" style="font-size: 12px;">@Resources.Dictionary.disSelectAll</label></div>
                        <div class="roomList">
                            <ul>
                                @For i As Integer = 0 To roomsPlan.Count - 1
                                    Dim cssClavCuarto = Utilities.WithOutSpecialChars(roomsPlan(i).Clav_Cuarto)

                                    Dim chkRoom As String = ""
                                    Dim checked As Boolean = False
                                    For r As Integer = 0 To ListPromoRoom.Count - 1
                                        If (ListPromoRoom(r).Clav_Cuarto = roomsPlan(i).Clav_Cuarto And ListPromoRoom(r).Clav_plan = roomsPlan(i).Clav_Plan) Then
                                            chkRoom = "checked= checked"
                                            checked = True
                                        End If
                                    Next
                                    '/* Informacion de las habitaciones */

                                    @Html.HiddenFor(Function(m) m.roomRates.Item(i).Clav_Cuarto, New With {.Value = roomsPlan(i).Clav_Cuarto})
                                    @Html.HiddenFor(Function(m) m.roomRates.Item(i).Clav_plan, New With {.Value = roomsPlan(i).Clav_Plan})
                                    @*Html.HiddenFor(Function(m) m.roomRates.Item(i).Id_Contrato, New With {.Value = roomsPlan(i).Id_Contrato})*@
                                    @Html.HiddenFor(Function(m) m.roomRates.Item(i).selected, New With {.Class = String.Format("Inp_{0}_{1}", cssClavCuarto, roomsPlan(i).Clav_Plan), .Value = checked})
                                    'If (roomsPlan(i).Clav_Plan = PlanRooms) Then
                                    @<li>
                                        @*@If checked Then
                                               @Html.CheckBox(String.Format("{0}_{1}", roomsPlan(i).Clav_Cuarto, roomsPlan(i).Clav_Plan), checked, New With {.Value = checked, .Class = IIf(i = roomsPlan.Count - 1, "liLast", ""), .Disabled = "disabled"})
                                            Else*@
                                        @Html.CheckBox(String.Format("{0}_{1}", cssClavCuarto, roomsPlan(i).Clav_Plan), checked, New With {.Id = String.Format("{0}_{1}", cssClavCuarto, roomsPlan(i).Clav_Plan), .Value = checked, .Class = IIf(i = roomsPlan.Count - 1, "liLast", "")})
                                        @*End If*@
                                        @*<input id="@String.Format("{0}_{1}", roomsPlan(i).Clav_Cuarto, roomsPlan(i).Clav_Plan)" @IIf(i = roomsPlan.Count - 1, "class=liLast", "") type="checkbox" name="Rooms" value="@String.Format("{0}_{1}", roomsPlan(i).Clav_Cuarto, roomsPlan(i).Clav_Plan)" @chkRoom/>*@
                                        <label for="@String.Format("{0}_{1}", cssClavCuarto, roomsPlan(i).Clav_Plan)">@roomsPlan(i).Nombre_Cuarto - @roomsPlan(i).Nombre_Plan</label>
                                    </li>
                                    'End If

                                Next
                            </ul>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="loadedContent">
        @*Travel Window*@
        <div class="sectionWindow travelWindow">
            <span class="sectionTitle">@Resources.Dictionary.disTravelWindow</span>
            <div class="dateLeft">
                <script>
                    const star = new Date('@Promo.Temporada_Inicial.ToString("yyyy/MM/dd", New System.Globalization.CultureInfo(culture))');
                    const end = new Date('@Promo.Temporada_Final.ToString("yyyy/MM/dd", New System.Globalization.CultureInfo(culture))');
                    const diffMonthns = diff_months(end, star);
                    const monthsYear = 13;
                    if (diffMonthns < monthsYear) {
                        const maxDate = new Date('@Promo.Temporada_Inicial.ToString("yyyy/MM/dd", New System.Globalization.CultureInfo(culture))');
                        $(() => {
                            $("#txt_travelEndDate, #blackoutFromDate, #blackoutToDate, #txt_bookingToDate").datepicker("option", "maxDate", new Date(maxDate.getFullYear() + 1, maxDate.getMonth(), maxDate.getDate()));
                            var d = $('#txt_bookingToDate').datepicker('getDate');
                            const final = d.getFullYear() + "/" + (d.getMonth() + 1) + "/" + d.getDate();
                            $("#bookingToDate").val(final)
                        });;
                    }

                    function diff_months(d2, d1) {
                        var months;
                        months = (d2.getFullYear() - d1.getFullYear()) * 12;
                        months -= d1.getMonth() + 1;
                        months += d2.getMonth() + 1;
                        return months <= 0 ? 0 : months;

                    }
                </script>
                <label class="upperLabel" for="txt_travelStartDate">@Resources.Dictionary.disStartDate:</label>
                @Html.TextBox("txt_travelStartDate", Utilities.FormatDate(Promo.Temporada_Inicial.ToString("dd/MMMM/yyyy", New System.Globalization.CultureInfo(culture))))
                @Html.HiddenFor(Function(m) m.Temporada_Inicial, New With {.Value = Promo.Temporada_Inicial.ToString("yyyy/MM/dd"), .Id = "travelStartDate"})
            </div>
            <div class="dateRight">
                <label class="upperLabel" for="travelEndDate">@Resources.Dictionary.disEndDate:</label>
                @Html.TextBox("txt_travelEndDate", Utilities.FormatDate(Promo.Temporada_Final.ToString("dd/MMMM/yyyy", New System.Globalization.CultureInfo(culture))))
                @Html.HiddenFor(Function(m) m.Temporada_Final, New With {.Value = Format(CType(Promo.Temporada_Final, Date), "yyyy/MM/dd"), .Id = "travelEndDate"})
            </div>
            @code
                Dim checkTarifa = IIf(Promo.Dia_Tarifa <> 0 And Promo.Dia_Tarifa <> 127, True, False)
                Dim checkLlegada = IIf(Promo.Dia_Llegada <> 0 And Promo.Dia_Llegada <> 127, True, False)
            End Code
            <div class="exclusiveDates">
                @Html.CheckBox("open_specificDate", (Promo.Dia_Tarifa <> 0 And Promo.Dia_Tarifa <> 127), New With {.Value = Promo.Dia_Tarifa, .Class = "toggleSection"})
            @Html.HiddenFor(Function(m) m.Dia_Tarifa, New With {.Value = Promo.Dia_Tarifa, .Id = "Rate_Day"})
            <label for="open_specificDate" @IIf(Promo.Dia_Tarifa <> 0 And Promo.Dia_Tarifa <> 127, "class=on", "")> @Resources.Dictionary.disSpecificDays. </label><div class="help_tip" id="help_specificDate"></div>
            <ul class="sectionBox @IIf(Promo.Dia_Tarifa <> 0 And Promo.Dia_Tarifa <> 127, "on", "off")" id="specificDate">
                <li class="day @IIf(dayTravel(6) = 1, "checked", "") "><span @IIf(dayTravel(6) = 1, "class=on", "")>@Resources.Dictionary.sSun</span><input class="checkbox" name="dateday" @IIf(dayTravel(6) = 1, "checked=checked", "") value="1" type="checkbox" /></li>
                <li class="day @IIf(dayTravel(5) = 1, "checked", "") "><span @IIf(dayTravel(5) = 1, "class=on", "")>@Resources.Dictionary.sMon</span><input class="checkbox" name="dateday" @IIf(dayTravel(5) = 1, "checked=checked", "") value="2" type="checkbox" /></li>
                <li class="day @IIf(dayTravel(4) = 1, "checked", "") "><span @IIf(dayTravel(4) = 1, "class=on", "")>@Resources.Dictionary.sTue</span><input class="checkbox" name="dateday" @IIf(dayTravel(4) = 1, "checked=checked", "") value="3" type="checkbox" /></li>
                <li class="day @IIf(dayTravel(3) = 1, "checked", "") "><span @IIf(dayTravel(3) = 1, "class=on", "")>@Resources.Dictionary.sWed</span><input class="checkbox" name="dateday" @IIf(dayTravel(3) = 1, "checked=checked", "") value="4" type="checkbox" /></li>
                <li class="day @IIf(dayTravel(2) = 1, "checked", "") "><span @IIf(dayTravel(2) = 1, "class=on", "")>@Resources.Dictionary.sThu</span><input class="checkbox" name="dateday" @IIf(dayTravel(2) = 1, "checked=checked", "") value="5" type="checkbox" /></li>
                <li class="day @IIf(dayTravel(1) = 1, "checked", "") "><span @IIf(dayTravel(1) = 1, "class=on", "")>@Resources.Dictionary.sFri</span><input class="checkbox" name="dateday" @IIf(dayTravel(1) = 1, "checked=checked", "") value="6" type="checkbox" /></li>
                <li class="liLast day @IIf(dayTravel(0) = 1, "checked", "") "><span @IIf(dayTravel(0) = 1, "class=on", "")>@Resources.Dictionary.sSat</span><input class="checkbox" name="dateday" @IIf(dayTravel(0) = 1, "checked=checked", "") value="7" type="checkbox" /></li>
            </ul>
        </div>
        <div class="exclusiveArrivals">
            @Html.CheckBox("open_specificArrivals", (Promo.Dia_Llegada <> 0 And Promo.Dia_Llegada <> 127), New With {.Value = Promo.Dia_Llegada, .Class = "toggleSection"})
        @Html.HiddenFor(Function(m) m.Dia_Llegada, New With {.Value = Promo.Dia_Llegada, .Id = "Arrivals_Day"})
        <label for="open_specificArrivals" @IIf(Promo.Dia_Llegada <> 0 And Promo.Dia_Llegada <> 127, "class=on", "")> @Resources.Dictionary.disSpecificArrivals. </label><div class="help_tip" id="help_specificArrivals"></div>
        <ul class="sectionBox @IIf(Promo.Dia_Tarifa <> 0 And Promo.Dia_Llegada <> 127, "on", "off")" id="specificArrivals">
            <li class="day @IIf(dayArrival(6) = 1, "checked", "") "><span @IIf(dayArrival(6) = 1, "class=on", "")>@Resources.Dictionary.sSun</span><input class="checkbox" name="dateday" @IIf(dayArrival(6) = 1, "checked=checked", "") value="1" type="checkbox" /></li>
            <li class="day @IIf(dayArrival(5) = 1, "checked", "") "><span @IIf(dayArrival(5) = 1, "class=on", "")>@Resources.Dictionary.sMon</span><input class="checkbox" name="dateday" @IIf(dayArrival(5) = 1, "checked=checked", "") value="2" type="checkbox" /></li>
            <li class="day @IIf(dayArrival(4) = 1, "checked", "") "><span @IIf(dayArrival(4) = 1, "class=on", "")>@Resources.Dictionary.sTue</span><input class="checkbox" name="dateday" @IIf(dayArrival(4) = 1, "checked=checked", "") value="3" type="checkbox" /></li>
            <li class="day @IIf(dayArrival(3) = 1, "checked", "") "><span @IIf(dayArrival(3) = 1, "class=on", "")>@Resources.Dictionary.sWed</span><input class="checkbox" name="dateday" @IIf(dayArrival(3) = 1, "checked=checked", "") value="4" type="checkbox" /></li>
            <li class="day @IIf(dayArrival(2) = 1, "checked", "") "><span @IIf(dayArrival(2) = 1, "class=on", "")>@Resources.Dictionary.sThu</span><input class="checkbox" name="dateday" @IIf(dayArrival(2) = 1, "checked=checked", "") value="5" type="checkbox" /></li>
            <li class="day @IIf(dayArrival(1) = 1, "checked", "") "><span @IIf(dayArrival(1) = 1, "class=on", "")>@Resources.Dictionary.sFri</span><input class="checkbox" name="dateday" @IIf(dayArrival(1) = 1, "checked=checked", "") value="6" type="checkbox" /></li>
            <li class="liLast day @IIf(dayArrival(0) = 1, "checked", "") "><span @IIf(dayArrival(0) = 1, "class=on", "")>@Resources.Dictionary.sSat</span><input class="checkbox" name="dateday" @IIf(dayArrival(0) = 1, "checked=checked", "") value="7" type="checkbox" /></li>
        </ul>
    </div>
    @CODE
        If ListBlackOutDates.count > 0 Then
            ListBlackOutDates = IIf(ListBlackOutDates(0).BlackOutInicial = New Date(1900, 1, 1), Nothing, ListBlackOutDates)
        Else
            ListBlackOutDates = Nothing
        End If

        Dim Check_BlackOut As Boolean = IIf(Not ListBlackOutDates Is Nothing, True, False)
    End Code
    <div class="blackoutDays">
        @Html.CheckBox("open_blackout", Check_BlackOut, New With {.class = "toggleSection"})
    <label for="open_blackout"> @Resources.Dictionary.disBlackoutDays. </label><div class="help_tip" id="help_blackout"></div>
    <div class="sectionBox blackout off" id="blackout" @(IIf(Check_BlackOut, "style=display:block;", ""))>
        <div class="blackoutFrom">
            <label for="blackoutFromDate" class="upperLabel">@Resources.Dictionary.disBetween:</label>
            @Html.TextBox("blackoutFromDate")
            @Html.Hidden("blackoutFrom")
        </div>
        <div class="blackoutTo">
            <label for="blackoutToDate" class="upperLabel">@Resources.Dictionary.disAnd:</label>
            @Html.TextBox("blackoutToDate")
            @Html.Hidden("blackoutTo")
        </div>
        <span id="AddDateBlackout" class="addSubmit addblackout"> + @Resources.Dictionary.disAddBlackOut</span>
        <div class="dateShow">
            <span class="sectionSubTitle">@Resources.Dictionary.disDateRangesSelected</span><a href="#" class="deleteAll" style="display:none;">@Resources.Dictionary.DisRemoveAll</a>
            <div class="hr"></div>
            <div class="rangeSelectedBKO">
                <ul id="Dates_Blackout">
                    @Code
                        Dim datesString As String = ""
                        If Not ListBlackOutDates Is Nothing Then
                            For Each item In ListBlackOutDates


                            Next
                        End If
                    End Code
                </ul>
            </div>
        </div>
        @Html.HiddenFor(Function(m) m.Dias_BlackOut, New With {.Value = datesString})
    </div>
</div>
</div>
@*Booking Window*@
<div class="sectionWindow bookingWindow">
    <span class="sectionTitle">@Resources.Dictionary.disBookingWindow</span>
    <div class="bookingOption">
        @Code
            Dim Check_byDate As Boolean = IIf(Promo.Tipo_Booking = "T" And Promo.CodigoPromo <> "24HORAS", True, False)
            Dim Check_earlyBooking As Boolean = IIf(Promo.Tipo_Booking = "D" And Promo.Booking_En_Dias >= 0 And Promo.Booking_En_Dias_After >= 0, True, False)
            Dim Check_24Booking As Boolean = IIf(Promo.Tipo_Booking = "T" And Promo.CodigoPromo = "24HORAS", True, False)
            'Dim Check_LastMinute As Boolean = (IIf(Promo.Tipo_Booking = "D" And Promo.Booking_En_Dias = 0 And Promo.Booking_En_Dias_After = 1, True, False))
            Dim valorBooking = IIf(Promo.Tipo_Booking = "T" And Promo.CodigoPromo = "24HORAS", "T24", Promo.Tipo_Booking)
        End Code
        <div class="radioSelection">
            @Html.HiddenFor(Function(m) m.Tipo_Booking, New With {.Value = valorBooking})
            @Html.RadioButton("Type_Booking", "T", Check_byDate, IIf(Is24Hrs Or EsPromoOculta, New With {.Disabled = "disabled", .Id = "open_byDate", Check_byDate}, New With {.Id = "open_byDate", Check_byDate}))
            <label for="open_byDate" @IIf(Promo.Tipo_Booking = "T" And Promo.CodigoPromo <> "24HORAS", "class=on", "")> @Resources.Dictionary.disFixedDates. </label><div class="help_tip" id="help_byDate"></div>
        </div>
        <div class="radioSelection">
            @Html.RadioButton("Type_Booking", "D", Check_earlyBooking, IIf(Is24Hrs Or EsPromoOculta, New With {.Disabled = "disabled", .Id = "open_earlyBooking", Check_earlyBooking}, New With {.Id = "open_earlyBooking", Check_earlyBooking}))
            <label for="open_earlyBooking" @IIf(Check_earlyBooking, "class=on", "")> @Resources.Dictionary.DisEarlyBookingDays. </label><div class="help_tip" id="help_earlyBooking"></div>
        </div>
        @If (Is24Hrs Or (ShowPromo24Hrs = 1 Or Session("CompanyHotel") <> "BEDA")) Or Session("IsSuperUser") Then
            @<div class="radioSelection">
                @Html.RadioButton("Type_Booking", "T24", Check_24Booking, IIf(Is24Hrs Or EsPromoOculta, New With {.Disabled = "disabled", .Id = "open_24Booking", Check_24Booking}, New With {.Id = "open_24Booking", Check_24Booking}))
                <label for="open_24Booking" @IIf(Promo.Tipo_Booking = "T" And Promo.CodigoPromo = "24HORAS", "class=on", "")>@Resources.Dictionary.Exclusive24Hrs</label>

                <div class="help_tip" id="help_24Booking"></div>
            </div>
        End If
        @* <div class="radioSelection">
            @Html.RadioButton("Type_Booking", "L", Check_LastMinute, New With {.Id = "LastMinute", Check_LastMinute})
            <label for="LastMinute" @IIf(Check_LastMinute, "class=on", "")>Last Minute </label><div class="help_tip" id="help_lastMinute" ></div></div>*@
        @code
            'Horas y Minutos Booking_Windows_De
            Dim hours_De As List(Of SelectListItem) = New List(Of SelectListItem)
            For i As Integer = 0 To 23
                hours_De.Add(New SelectListItem With {.Text = i.ToString("00"), .Value = i.ToString("00"), .Selected = IIf(windows_de = Nothing, IIf(i.ToString("00") = "00", True, False), IIf(windows_de.Hour.ToString("00") = i, True, False))})
            Next
            Dim minutes_De As List(Of SelectListItem) = New List(Of SelectListItem)
            For i As Integer = 0 To 59
                minutes_De.Add(New SelectListItem With {.Text = i.ToString("00"), .Value = i.ToString("00"), .Selected = IIf(windows_de = Nothing, IIf(i.ToString("00") = "00", True, False), IIf(windows_de.Minute.ToString("00") = i, True, False))})
            Next
            'Horas y Minutos Booking_Windows_A
            'Horas y Minutos
            Dim hours_A As List(Of SelectListItem) = New List(Of SelectListItem)
            For i As Integer = 0 To 23
                hours_A.Add(New SelectListItem With {.Text = i.ToString("00"), .Value = i.ToString("00"), .Selected = IIf(windows_a = Nothing, IIf(i.ToString("00") = "23", True, False), IIf(windows_a.Hour.ToString("00") = i, True, False))})
            Next
            Dim minutes_A As List(Of SelectListItem) = New List(Of SelectListItem)
            For i As Integer = 0 To 59
                minutes_A.Add(New SelectListItem With {.Text = i.ToString("00"), .Value = i.ToString("00"), .Selected = IIf(windows_de = Nothing, IIf(i.ToString("00") = "59", True, False), IIf(windows_a.Minute.ToString("00") = i, True, False))})
            Next
        End Code
        <div class="bookingInputs sectionBox @IIf(Promo.Tipo_Booking = "T" And Promo.CodigoPromo <> "24HORAS", "", "off")" id="byDate">
            <div class="bookingFrom">
                <label class="time-zone-ad">@Resources.Dictionary.disTimeZone</label>
                <label for="bookingFromDate" class="upperLabel">@Resources.Dictionary.disFrom   :</label>
                <script>
                    const stars = new Date('@windows_de.ToString("yyyy/MM/dd", New System.Globalization.CultureInfo(culture))');
                    const ends = new Date('@windows_a.ToString("yyyy/MM/dd", New System.Globalization.CultureInfo(culture))');
                    const diffMonthnss = diff_monthss(ends, stars);
                    const monthsYears = 13;
                    if (diffMonthnss < monthsYears) {
                        const maxDate = new Date('@windows_de.ToString("yyyy/MM/dd", New System.Globalization.CultureInfo(culture))');
                        $(() => {
                            var d = $('#txt_bookingToDate').datepicker('getDate');
                            const final = d.getFullYear() + "/" + (d.getMonth() + 1) + "/" + d.getDate();
                            $("#bookingToDate").val(final)
                            $("#blackoutFromDate, #blackoutToDate, #txt_bookingToDate").datepicker("option", "maxDate", new Date(maxDate.getFullYear() + 1, maxDate.getMonth(), maxDate.getDate()));
                        });;
                    }

                    function diff_monthss(d2, d1) {
                        var months;
                        months = (d2.getFullYear() - d1.getFullYear()) * 12;
                        months -= d1.getMonth() + 1;
                        months += d2.getMonth() + 1;
                        return months <= 0 ? 0 : months;

                    }
                </script>

                @Html.TextBox("txt_bookingFromDate", Utilities.FormatDate(windows_de.ToString("dd/MMMM/yyyy", New System.Globalization.CultureInfo(culture))), IIf(EsPromoOculta, New With {.Disabled = "disabled"}, ""))
                @Html.HiddenFor(Function(m) m.Booking_Windows_De, New With {.Value = windows_de.ToString("yyyy/MM/dd"), .Id = "bookingFromDate"})
                @Html.DropDownListFor(Function(m) m.Hours_Windows_De, hours_De)
                <span>Hrs.</span>
                @Html.DropDownListFor(Function(m) m.Minutes_Windows_De, minutes_De)
                <span>Min.</span>
            </div>
            <div class="bookingTo">
                <label class="time-zone-ad">@Resources.Dictionary.disTimeZone</label>
                <label for="bookingToDate" class="upperLabel">@Resources.Dictionary.DisHasta:</label>
                @Html.TextBox("txt_bookingToDate", Utilities.FormatDate(windows_a.ToString("dd/MMMM/yyyy", New System.Globalization.CultureInfo(culture))), IIf(EsPromoOculta, New With {.Disabled = "disabled"}, ""))
                @Html.HiddenFor(Function(m) m.Booking_Windows_A, New With {.Value = windows_a.ToString("yyyy/MM/dd"), .Id = "bookingToDate"})
                @Html.DropDownListFor(Function(m) m.Hours_Windows_A, hours_A)
                <span>Hrs.</span>
                @Html.DropDownListFor(Function(m) m.Minutes_Windows_A, minutes_A)
                <span>Min.</span>
            </div>
        </div>
        <div class="bookingInputs sectionBox @IIf(Check_earlyBooking, "", "off")" id="earlyBooking">
            <div class="bookingMin">
                <label for="bookingMinDays" class="upperLabel">@Resources.Dictionary.DisMinDays</label>
                @Html.TextBoxFor(Function(m) m.Booking_En_Dias, IIf(EsPromoOculta, New With {.Disabled = "disabled", .Value = Promo.Booking_En_Dias, .Id = "bookingMinDays"}, New With {.Value = Promo.Booking_En_Dias, .Id = "bookingMinDays"}))
            </div>
            <div class="bookingMax">
                <label for="bookingMaxDays" class="upperLabel">@Resources.Dictionary.DisMaxDays</label>
                @Html.TextBoxFor(Function(m) m.Booking_Dias_After, IIf(EsPromoOculta, New With {.Disabled = "disabled", .Value = Promo.Booking_En_Dias_After, .Id = "bookingMaxDays", .onkeyup = "return maxDaysKeyPress(this)"}, New With {.Value = Promo.Booking_En_Dias_After, .Id = "bookingMaxDays", .onkeyup = "return maxDaysKeyPress(this)"}))
            </div>
        </div>

        <div class="bookingInputs sectionBox @IIf(Promo.Tipo_Booking = "T" And Promo.CodigoPromo = "24HORAS", "", "off")" id="24Booking">

        </div>
        @*'Dias visibles de la promo*@
        @*                <div class="exclusiveDates">@Html.CheckBox("booking_specificDates", (Promo.Dia_Promo <> 0 And Promo.Dia_Promo <> 127), New With {.Value = Promo.Dia_Promo, .Class = "toggleSection"})
            @Html.HiddenFor(Function(m) m.Dias_Promo, New With {.Value = Promo.Dia_Promo, .Id = "Booking_Dias"})
            <label for="booking_specificDates" @IIf(Promo.Dia_Promo <> 0 And Promo.Dia_Promo <> 127, "class=on", "")> @Resources.Dictionary.disSpecificDays. </label><div class="help_tip" id="help_specificDate" ></div>
                <ul class="sectionBox @IIf(Promo.Dia_Promo <> 0 And Promo.Dia_Promo <> 127, "on", "off")" id="specificDates" >
                    <li class="day  @IIf(dayPromo(6) = 1, "checked", "") "><span @IIf(dayPromo(6) = 1, "class=on", "") ) >@Resources.Dictionary.sSun</span><input class="checkbox" name="dateday" @IIf(dayPromo(6) = 1, "checked", "") value="1" type="checkbox" /></li>
                    <li class="day  @IIf(dayPromo(5) = 1, "checked", "") "><span @IIf(dayPromo(5) = 1, "class=on", "") ) >@Resources.Dictionary.sMon</span><input class="checkbox" name="dateday" @IIf(dayPromo(5) = 1, "checked", "") value="2" type="checkbox" /></li>
                    <li class="day  @IIf(dayPromo(4) = 1, "checked", "") "><span @IIf(dayPromo(4) = 1, "class=on", "") ) >@Resources.Dictionary.sTue</span><input class="checkbox" name="dateday" @IIf(dayPromo(4) = 1, "checked", "") value="3" type="checkbox" /></li>
                    <li class="day  @IIf(dayPromo(3) = 1, "checked", "") "><span @IIf(dayPromo(3) = 1, "class=on", "") ) >@Resources.Dictionary.sWed</span><input class="checkbox" name="dateday" @IIf(dayPromo(3) = 1, "checked", "") value="4" type="checkbox" /></li>
                    <li class="day  @IIf(dayPromo(2) = 1, "checked", "") "><span @IIf(dayPromo(2) = 1, "class=on", "") ) >@Resources.Dictionary.sThu</span><input class="checkbox" name="dateday" @IIf(dayPromo(2) = 1, "checked", "") value="5" type="checkbox" /></li>
                    <li class="day  @IIf(dayPromo(1) = 1, "checked", "") "><span @IIf(dayPromo(1) = 1, "class=on", "") ) >@Resources.Dictionary.sFri</span><input class="checkbox" name="dateday" @IIf(dayPromo(1) = 1, "checked", "") value="6" type="checkbox" /></li>
                    <li class="liLast day @IIf(dayPromo(0) = 1, "checked", "") "><span @IIf(dayPromo(0) = 1, "class=on", "") >@Resources.Dictionary.sSat</span><input class="checkbox" name="dateday" @IIf(dayPromo(0) = 1, "checked", "") value="7" type="checkbox" /></li>
                </ul>
            </div>*@

        @*Horas de vigencia de la promo*@
        @code
            Dim HoraInicio As String = Promo.HoraInicio.Hours.ToString("00")
            Dim MinInicio As String = Promo.HoraInicio.Minutes.ToString("00")

            Dim HoraFinal As String = Promo.HoraFinal.Hours.ToString("00")
            Dim MinFinal As String = Promo.HoraFinal.Minutes.ToString("00")
        End Code

        @*<div class="exclusiveArrivals">@Html.CheckBox("open_specificHours", (HoraInicio <> "00" And HoraFinal <> "00"), New With {.Class = "toggleSection"})
            <label for="open_specificHours" @IIf(HoraInicio <> "00" And HoraFinal <> "00", "class=on", "")> Horas del dia vigente. </label><div class="help_tip" id="help_specificArrivals" ></div>
                <ul class="sectionBox @IIf(HoraInicio <> "00" And HoraFinal <> "00", "on", "off")" id="specificHours" >
                    <div><label for="HoursWindowsDe">Hora Inicial:</label>
                        @Html.DropDownListFor(Function(m) m.HoursWindowsDe, New SelectList(hours_De, "Value", "Text", HoraInicio))
                        <span>Hrs.</span>
                        @Html.DropDownListFor(Function(m) m.MinutesWindowsDe, New selectlist(minutes_De, "Value", "Text", MinInicio))
                        <span>Min.</span>
                    </div>
                    <div>
                        <label for="HoursWindowsA">Hora Final:</label>
                        @Html.DropDownListFor(Function(m) m.HoursWindowsA, New SelectList(hours_A, "Value", "Text", HoraFinal))
                        <span>Hrs.</span>
                        @Html.DropDownListFor(Function(m) m.MinutesWindowsA, New SelectList(minutes_A, "Value", "Text", MinFinal))
                        <span>Min.</span>
                    </div>
                </ul>
            </div>*@
    </div>
</div>
<div class="sectionWindow promoType">
    <span class="sectionTitle">@Resources.Dictionary.DisPromoType</span>
    @Code
        Dim promoType As String = ""
        Dim freeKidsText As String = ""
        If Promo.Tipo_Promo.LastIndexOf("FK") >= 0 Then
            Dim promos = Promo.Tipo_Promo.Split("|")
            For Each item In promos
                If item.LastIndexOf("FK") >= 0 Then
                    freeKidsText &= item & "|"
                ElseIf item <> "" Then
                    promoType &= item & "|"
                End If
            Next
            promoType &= "FK" & "|"
        Else
            promoType = Promo.Tipo_Promo
        End If
    End Code

    @Html.HiddenFor(Function(m) m.Tipo_Promo, New With {.Value = promoType, .Id = "PromoType"})
    <ul class="tabs" id="Chck_promoType">
        <li class="active on" id="open_addValue"><input class="toggle_disabled" id="Add_Value" type="checkbox" @IIf(Promo.Tipo_Promo.Contains("AD"), "checked=checked", "") value="AD" />@Resources.Dictionary.disAddValueP</li>
        <li id="open_freeNights"><input class="toggle_disabled" id="Free_Night" type="checkbox" @IIf(Promo.Tipo_Promo.Contains("FN"), "checked=checked", "") value="FN" />@Resources.Dictionary.DisFreeNights</li>
        <li id="open_discount"><input class="toggle_disabled" id="Discount" type="checkbox" @IIf(Promo.Tipo_Promo.Contains("OF_PO") Or Promo.Tipo_Promo.Contains("OF_PE") Or Promo.Tipo_Promo.Contains("DV_PE"), "checked=checked", "") value="" />@Resources.Dictionary.DisDiscount</li>
        @If ((From l In roomsPlan Where l.Clav_Plan.ToUpper <> "EP").Count > 0 And (From l In roomsPlan Where l.Clav_Plan.ToUpper <> "BI").Count > 0) And Not String.IsNullOrEmpty(sAgesChild) Or Not String.IsNullOrEmpty(sAgesJunior) Then
            @<li id="open_freeKids"><input class="toggle_disabled" id="Free_Kids" type="checkbox" @IIf(Promo.Tipo_Promo.Contains("FK"), "checked=checked", "") value="FK" />@Resources.Dictionary.DisFreeKids</li>
        End If

    </ul>
    <div class="tabGroup">
        @*ADD VALUE*@
        @Code
            Dim disabled_AddValue = IIf(Not Promo.Tipo_Promo.Contains("AD"), "disabled=disabled", "")
        End Code
        <div class="sectionBox addValue tabContent" id="addValue">
            @*<span class="on"><input id="mergeAddValue" type="checkbox" @disabled_AddValue /><label for="mergeAddValue">@Resources.Dictionary.DisMergeAddValue.</label></span>*@
            <ul class="languageTabs">
                <li class="active" id="open_english">@Resources.Dictionary.disEnglish</li>
                <li id="open_spanish">@Resources.Dictionary.disSpanish</li>
                <li id="open_portuguese">@Resources.Dictionary.disPortuguese</li>
            </ul>
            <div class="tabGroup">
                <div class="languageContent tabContent" id="english">
                    <span class="alert">@Resources.Dictionary.disCheckText</span>
                    @Html.TextAreaFor(Function(m) m.Valor_Agregado_Ingles, New With {.Cols = 80, .Rows = 7, .Maxlength = "400", .Value = Resources.Dictionary.disInsertPromoText, disabled_AddValue})
                    <div class="translate">
                        <span>@Resources.Dictionary.disTranslate: </span>
                        <span class="on"><input checked="checked" id="etp" type="checkbox" disabled="disabled" /><label for="etp">@Resources.Dictionary.disToSpanish </label></span>
                        <span class="on"><input checked="checked" id="pte" type="checkbox" disabled="disabled" /><label for="pte">@Resources.Dictionary.disToPortuguese </label></span>
                        <span class="addSubmit" id="translateEN"> @Resources.Dictionary.disTranslate </span>
                    </div>
                </div>
                <div class=" languageContent tabContent" id="spanish" style="display:none">
                    <span class="alert">@Resources.Dictionary.disCheckText</span>
                    @Html.TextAreaFor(Function(m) m.Valor_Agregado_Espanol, New With {.Cols = 80, .Rows = 7, .Maxlength = "400", .Value = Resources.Dictionary.disInsertPromoText, disabled_AddValue})
                    @*<textarea rows="7" cols="80" @disabled_AddValue>Please insert some text here</textarea>*@
                    <div class="translate">
                        <span>@Resources.Dictionary.disTranslate: </span>
                        <span class="on"><input checked="checked" id="ete" type="checkbox" disabled="disabled" /><label for="ete">@Resources.Dictionary.disToEnglish </label></span>
                        <span class="on"><input checked="checked" id="pte" type="checkbox" disabled="disabled" /><label for="pte">@Resources.Dictionary.disToPortuguese </label></span>
                        <span class="addSubmit" id="translateES"> @Resources.Dictionary.disTranslate </span>
                    </div>
                </div>
                <div class="languageContent tabContent" id="portuguese" style="display:none">
                    <span class="alert">@Resources.Dictionary.disCheckText</span>
                    @Html.TextAreaFor(Function(m) m.Valor_Agregado_Portuguese, New With {.Cols = 80, .Rows = 7, .Maxlength = "400", .Value = Resources.Dictionary.disInsertPromoText, disabled_AddValue})
                    @*<textarea rows="7" cols="80" @disabled_AddValue>Please insert some text here</textarea>*@
                    <div class="translate">
                        <span>@Resources.Dictionary.disTranslate: </span>
                        <span class="on"><input checked="checked" id="etp" type="checkbox" disabled="disabled" /><label for="etp">@Resources.Dictionary.disToSpanish </label></span>
                        <span class="on"><input checked="checked" id="ete" type="checkbox" disabled="disabled" /><label for="ete">@Resources.Dictionary.disToEnglish </label></span>
                        <span class="addSubmit" id="translatePO"> @Resources.Dictionary.disTranslate </span>
                    </div>
                </div>
            </div>
        </div>
        @*FREE NIGHTS*@
        @Code
            Dim disabled_freeNights = IIf(Not Promo.Tipo_Promo.Contains("FN"), "disabled=disabled", "")
            Dim itemsAcumulable As List(Of SelectListItem) = New List(Of SelectListItem)
            itemsAcumulable.Add(New SelectListItem With {.Text = Resources.Dictionary.disOnly, .Value = 0, .Selected = (Promo.Acumulable = 0)})
            itemsAcumulable.Add(New SelectListItem With {.Text = Resources.Dictionary.disEvery, .Value = 1, .Selected = (Promo.Acumulable = 1)})

            Dim itemsAcumulable2 As List(Of SelectListItem) = New List(Of SelectListItem)
            itemsAcumulable2.Add(New SelectListItem With {.Text = Resources.Dictionary.disOnly, .Value = 0, .Selected = (Promo.Acumulable2 = 0)})
            itemsAcumulable2.Add(New SelectListItem With {.Text = Resources.Dictionary.disEvery, .Value = 1, .Selected = (Promo.Acumulable2 = 1)})
        End Code

        <div class="sectionBox tabContent nights off" id="freeNights">
            <div class="freeNights">
                @Html.DropDownListFor(Function(m) m.Acumulable, itemsAcumulable, New With {disabled_freeNights})
                @Html.TextBoxFor(Function(m) m.Noche_Gratis, New With {.Value = Promo.Noche_Gratis, .Id = "FreeNight", .maxlength = 2, .onkeypress = "return freeNightValidate(event)", .onkeyup = "return freeNightKeyPress(this)", disabled_freeNights})<span class="numberSymbol"> ° </span>@Resources.Dictionary.disNightbefree.
            </div>
            <div class="freeNights">
                @code
                    Dim disabled_freeNights2 = IIf(Promo.Noche_Gratis2 > 0 Or disabled_freeNights = Nothing, "", "disabled=disabled")
                End Code

                @Html.CheckBox("andNights", (Promo.Noche_Gratis2 > 0), New With {.Class = "toggleAND", disabled_freeNights2})<label for="andNights" class="andNights">@Resources.Dictionary.disAnd</label>
                @*<input class="toggleAND" id="andNights" type="checkbox" @iif(Promo.Noche_Gratis2 > 0, "checked=checked", "") @disabled_freeNights />*@
                @Html.DropDownListFor(Function(m) m.Acumulable2, itemsAcumulable2, New With {disabled_freeNights2})
                @Html.TextBoxFor(Function(m) m.Noche_Gratis2, New With {.Value = Promo.Noche_Gratis2, .maxlength = 2, .onkeypress = "return secondFreeNightValidate(event)", .onkeyup = "return secondFreeNightKeyPress(this)", disabled_freeNights2})<span class="numberSymbol"> ° </span>@Resources.Dictionary.disNightbefree.
            </div>
            <span class="lastNight">
                @Code Dim lastNightChk = IIf(Promo.Ultima_Gratis = 1, ".Checked=True", "")End Code

                @Html.CheckBox("freeLastNight", (Promo.Ultima_Gratis = 1), New With {.Value = (Promo.Ultima_Gratis = 1), disabled_freeNights})
                @Html.HiddenFor(Function(m) m.Ultima_Gratis, New With {.Value = (Promo.Ultima_Gratis = 1)})<label for="freeLastNight">@Resources.Dictionary.disLastNightbefree.</label>
            </span>
            @*<input id="freeLastNight" type="checkbox" @IIf(Promo.Ultima_Gratis = 1, "checked=checked", "") @disabled_freeNights/> *@
        </div>

        @*DISCOUNT*@
        @Code
            Dim disabled_Discount = IIf(Not Promo.Tipo_Promo.Contains("OF_PO") And Not Promo.Tipo_Promo.Contains("DV_PE") And Not Promo.Tipo_Promo.Contains("OF_PE"), "disabled=disabled", "")
            Dim disabledDiscount = IIf(Not Promo.Tipo_Promo.Contains("OF_PO") And Not Promo.Tipo_Promo.Contains("DV_PE") And Not Promo.Tipo_Promo.Contains("OF_PE"), New With {.Disabled = "disabled"}, Nothing)

        End Code
        <div class="sectionBox tabContent discount off" id="discount">
            <div class="discountOptions">
                <span>
                    <input name="discount" id="discPercentage" type="radio" @IIf(Promo.Tipo_Promo.Contains("OF_PO"), "checked=checked", "") @disabled_Discount value="OF_PO" />
                    <label for="discPercentage">% (@Resources.Dictionary.disPercentage) </label>
                    <div class="help_tip" id="help_discPercentage"></div>
                </span>
                <span @(IIf(IsDifeMoneda Or contractPromo.Count > 1, "style=display:none;", ""))>
                    <input name="discount" id="specialRate" type="radio" @IIf(Promo.Tipo_Promo.Contains("DV_PE"), "checked=checked", "") @disabled_Discount value="DV_PE" />
                    <label for="specialRate">@Resources.Dictionary.DisTarifaSpecial </label><div class="help_tip" id="help_specialRate"></div>
                    @If Session("IsSuperUser") Then
                        @<span style="margin: 0px;">
                            <label style="margin-left: 5px; margin-right: 3px; font-size: 11px; font-weight: bold;">(MarkUp)</label>
                            <input id="MarkUp_DV_PE" type="text" style="width: 65px;" value="@(Double.Parse(ListaContratos(3)).ToString("C", ci).Replace(nfi.CurrencySymbol, ""))" />
                            <img src="@Url.Content("~/Content/themes/base/images/ic_apply.png")" id="btnSetMarkUp">
                        </span>
                    End If
                </span>
                <span @(IIf(IsDifeMoneda, "style=display:none;", ""))>
                    <input name="discount" id="discAmount" type="radio" @IIf(Promo.Tipo_Promo.Contains("OF_PE"), "checked=checked", "") @disabled_Discount value="OF_PE" />
                    <label for="discAmount">- $ (@Resources.Dictionary.disAmount) </label>
                    <div class="help_tip" id="help_discAmount"></div>
                </span>
            </div>
            <div class="discountDetail" style="float:left;">
                @code
                    'If PlanRooms = "EP" Then
                    If ((From Pln In roomsPlan Where Pln.Clav_Plan = "EP").Count > 0 Or (From Pln In roomsPlan Where Pln.Clav_Plan = "BI").Count > 0) Then
                        @<div class="tableEP" @IIf((From lpr In ListPromoRoom Where lpr.Clav_plan = "EP").Count > 0 Or (From lpr In ListPromoRoom Where lpr.Clav_plan = "BI").Count > 0, "", "style=display:none;")>
                            <div class="tableRow">
                                <div class="check">
                                    <input class="chk_All" type="checkbox" @disabled_Discount />
                                </div>
                                <div class="col">
                                    <span>@Resources.Dictionary.disRoomRate</span>
                                    @Html.TextBox("Head_DisRate", (IIf(Promo.Tipo_Promo.Contains("OF_PO"), "%", "$")), New With {disabled_Discount})
                                    <img id="btnSetDisRate" class="applyBtn" src="@Url.Content("~/Content/themes/base/images/ic_apply.png")" lang="@(IIf(Promo.Tipo_Promo.Contains("OF_PO"), "%", IIf(Promo.Tipo_Promo.Contains("OF_PE"), "$", "")))" />
                                </div>
                                <div class="col">
                                    @If showExtras Then
                                        @<span>@Resources.Dictionary.DisExtraPerson (s)</span>
                                        @Html.TextBox("Head_DisExtra", (IIf(Promo.Tipo_Promo.Contains("OF_PO"), "%", "$")), New With {disabled_Discount})
                                        @<img id="btnSetDisExtra" class="applyBtn" src="@Url.Content("~/Content/themes/base/images/ic_apply.png")" lang="@(IIf(Promo.Tipo_Promo.Contains("OF_PO"), "%", IIf(Promo.Tipo_Promo.Contains("OF_PE"), "$", "")))" />
                                    End If
                                </div>
                            </div>
                            @For i As Integer = 0 To roomsPlan.Count - 1
                                Dim cssClavCuarto = Utilities.WithOutSpecialChars(roomsPlan(i).Clav_Cuarto)

                                Dim hasPromo As Boolean = False
                                Dim hide_DVPE = IIf(Promo.Tipo_Promo.Contains("OF_PO"), "display:none;", IIf(Promo.Tipo_Promo.Contains("DV_PE"), IIf(Not EsNeta Or Session("IsSuperUser"), "", "display:none;"), IIf((Promo.Tipo_Promo.Contains("OF_PE") And Not EsNeta), "", "display:none;")))
                                Dim hide_OFPE = IIf((Promo.Tipo_Promo.Contains("OF_PE") And EsNeta), "", IIf(Promo.Tipo_Promo.Contains("DV_PE"), IIf(EsNeta Or Session("IsSuperUser"), "", "display:none;"), "display:none;"))
                                Dim hide_DVPO = IIf(Not Promo.Tipo_Promo.Contains("OF_PO"), "display:none;", "")


                                Dim styleHeight As String = IIf(Promo.Tipo_Promo.Contains("DV_PE"), "height: 35px;", IIf(Not Promo.Tipo_Promo.Contains("DV_PE") And Not Promo.Tipo_Promo.Contains("OF_PE") And Not Promo.Tipo_Promo.Contains("OF_PO"), "height: 35px;", "height: 18px;"))
                                'MUESTRA LAS HABITACIONES QUE TIENEN PROMOCION
                                For r As Integer = 0 To ListPromoRoom.Count - 1
                                    If (roomsPlan(i).Clav_Cuarto = ListPromoRoom(r).Clav_Cuarto And (roomsPlan(i).Clav_Plan = ListPromoRoom(r).Clav_plan And (ListPromoRoom(r).Clav_plan = "EP" Or ListPromoRoom(r).Clav_plan = "BI"))) Then
                                        'Asignacion de valores
                                        Dim _Tarifa_Neta_Porc = Double.Parse(IIf(Promo.Tipo_Promo.Contains("OF_PO"), ListPromoRoom(r).Tarifa_Neta_porc * 100, "0")).ToString("C", ci).Replace(nfi.CurrencySymbol, "")
                                        Dim _Tarifa_Neta = Double.Parse(IIf(Promo.Tipo_Promo.Contains("OF_PE") Or Promo.Tipo_Promo.Contains("DV_PE"), ListPromoRoom(r).Tarifa_Neta, "0")).ToString("C", ci).Replace(nfi.CurrencySymbol, "")
                                        Dim _Tarifa_Venta = Double.Parse(IIf(Promo.Tipo_Promo.Contains("OF_PE") Or Promo.Tipo_Promo.Contains("DV_PE"), ListPromoRoom(r).Tarifa_Venta, "0")).ToString("C", ci).Replace(nfi.CurrencySymbol, "")

                                        Dim _Extra_Neta_Porc = Double.Parse(IIf(Promo.Tipo_Promo.Contains("OF_PO"), ListPromoRoom(r).Extra_Neta_porc * 100, "0")).ToString("C", ci).Replace(nfi.CurrencySymbol, "")
                                        Dim _Extra_Neta = Double.Parse(IIf(Promo.Tipo_Promo.Contains("OF_PE") Or Promo.Tipo_Promo.Contains("DV_PE"), ListPromoRoom(r).Extra_Neta, "0")).ToString("C", ci).Replace(nfi.CurrencySymbol, "")
                                        Dim _Extra_Venta = Double.Parse(IIf(Promo.Tipo_Promo.Contains("OF_PE") Or Promo.Tipo_Promo.Contains("DV_PE"), ListPromoRoom(r).Extra_Venta, "0")).ToString("C", ci).Replace(nfi.CurrencySymbol, "")

                                        @<div class="rowRates roomsDiscount @String.Format("{0}_{1}", cssClavCuarto, roomsPlan(i).Clav_Plan)">
                                            <div class="roomName">@roomsPlan(i).Nombre_Cuarto -  @roomsPlan(i).Nombre_Plan</div>
                                            <div class="tableRow">

                                                <div class="checkRow" style="@styleHeight">
                                                    @If Promo.Booking_Window_A Is Nothing Or Promo.Booking_Window_A >= Now Then
                                                        @Html.HiddenFor(Function(m) m.roomRates(i).Consecutivo, New With {.Value = ListPromoRoom(r).Consecutivo})
                                                    End If
                                                    <input id="chk_@(i)_@(cssClavCuarto)" type="checkbox" @disabled_Discount />
                                                </div>
                                                <div class="td rr_@(i)_@(cssClavCuarto)" style="@styleHeight">
                                                    @If Session("IsSuperUser") Then 'Si es MarketManager, muestra todo
                                                        @<span class="notif" @IIf(hide_DVPO = "" Or hide_OFPE = "", "", "style=display:none;")>@IIf(Promo.Tipo_Promo.Contains("OF_PO") And Not EsNeta, "V", "N") </span>
                                                        @Html.TextBoxFor(Function(m) m.roomRates(i).Tarifa_Neta_porc, New With {.Value = _Tarifa_Neta_Porc, .Class = "rtsPorcent", disabled_Discount, .Style = hide_DVPO})
                                                        @Html.TextBoxFor(Function(m) m.roomRates(i).Tarifa_Neta, New With {.Value = _Tarifa_Neta, .Class = "rtsMount", disabled_Discount, .Style = hide_OFPE})
                                                        @<span class="tMoneda" @IIf(hide_DVPO = "" Or hide_OFPE = "", "", "style=display:none;")> @Unit_Discount</span>
                                                        @<div class="rVenta" style="float: left; padding-top: 4px; width: 100%; @hide_DVPE">
                                                            <span class="notif">V </span>
                                                            @Html.TextBoxFor(Function(m) m.roomRates(i).Tarifa_Venta, New With {.Value = _Tarifa_Venta, disabled_Discount, .Class = "rtsVent"})
                                                            <span class="tMoneda"> @Unit_Discount</span>
                                                        </div>
                                                    Else
                                                        'If notif_Type <> "V" Then 'No ve la pública, ve la neta
                                                        @<span class="notif">@(IIf(EsNeta, "N", "V")) </span>
                                                        @Html.TextBoxFor(Function(m) m.roomRates(i).Tarifa_Neta_porc, New With {.Value = _Tarifa_Neta_Porc, .Class = "rtsPorcent", disabled_Discount, .Style = hide_DVPO})
                                                        @Html.TextBoxFor(Function(m) m.roomRates(i).Tarifa_Neta, New With {.Value = IIf(EsNeta, _Tarifa_Neta, _Tarifa_Venta), .Class = "rtsMount", disabled_Discount, .Style = hide_OFPE & IIf(EsNeta, "", ";display:none;")})
                                                        @*<span class="tMoneda" style="@EsNeta"> @Unit_Discount</span>*@
                                                        'Else 'Ve la pública, No ve la Neta
                                                        @*<span style="@EsVenta">V </span>*@
                                                        @*Html.TextBoxFor(Function(m) m.roomRates(i).Tarifa_Neta_porc, New With {.Value = _Tarifa_Neta_Porc, .Class = "rtsPorcent", disabled_Discount, .Style = hide_DVPO})*@
                                                        @<div class="rVenta" style="float: left; @hide_DVPE @IIf(EsNeta, ";display:none;", "")">
                                                            @Html.TextBoxFor(Function(m) m.roomRates(i).Tarifa_Venta, New With {.Value = IIf(EsNeta, _Tarifa_Neta, _Tarifa_Venta), disabled_Discount, .Class = "rtsVent"})
                                                        </div>
                                                        @<span class="tMoneda"> @Unit_Discount</span>
                                                        ' End If
                                                    End If
                                                </div>
                                                <div class="td ep_@(i)_@(cssClavCuarto)" style="@styleHeight">
                                                    @If (From l In ListAgesByHotelRoom Where l.Clav_Cuarto = roomsPlan(i).Clav_Cuarto And l.Cap_Extras >= 1).Count > 0 Then
                                                        If Session("IsSuperUser") Then 'Si es MarketManager, muestra todo
                                                            @<span class="notif" @IIf(hide_DVPO = "" Or hide_OFPE = "", "", "style=display:none;")>@IIf(Promo.Tipo_Promo.Contains("OF_PO") And Not EsNeta, "V", "N") </span>
                                                            @Html.TextBoxFor(Function(m) m.roomRates(i).Extra_Neta_porc, New With {.Value = _Extra_Neta_Porc, .Class = "rtsPorcent", disabled_Discount, .Style = hide_DVPO})
                                                            @Html.TextBoxFor(Function(m) m.roomRates(i).Extra_Neta, New With {.Value = _Extra_Neta, .Class = "rtsMount", disabled_Discount, .Style = hide_OFPE})
                                                            @<span class="tMoneda" @IIf(hide_DVPO = "" Or hide_OFPE = "", "", "style=display:none;")> @Unit_Discount</span>
                                                            @<div class="rVenta" style="float: left; padding-top: 4px; width: 100%; @hide_DVPE">
                                                                <span class="notif">V </span>
                                                                @Html.TextBoxFor(Function(m) m.roomRates(i).Extra_Venta, New With {.Value = _Extra_Venta, disabled_Discount, .Class = "rtsVent"})
                                                                <span class="tMoneda"> @Unit_Discount</span>
                                                            </div>
                                                        Else
                                                            'If notif_Type <> "V" Then 'No ve la pública, ve la neta
                                                            @<span class="notif">@(IIf(EsNeta, "N", "V")) </span>
                                                            @Html.TextBoxFor(Function(m) m.roomRates(i).Extra_Neta_porc, New With {.Value = _Extra_Neta_Porc, .Class = "rtsPorcent", disabled_Discount, .Style = hide_DVPO})
                                                            @Html.TextBoxFor(Function(m) m.roomRates(i).Extra_Neta, New With {.Value = IIf(EsNeta, _Extra_Neta, _Extra_Venta), .Class = "rtsMount", disabled_Discount, .Style = hide_OFPE & IIf(EsNeta, "", ";display:none;")})
                                                            @*<span class="tMoneda"> @Unit_Discount</span>*@
                                                            'Else 'Ve la pública, No ve la Neta
                                                            @*<span>V </span>*@
                                                            @*Html.TextBoxFor(Function(m) m.roomRates(i).Extra_Neta_porc, New With {.Value = _Extra_Neta_Porc, .Class = "rtsPorcent", disabled_Discount, .Style = hide_DVPO})*@
                                                            @<div class="rVenta" style="float: left; @hide_DVPE @IIf(EsNeta, ";display:none;", "")">
                                                                @Html.TextBoxFor(Function(m) m.roomRates(i).Extra_Venta, New With {.Value = IIf(EsNeta, _Extra_Neta, _Extra_Venta), disabled_Discount, .Class = "rtsVent"})
                                                            </div>
                                                            @<span class="tMoneda"> @Unit_Discount</span>
                                                            'End If
                                                        End If
                                                    End If
                                                </div>
                                            </div>
                                        </div>
                                        hasPromo = True
                                        Exit For
                                    End If
                                Next
                                'MUESTRA LAS HABITACIONES DEL CONTRATO y no tiene promo
                                If Not hasPromo And (roomsPlan(i).Clav_Plan = "EP" Or roomsPlan(i).Clav_Plan = "BI") Then
                                    @<div class="rowRates roomsDiscount @String.Format("{0}_{1}", cssClavCuarto, roomsPlan(i).Clav_Plan)" style="display:none">
                                        <div class="roomName">@roomsPlan(i).Nombre_Cuarto -  @roomsPlan(i).Nombre_Plan</div>
                                        <div class="tableRow">
                                            <div class="checkRow" style="@styleHeight">
                                                <input id="chk_@(i)_@(cssClavCuarto)" type="checkbox" @disabled_Discount />
                                            </div>
                                            <div class="td rr_@(i)_@(cssClavCuarto)" style="@styleHeight">
                                                @If Session("IsSuperUser") Then 'Si es MarketManager, muestra todo
                                                    @<span class="notif" @IIf(hide_DVPO = "" Or hide_OFPE = "", "", "style=display:none;")>@IIf(Promo.Tipo_Promo.Contains("OF_PO") And Not EsNeta, "V", "N") </span>
                                                    @Html.TextBoxFor(Function(m) m.roomRates(i).Tarifa_Neta_porc, New With {.Value = "0", .Class = "rtsPorcent", disabled_Discount, .Style = hide_DVPO})
                                                    @Html.TextBoxFor(Function(m) m.roomRates(i).Tarifa_Neta, New With {.Value = "0", .Class = "rtsMount", disabled_Discount, .Style = hide_OFPE})
                                                    @<span class="tMoneda" @IIf(hide_DVPO = "" Or hide_OFPE = "", "", "style=display:none;")> @Unit_Discount</span>
                                                    @<div class="rVenta" style="float: left; padding-top: 4px; width: 100%; @hide_DVPE">
                                                        <span class="notif">V </span>
                                                        @Html.TextBoxFor(Function(m) m.roomRates(i).Tarifa_Venta, New With {.Value = "0", disabled_Discount, .Class = "rtsVent"})
                                                        <span class="tMoneda"> @Unit_Discount</span>
                                                    </div>
                                                Else
                                                    'If notif_Type <> "V" Then 'No ve la pública, ve la neta
                                                    @<span class="notif">@(IIf(EsNeta, "N", "V")) </span>
                                                    @Html.TextBoxFor(Function(m) m.roomRates(i).Tarifa_Neta_porc, New With {.Value = "0", .Class = "rtsPorcent", disabled_Discount, .Style = hide_DVPO})
                                                    @Html.TextBoxFor(Function(m) m.roomRates(i).Tarifa_Neta, New With {.Value = "0", .Class = "rtsMount", disabled_Discount, .Style = hide_OFPE & IIf(EsNeta, "", ";display:none;")})
                                                    @*<span class="tMoneda"> @Unit_Discount</span>*@
                                                    'Else 'Ve la pública, No ve la Neta
                                                    @*<span>V </span>*@
                                                    @*Html.TextBoxFor(Function(m) m.roomRates(i).Tarifa_Neta_porc, New With {.Value = "0", .Class = "rtsPorcent", disabled_Discount, .Style = hide_DVPO})*@
                                                    @<div class="rVenta" style="float: left; @hide_DVPE @IIf(EsNeta, ";display:none;", "")">
                                                        @Html.TextBoxFor(Function(m) m.roomRates(i).Tarifa_Venta, New With {.Value = "0", disabled_Discount, .Class = "rtsVent"})
                                                    </div>
                                                    @<span class="tMoneda"> @Unit_Discount</span>
                                                    'End If
                                                End If
                                            </div>
                                            <div class="td ep_@(i)_@(cssClavCuarto)" style="@styleHeight">
                                                @If (From l In ListAgesByHotelRoom Where l.Clav_Cuarto = roomsPlan(i).Clav_Cuarto And l.Cap_Extras >= 1).Count > 0 Then
                                                    If Session("IsSuperUser") Then 'Si es MarketManager, muestra todo
                                                        @<span class="notif" @IIf(hide_DVPO = "" Or hide_OFPE = "", "", "style=display:none;")>@IIf(Promo.Tipo_Promo.Contains("OF_PO") And Not EsNeta, "V", "N") </span>
                                                        @Html.TextBoxFor(Function(m) m.roomRates(i).Extra_Neta_porc, New With {.Value = "0", .Class = "rtsPorcent", disabled_Discount, .Style = hide_DVPO})
                                                        @Html.TextBoxFor(Function(m) m.roomRates(i).Extra_Neta, New With {.Value = "0", .Class = "rtsMount", disabled_Discount, .Style = hide_OFPE})
                                                        @<span class="tMoneda" @IIf(hide_DVPO = "" Or hide_OFPE = "", "", "style=display:none;")> @Unit_Discount</span>
                                                        @<div class="rVenta" style="float: left; padding-top: 4px; width: 100%; @hide_DVPE">
                                                            <span class="notif">V </span>
                                                            @Html.TextBoxFor(Function(m) m.roomRates(i).Extra_Venta, New With {.Value = "0", disabled_Discount, .Class = "rtsVent"})
                                                            <span class="tMoneda"> @Unit_Discount</span>
                                                        </div>
                                                    Else
                                                        'If notif_Type <> "V" Then 'No ve la pública, ve la neta
                                                        @<span class="notif">@(IIf(EsNeta, "N", "V")) </span>
                                                        @Html.TextBoxFor(Function(m) m.roomRates(i).Extra_Neta_porc, New With {.Value = "0", .Class = "rtsPorcent", disabled_Discount, .Style = hide_DVPO})
                                                        @Html.TextBoxFor(Function(m) m.roomRates(i).Extra_Neta, New With {.Value = "0", .Class = "rtsMount", disabled_Discount, .Style = hide_OFPE & IIf(EsNeta, "", ";display:none;")})
                                                        @*<span class="tMoneda"> @Unit_Discount</span>*@
                                                        'Else 'Ve la pública, No ve la Neta
                                                        @*<span>V </span>*@
                                                        @*Html.TextBoxFor(Function(m) m.roomRates(i).Extra_Neta_porc, New With {.Value = "0",.Class = "rtsPorcent", disabled_Discount, .Style = hide_DVPO})*@
                                                        @<div class="rVenta" style="float: left; @hide_DVPE @IIf(EsNeta, ";display:none;", "")">
                                                            @Html.TextBoxFor(Function(m) m.roomRates(i).Extra_Venta, New With {.Value = "0", disabled_Discount, .Class = "rtsVent"})
                                                        </div>
                                                        @<span class="tMoneda"> @Unit_Discount</span>
                                                        'End If
                                                    End If
                                                End If
                                            </div>
                                        </div>
                                    </div>
                                End If
                            Next

                            @TextoCargaTarifas(Session("TipoCarga"), "EP")
                        </div>

                    End If
                    If ((From Pln In roomsPlan Where Pln.Clav_Plan <> "EP").Count > 0 And (From Pln In roomsPlan Where Pln.Clav_Plan <> "BI").Count > 0) Then
                        @<div class="table" @IIf((From lpr In ListPromoRoom Where lpr.Clav_plan <> "EP").Count > 0 And (From lpr In ListPromoRoom Where lpr.Clav_plan <> "BI").Count > 0, "", "style=display:none;")>
                            <div class="tableRow">
                                <div class="check" style="height: 35px; width: 60px;">
                                    <input class="chk_All" type="checkbox" @disabled_Discount />
                                </div>
                                <div class="col">
                                    <span>SGL</span>
                                    @Html.TextBox("Head_Single", (IIf(Promo.Tipo_Promo.Contains("OF_PO"), "%", "$")), New With {disabledDiscount})
                                    <img id="btnSetSingleRate" class="applyBtn" src="@Url.Content("~/Content/themes/base/images/ic_apply.png")" lang="@(IIf(Promo.Tipo_Promo.Contains("OF_PO"), "%", IIf(Promo.Tipo_Promo.Contains("OF_PE"), "$", "")))" />
                                </div>
                                <div class="col">
                                    <span>DBL</span>
                                    @Html.TextBox("Head_Dbl", (IIf(Promo.Tipo_Promo.Contains("OF_PO"), "%", "$")), New With {disabled_Discount})
                                    <img id="btnSetDblRate" class="applyBtn" src="@Url.Content("~/Content/themes/base/images/ic_apply.png")" lang="@(IIf(Promo.Tipo_Promo.Contains("OF_PO"), "%", IIf(Promo.Tipo_Promo.Contains("OF_PE"), "$", "")))" />
                                </div>
                                <div class="col">
                                    <span>TRL</span>
                                    @Html.TextBox("Head_Trl", (IIf(Promo.Tipo_Promo.Contains("OF_PO"), "%", "$")), New With {disabled_Discount})
                                    <img id="btnSetTrlRate" class="applyBtn" src="@Url.Content("~/Content/themes/base/images/ic_apply.png")" lang="@(IIf(Promo.Tipo_Promo.Contains("OF_PO"), "%", IIf(Promo.Tipo_Promo.Contains("OF_PE"), "$", "")))" />
                                </div>
                                <div class="col">
                                    <span>CUAD</span>
                                    @Html.TextBox("Head_Cuad", (IIf(Promo.Tipo_Promo.Contains("OF_PO"), "%", "$")), New With {disabled_Discount})
                                    <img id="btnSetCuadRate" class="applyBtn" src="@Url.Content("~/Content/themes/base/images/ic_apply.png")" lang="@(IIf(Promo.Tipo_Promo.Contains("OF_PO"), "%", IIf(Promo.Tipo_Promo.Contains("OF_PE"), "$", "")))" />
                                </div>
                                <div class="col">
                                    <span>Child @sAgesChild</span>
                                    @Html.TextBox("Head_Ninos", (IIf(Promo.Tipo_Promo.Contains("OF_PO"), "%", "$")), New With {disabled_Discount})
                                    <img id="btnSetNinosRate" class="applyBtn" src="@Url.Content("~/Content/themes/base/images/ic_apply.png")" lang="@(IIf(Promo.Tipo_Promo.Contains("OF_PO"), "%", IIf(Promo.Tipo_Promo.Contains("OF_PE"), "$", "")))" />
                                </div>
                                @*<div class="col"><span>Child 7 - 11</span><input type="text"/><img class="applyBtn" src="@Url.Content("~/Content/themes/base/images/ic_apply.png")"></div>*@
                                @* @If (From l In ListAgesByHotelRoom Where l.Edad_Junior <> "0 - 0").Count > 0 Then*@
                                <div class="col">
                                    <span>Jr @sAgesJunior</span>
                                    @Html.TextBox("Head_Junior", (IIf(Promo.Tipo_Promo.Contains("OF_PO"), "%", "$")), New With {disabled_Discount})
                                    <img id="btnSetJuniorRate" class="applyBtn" src="@Url.Content("~/Content/themes/base/images/ic_apply.png")" lang="@(IIf(Promo.Tipo_Promo.Contains("OF_PO"), "%", IIf(Promo.Tipo_Promo.Contains("OF_PE"), "$", "")))" />
                                </div>
                                @*end if*@
                            </div>
                            @For i As Integer = 0 To roomsPlan.Count - 1
                                Dim cssClavCuarto = Utilities.WithOutSpecialChars(roomsPlan(i).Clav_Cuarto)
                                Dim hasPromo As Boolean = False
                                Dim hide_DVPE = IIf(Promo.Tipo_Promo.Contains("OF_PO"), "display:none;", IIf(Promo.Tipo_Promo.Contains("DV_PE"), IIf(Not EsNeta Or Session("IsSuperUser"), "", "display:none;"), IIf((Promo.Tipo_Promo.Contains("OF_PE") And Not EsNeta), "", "display:none;")))
                                Dim hide_OFPE = IIf((Promo.Tipo_Promo.Contains("OF_PE") And EsNeta), "", IIf(Promo.Tipo_Promo.Contains("DV_PE"), IIf(EsNeta Or Session("IsSuperUser"), "", "display:none;"), "display:none;"))
                                Dim hide_DVPO = IIf(Not Promo.Tipo_Promo.Contains("OF_PO"), "display:none;", "")
                                Dim styleHeight As String = IIf(Promo.Tipo_Promo.Contains("DV_PE"), "height: 35px;", IIf(Not Promo.Tipo_Promo.Contains("DV_PE") And Not Promo.Tipo_Promo.Contains("OF_PE") And Not Promo.Tipo_Promo.Contains("OF_PO"), "height: 35px;", "height: 18px;"))


                                'MUESTRA LA HABITACION QUE TIENEN PROMOCION
                                For r As Integer = 0 To ListPromoRoom.Count - 1
                                    If (roomsPlan(i).Clav_Cuarto = ListPromoRoom(r).Clav_Cuarto And (roomsPlan(i).Clav_Plan = ListPromoRoom(r).Clav_plan And (ListPromoRoom(r).Clav_plan <> "EP" And ListPromoRoom(r).Clav_plan <> "BI"))) Then
                                        'Asignando Valores
                                        Dim TipoPromociones = Promo.Tipo_Promo.Split("|")

                                        Dim _Sencillo_Neta_porc = Double.Parse(IIf(Promo.Tipo_Promo.Contains("OF_PO"), IIf(ListPromoRoom(r).Tarifa_Neta_porc = 0, ListPromoRoom(r).Sencillo_Neta_porc * 100, ListPromoRoom(r).Tarifa_Neta_porc * 100), "0")).ToString("C", ci).Replace(nfi.CurrencySymbol, "")
                                        Dim _Sencillo_Neta = Double.Parse(IIf(Promo.Tipo_Promo.Contains("OF_PE") Or Promo.Tipo_Promo.Contains("DV_PE"), ListPromoRoom(r).Sencillo_Neta, "0")).ToString("C", ci).Replace(nfi.CurrencySymbol, "")
                                        Dim _Sencillo_Venta = Double.Parse(IIf(Promo.Tipo_Promo.Contains("OF_PE") Or Promo.Tipo_Promo.Contains("DV_PE"), ListPromoRoom(r).Sencillo_Venta, "0")).ToString("C", ci).Replace(nfi.CurrencySymbol, "")

                                        Dim _Double_Neta_porc = Double.Parse(IIf(Promo.Tipo_Promo.Contains("OF_PO"), IIf(ListPromoRoom(r).Tarifa_Neta_porc = 0, ListPromoRoom(r).Double_Neta_porc * 100, ListPromoRoom(r).Tarifa_Neta_porc * 100), "0")).ToString("C", ci).Replace(nfi.CurrencySymbol, "")
                                        Dim _Double_Neta = Double.Parse(IIf(Promo.Tipo_Promo.Contains("OF_PE") Or Promo.Tipo_Promo.Contains("DV_PE"), ListPromoRoom(r).Doble_Neta, "0")).ToString("C", ci).Replace(nfi.CurrencySymbol, "")
                                        Dim _Double_Venta = Double.Parse(IIf(Promo.Tipo_Promo.Contains("OF_PE") Or Promo.Tipo_Promo.Contains("DV_PE"), ListPromoRoom(r).Double_Venta, "0")).ToString("C", ci).Replace(nfi.CurrencySymbol, "")

                                        Dim _Triple_Neta_porc = Double.Parse(IIf(Promo.Tipo_Promo.Contains("OF_PO"), IIf(ListPromoRoom(r).Tarifa_Neta_porc = 0, ListPromoRoom(r).Triple_Neta_porc * 100, ListPromoRoom(r).Tarifa_Neta_porc * 100), "0")).ToString("C", ci).Replace(nfi.CurrencySymbol, "")
                                        Dim _Triple_Neta = Double.Parse(IIf(Promo.Tipo_Promo.Contains("OF_PE") Or Promo.Tipo_Promo.Contains("DV_PE"), ListPromoRoom(r).Triple_Neta, "0")).ToString("C", ci).Replace(nfi.CurrencySymbol, "")
                                        Dim _Triple_Venta = Double.Parse(IIf(Promo.Tipo_Promo.Contains("OF_PE") Or Promo.Tipo_Promo.Contains("DV_PE"), ListPromoRoom(r).Triple_Venta, "0")).ToString("C", ci).Replace(nfi.CurrencySymbol, "")

                                        Dim _Cuadruple_Neta_porc = Double.Parse(IIf(Promo.Tipo_Promo.Contains("OF_PO"), IIf(ListPromoRoom(r).Tarifa_Neta_porc = 0, ListPromoRoom(r).Cuadruple_Neta_porc * 100, ListPromoRoom(r).Tarifa_Neta_porc * 100), "0")).ToString("C", ci).Replace(nfi.CurrencySymbol, "")
                                        Dim _Cuadruple_Neta = Double.Parse(IIf(Promo.Tipo_Promo.Contains("OF_PE") Or Promo.Tipo_Promo.Contains("DV_PE"), ListPromoRoom(r).Cuadruple_Neta, "0")).ToString("C", ci).Replace(nfi.CurrencySymbol, "")
                                        Dim _Cuadruple_Venta = Double.Parse(IIf(Promo.Tipo_Promo.Contains("OF_PE") Or Promo.Tipo_Promo.Contains("DV_PE"), ListPromoRoom(r).Cuadruple_Venta, "0")).ToString("C", ci).Replace(nfi.CurrencySymbol, "")

                                        Dim _Ninos_Neta_porc = Double.Parse(IIf(Promo.Tipo_Promo.Contains("OF_PO") Or TipoPromociones.Contains("FK") Or TipoPromociones.Contains("FKN"), IIf(ListPromoRoom(r).Tarifa_Neta_porc = 0, ListPromoRoom(r).Ninos_Neta_porc * 100, ListPromoRoom(r).Tarifa_Neta_porc * 100), "0")).ToString("C", ci).Replace(nfi.CurrencySymbol, "")
                                        Dim _Ninos_Neta = Double.Parse(IIf(Promo.Tipo_Promo.Contains("OF_PE") Or Promo.Tipo_Promo.Contains("DV_PE"), ListPromoRoom(r).Ninos_Neta, "0")).ToString("C", ci).Replace(nfi.CurrencySymbol, "")
                                        Dim _Ninos_Venta = Double.Parse(IIf(Promo.Tipo_Promo.Contains("OF_PE") Or Promo.Tipo_Promo.Contains("DV_PE"), ListPromoRoom(r).Ninos_Venta, "0")).ToString("C", ci).Replace(nfi.CurrencySymbol, "")

                                        Dim _Junior_Neta_porc = Double.Parse(IIf(Promo.Tipo_Promo.Contains("OF_PO") Or TipoPromociones.Contains("FK") Or TipoPromociones.Contains("FKJ"), IIf(ListPromoRoom(r).Tarifa_Neta_porc = 0, ListPromoRoom(r).Junior_Neta_porc * 100, ListPromoRoom(r).Tarifa_Neta_porc * 100), "0")).ToString("C", ci).Replace(nfi.CurrencySymbol, "")
                                        Dim _Junior_Neta = Double.Parse(IIf(Promo.Tipo_Promo.Contains("OF_PE") Or Promo.Tipo_Promo.Contains("DV_PE"), ListPromoRoom(r).Junior_Neta, "0")).ToString("C", ci).Replace(nfi.CurrencySymbol, "")
                                        Dim _Junior_Venta = Double.Parse(IIf(Promo.Tipo_Promo.Contains("OF_PE") Or Promo.Tipo_Promo.Contains("DV_PE"), ListPromoRoom(r).Junior_Venta, "0")).ToString("C", ci).Replace(nfi.CurrencySymbol, "")

                                        @<div class="rowRates @String.Format("{0}_{1}", cssClavCuarto, roomsPlan(i).Clav_Plan)">
                                            <div class="roomName">@roomsPlan(i).Nombre_Cuarto -  @roomsPlan(i).Nombre_Plan</div>
                                            <div class="tableRow">
                                                <div class="checkRow" style="width: 60px; @styleHeight">
                                                    @If Promo.Booking_Window_A Is Nothing Or Promo.Booking_Window_A >= Now Then
                                                        @Html.HiddenFor(Function(m) m.roomRates(i).Consecutivo, New With {.Value = ListPromoRoom(r).Consecutivo})
                                                    End If
                                                    <input id="chk_@(i)_@(cssClavCuarto)" type="checkbox" @disabled_Discount />
                                                </div>

                                                @If (From l In ListAgesByHotelRoom Where l.Clav_Cuarto = roomsPlan(i).Clav_Cuarto And (l.Cap_Adultos) >= 1).Count > 0 Then
                                                    @<div class="td sgl_@(i)_@(cssClavCuarto)" style="@styleHeight">
                                                        @If Session("IsSuperUser") Then 'Si es MarketManager, muestra todo
                                                            @<span class="notif" @IIf(hide_DVPO = "" Or hide_OFPE = "", "", "style=display:none;")>@IIf(Promo.Tipo_Promo.Contains("OF_PO") And Not EsNeta, "V", "N") </span>
                                                            @Html.TextBoxFor(Function(m) m.roomRates(i).Sencillo_Neta_porc, New With {.Value = _Sencillo_Neta_porc, .Class = "rtsPorcent", disabled_Discount, .Style = hide_DVPO})
                                                            @Html.TextBoxFor(Function(m) m.roomRates(i).Sencillo_Neta, New With {.Value = _Sencillo_Neta, .Class = "rtsMount", disabled_Discount, .Style = hide_OFPE})
                                                            @<span class="tMoneda" @IIf(hide_DVPO = "" Or hide_OFPE = "", "", "style=display:none;")> @Unit_Discount</span>
                                                            @<div class="rVenta" style="float: left; padding-top: 4px; width: 100%; @hide_DVPE">
                                                                <span class="notif">V </span>
                                                                @Html.TextBoxFor(Function(m) m.roomRates(i).Sencillo_Venta, New With {.Value = _Sencillo_Venta, .Class = "rtsVent", disabled_Discount})
                                                                <span class="tMoneda"> @Unit_Discount</span>
                                                            </div>
                                                        Else
                                                            'If notif_Type <> "V" Then 'No ve la pública, ve la neta
                                                            @<span class="notif">@(IIf(EsNeta, "N", "V")) </span>
                                                            @Html.TextBoxFor(Function(m) m.roomRates(i).Sencillo_Neta_porc, New With {.Value = _Sencillo_Neta_porc, .Class = "rtsPorcent", disabled_Discount, .Style = hide_DVPO})
                                                            @Html.TextBoxFor(Function(m) m.roomRates(i).Sencillo_Neta, New With {.Value = IIf(EsNeta, _Sencillo_Neta, _Sencillo_Venta), .Class = "rtsMount", disabled_Discount, .Style = hide_OFPE & IIf(EsNeta, "", ";display:none;")})
                                                            @*<span class="tMoneda"> @Unit_Discount</span>*@
                                                            'Else 'Ve la pública, No ve la Neta
                                                            @*<span class="notif" style="@EsVenta">V </span>*@
                                                            @*Html.TextBoxFor(Function(m) m.roomRates(i).Sencillo_Neta_porc, New With {.Value = _Sencillo_Neta_porc, .Class = "rtsPorcent", disabled_Discount, .Style = hide_DVPO})*@
                                                            @<div class="rVenta" style="float: left; @hide_DVPE  @IIf(EsNeta, ";display:none;", "")">
                                                                @Html.TextBoxFor(Function(m) m.roomRates(i).Sencillo_Venta, New With {.Value = IIf(EsNeta, _Sencillo_Neta, _Sencillo_Venta), .Class = "rtsVent", disabled_Discount})
                                                            </div>
                                                            @<span class="tMoneda"> @Unit_Discount</span>
                                                            'End If
                                                        End If
                                                    </div>
                                                Else
                                                    @<div class="td sgl_@(i)_@(cssClavCuarto)" style="background: #EEEEEE; @styleHeight"></div>
                                                End If
                                                @If (From l In ListAgesByHotelRoom Where l.Clav_Cuarto = roomsPlan(i).Clav_Cuarto And (l.Cap_Adultos) >= 2).Count > 0 Then
                                                    @<div class="td dbl_@(i)_@(cssClavCuarto)" style="@styleHeight">
                                                        @If Session("IsSuperUser") Then 'Si es MarketManager, muestra todo
                                                            @<span class="notif" @IIf(hide_DVPO = "" Or hide_OFPE = "", "", "style=display:none;")>@IIf(Promo.Tipo_Promo.Contains("OF_PO") And Not EsNeta, "V", "N") </span>
                                                            @Html.TextBoxFor(Function(m) m.roomRates(i).Double_Neta_porc, New With {.Value = _Double_Neta_porc, .Class = "rtsPorcent", disabled_Discount, .Style = hide_DVPO})
                                                            @Html.TextBoxFor(Function(m) m.roomRates(i).Doble_Neta, New With {.Value = _Double_Neta, .Class = "rtsMount", disabled_Discount, .Style = hide_OFPE})
                                                            @<span class="tMoneda" @IIf(hide_DVPO = "" Or hide_OFPE = "", "", "style=display:none;")> @Unit_Discount</span>
                                                            @<div class="rVenta" style="float: left; padding-top: 4px; width: 100%; @hide_DVPE">
                                                                <span class="notif">V </span>
                                                                @Html.TextBoxFor(Function(m) m.roomRates(i).Double_Venta, New With {.Value = _Double_Venta, .Class = "rtsVent", disabled_Discount})
                                                                <span class="tMoneda"> @Unit_Discount</span>
                                                            </div>
                                                        Else
                                                            'If notif_Type <> "V" Then 'No ve la pública, ve la neta
                                                            @<span class="notif">@(IIf(EsNeta, "N", "V")) </span>
                                                            @Html.TextBoxFor(Function(m) m.roomRates(i).Double_Neta_porc, New With {.Value = _Double_Neta_porc, .Class = "rtsPorcent", disabled_Discount, .Style = hide_DVPO})
                                                            @Html.TextBoxFor(Function(m) m.roomRates(i).Doble_Neta, New With {.Value = IIf(EsNeta, _Double_Neta, _Double_Venta), .Class = "rtsMount", disabled_Discount, .Style = hide_OFPE & IIf(EsNeta, "", ";display:none;")})
                                                            @*<span class="tMoneda"> @Unit_Discount</span>*@
                                                            'Else 'Ve la pública, No ve la Neta
                                                            @*<span>V </span>*@
                                                            @*Html.TextBoxFor(Function(m) m.roomRates(i).Double_Neta_porc, New With {.Value = _Double_Neta_porc, .Class = "rtsPorcent", disabled_Discount, .Style = hide_DVPO})*@
                                                            @<div class="rVenta" style="float: left; @hide_DVPE @IIf(EsNeta, ";display:none;", "")">
                                                                @Html.TextBoxFor(Function(m) m.roomRates(i).Double_Venta, New With {.Value = IIf(EsNeta, _Double_Neta, _Double_Venta), .Class = "rtsVent", disabled_Discount})
                                                            </div>
                                                            @<span class="tMoneda"> @Unit_Discount</span>
                                                            'End If
                                                        End If
                                                    </div>
                                                Else
                                                    @<div class="td dbl_@(i)_@(cssClavCuarto)" style="background: #EEEEEE; @styleHeight"></div>
                                                End If
                                                @If (From l In ListAgesByHotelRoom Where l.Clav_Cuarto = roomsPlan(i).Clav_Cuarto And (l.Cap_Adultos) >= 3).Count > 0 Then
                                                    @<div class="td trl_@(i)_@(cssClavCuarto)" style="@styleHeight">
                                                        @If Session("IsSuperUser") Then 'Si es MarketManager, muestra todo
                                                            @<span class="notif" @IIf(hide_DVPO = "" Or hide_OFPE = "", "", "style=display:none;")>@IIf(Promo.Tipo_Promo.Contains("OF_PO") And Not EsNeta, "V", "N") </span>
                                                            @Html.TextBoxFor(Function(m) m.roomRates(i).Triple_Neta_porc, New With {.Value = _Triple_Neta_porc, .Class = "rtsPorcent", disabled_Discount, .Style = hide_DVPO})
                                                            @Html.TextBoxFor(Function(m) m.roomRates(i).Triple_Neta, New With {.Value = _Triple_Neta, .Class = "rtsMount", disabled_Discount, .Style = hide_OFPE})
                                                            @<span class="tMoneda" @IIf(hide_DVPO = "" Or hide_OFPE = "", "", "style=display:none;")> @Unit_Discount</span>
                                                            @<div class="rVenta" style="float: left; padding-top: 4px; width: 100%; @hide_DVPE">
                                                                <span class="notif">V </span>
                                                                @Html.TextBoxFor(Function(m) m.roomRates(i).Triple_Venta, New With {.Value = _Triple_Venta, .Class = "rtsVent", disabled_Discount})
                                                                <span class="tMoneda"> @Unit_Discount</span>
                                                            </div>
                                                        Else
                                                            'If notif_Type <> "V" Then 'No ve la pública, ve la neta
                                                            @<span class="notif">@(IIf(EsNeta, "N", "V")) </span>
                                                            @Html.TextBoxFor(Function(m) m.roomRates(i).Triple_Neta_porc, New With {.Value = _Triple_Neta_porc, .Class = "rtsPorcent", disabled_Discount, .Style = hide_DVPO})
                                                            @Html.TextBoxFor(Function(m) m.roomRates(i).Triple_Neta, New With {.Value = IIf(EsNeta, _Triple_Neta, _Triple_Venta), .Class = "rtsMount", disabled_Discount, .Style = hide_OFPE & IIf(EsNeta, "", ";display:none;")})
                                                            @*<span class="tMoneda"> @Unit_Discount</span>*@
                                                            'Else 'Ve la pública, No ve la Neta
                                                            @*<span>V </span>*@
                                                            @*Html.TextBoxFor(Function(m) m.roomRates(i).Triple_Neta_porc, New With {.Value = _Triple_Neta_porc, .Class = "rtsPorcent", disabled_Discount, .Style = hide_DVPO})*@
                                                            @<div class="rVenta" style="float: left; @hide_DVPE @IIf(EsNeta, ";display:none;", "")">
                                                                @Html.TextBoxFor(Function(m) m.roomRates(i).Triple_Venta, New With {.Value = IIf(EsNeta, _Triple_Neta, _Triple_Venta), .Class = "rtsVent", disabled_Discount})
                                                            </div>
                                                            @<span class="tMoneda"> @Unit_Discount</span>
                                                            ' End If
                                                        End If
                                                    </div>
                                                Else
                                                    @<div class="td trl_@(i)_@(cssClavCuarto)" style="background: #EEEEEE; @styleHeight"></div>
                                                End If
                                                @If (From l In ListAgesByHotelRoom Where l.Clav_Cuarto = roomsPlan(i).Clav_Cuarto And (l.Cap_Adultos) >= 4).Count > 0 Then
                                                    @<div class="td cuad_@(i)_@(cssClavCuarto)" style="@styleHeight">
                                                        @If Session("IsSuperUser") Then 'Si es MarketManager, muestra todo
                                                            @<span class="notif" @IIf(hide_DVPO = "" Or hide_OFPE = "", "", "style=display:none;")>@IIf(Promo.Tipo_Promo.Contains("OF_PO") And Not EsNeta, "V", "N") </span>
                                                            @Html.TextBoxFor(Function(m) m.roomRates(i).Cuadruple_Neta_porc, New With {.Value = _Cuadruple_Neta_porc, .Class = "rtsPorcent", disabled_Discount, .Style = hide_DVPO})
                                                            @Html.TextBoxFor(Function(m) m.roomRates(i).Cuadruple_Neta, New With {.Value = _Cuadruple_Neta, .Class = "rtsMount", disabled_Discount, .Style = hide_OFPE})
                                                            @<span class="tMoneda" @IIf(hide_DVPO = "" Or hide_OFPE = "", "", "style=display:none;")> @Unit_Discount</span>
                                                            @<div class="rVenta" style="float: left; padding-top: 4px; width: 100%; @hide_DVPE">
                                                                <span class="notif">V </span>
                                                                @Html.TextBoxFor(Function(m) m.roomRates(i).Cuadruple_Venta, New With {.Value = _Cuadruple_Venta, .Class = "rtsVent", disabled_Discount})
                                                                <span class="tMoneda"> @Unit_Discount</span>
                                                            </div>
                                                        Else
                                                            'If notif_Type <> "V" Then 'No ve la pública, ve la neta
                                                            @<span class="notif">@(IIf(EsNeta, "N", "V")) </span>
                                                            @Html.TextBoxFor(Function(m) m.roomRates(i).Cuadruple_Neta_porc, New With {.Value = _Cuadruple_Neta_porc, .Class = "rtsPorcent", disabled_Discount, .Style = hide_DVPO})
                                                            @Html.TextBoxFor(Function(m) m.roomRates(i).Cuadruple_Neta, New With {.Value = IIf(EsNeta, _Cuadruple_Neta, _Cuadruple_Venta), .Class = "rtsMount", disabled_Discount, .Style = hide_OFPE & IIf(EsNeta, "", ";display:none;")})
                                                            @*<span class="tMoneda"> @Unit_Discount</span>*@
                                                            'Else 'Ve la pública, No ve la Neta
                                                            @*<span>V </span>*@
                                                            @*Html.TextBoxFor(Function(m) m.roomRates(i).Cuadruple_Neta_porc, New With {.Value = _Cuadruple_Neta_porc, .Class = "rtsPorcent", disabled_Discount, .Style = hide_DVPO})*@
                                                            @<div class="rVenta" style="float: left; @hide_DVPE  @IIf(EsNeta, ";display:none;", "")">
                                                                @Html.TextBoxFor(Function(m) m.roomRates(i).Cuadruple_Venta, New With {.Value = IIf(EsNeta, _Cuadruple_Neta, _Cuadruple_Venta), .Class = "rtsVent", disabled_Discount})
                                                            </div>
                                                            @<span class="tMoneda"> @Unit_Discount</span>
                                                            'End If
                                                        End If
                                                    </div>
                                                Else
                                                    @<div class="td cuad_@(i)_@(cssClavCuarto)" style="background: #EEEEEE; @styleHeight"></div>
                                                End If
                                                @If (From l In ListAgesByHotelRoom Where l.Clav_Cuarto = roomsPlan(i).Clav_Cuarto And l.Edad_Nino <> "0 - 0").Count > 0 Then

                                                    @<div class="td ch211_@(i)_@(cssClavCuarto)" style="@styleHeight">
                                                        @If Session("IsSuperUser") Then 'Si es MarketManager, muestra todo
                                                            @<span class="notif" @IIf(hide_DVPO = "" Or hide_OFPE = "", "", "style=display:none;")>@IIf(Promo.Tipo_Promo.Contains("OF_PO") And Not EsNeta, "V", "N") </span>
                                                            @Html.TextBoxFor(Function(m) m.roomRates(i).Ninos_Neta_porc, New With {.Value = _Ninos_Neta_porc, .Class = "rtsPorcent pChild", disabled_Discount, .Style = hide_DVPO})
                                                            @Html.TextBoxFor(Function(m) m.roomRates(i).Ninos_Neta, New With {.Value = _Ninos_Neta, .Class = "rtsMount", disabled_Discount, .Style = hide_OFPE})
                                                            @<span class="tMoneda" @IIf(hide_DVPO = "" Or hide_OFPE = "", "", "style=display:none;")> @Unit_Discount</span>
                                                            @<div class="rVenta" style="float: left; padding-top: 4px; width: 100%; @hide_DVPE">
                                                                <span class="notif">V </span>
                                                                @Html.TextBoxFor(Function(m) m.roomRates(i).Ninos_Venta, New With {.Value = _Ninos_Venta, .Class = "rtsVent", disabled_Discount})
                                                                <span class="tMoneda"> @Unit_Discount</span>
                                                            </div>
                                                        Else
                                                            'If notif_Type <> "V" Then 'No ve la pública, ve la neta
                                                            @<span class="notif">@(IIf(EsNeta, "N", "V")) </span>
                                                            @Html.TextBoxFor(Function(m) m.roomRates(i).Ninos_Neta_porc, New With {.Value = _Ninos_Neta_porc, .Class = "rtsPorcent pChild", disabled_Discount, .Style = hide_DVPO})
                                                            @Html.TextBoxFor(Function(m) m.roomRates(i).Ninos_Neta, New With {.Value = IIf(EsNeta, _Ninos_Neta, _Ninos_Venta), .Class = "rtsMount", disabled_Discount, .Style = hide_OFPE & IIf(EsNeta, "", ";display:none;")})
                                                            @*<span class="tMoneda"> @Unit_Discount</span>*@
                                                            'Else 'Ve la pública, No ve la Neta
                                                            @*<span>V </span>*@
                                                            @*Html.TextBoxFor(Function(m) m.roomRates(i).Ninos_Neta_porc, New With {.Value = _Ninos_Neta_porc, .Class = "rtsPorcent", disabled_Discount, .Style = hide_DVPO})*@
                                                            @<div class="rVenta" style="float: left; @hide_DVPE @IIf(EsNeta, ";display:none;", "")">
                                                                @Html.TextBoxFor(Function(m) m.roomRates(i).Ninos_Venta, New With {.Value = IIf(EsNeta, _Ninos_Neta, _Ninos_Venta), .Class = "rtsVent", disabled_Discount})
                                                            </div>
                                                            @<span class="tMoneda"> @Unit_Discount</span>
                                                            'End If
                                                        End If
                                                    </div>
                                                Else
                                                    @<div class="td ch211_@(i)_@(cssClavCuarto)" style="background: #EEEEEE; @styleHeight"></div>
                                                End If
                                                @If (From l In ListAgesByHotelRoom Where l.Clav_Cuarto = roomsPlan(i).Clav_Cuarto And l.Edad_Junior <> "0 - 0").Count > 0 Then

                                                    @<div class="td jr_@(i)_@(cssClavCuarto)" style="@styleHeight">
                                                        @If Session("IsSuperUser") Then 'Si es MarketManager, muestra todo
                                                            @<span class="notif" @IIf(hide_DVPO = "" Or hide_OFPE = "", "", "style=display:none;")>@IIf(Promo.Tipo_Promo.Contains("OF_PO") And Not EsNeta, "V", "N") </span>
                                                            @Html.TextBoxFor(Function(m) m.roomRates(i).Junior_Neta_porc, New With {.Value = _Junior_Neta_porc, .Class = "rtsPorcent pJunior", disabled_Discount, .Style = hide_DVPO})
                                                            @Html.TextBoxFor(Function(m) m.roomRates(i).Junior_Neta, New With {.Value = _Junior_Neta, .Class = "rtsMount", disabled_Discount, .Style = hide_OFPE})
                                                            @<span class="tMoneda" @IIf(hide_DVPO = "" Or hide_OFPE = "", "", "style=display:none;")> @Unit_Discount</span>
                                                            @<div class="rVenta" style="float: left; padding-top: 4px; width: 100%; @hide_DVPE">
                                                                <span class="notif">V </span>
                                                                @Html.TextBoxFor(Function(m) m.roomRates(i).Junior_Venta, New With {.Value = _Junior_Venta, .Class = "rtsVent", disabled_Discount})
                                                                <span class="tMoneda"> @Unit_Discount</span>
                                                            </div>
                                                        Else
                                                            'If notif_Type <> "V" Then 'No ve la pública, ve la neta
                                                            @<span class="notif">@(IIf(EsNeta, "N", "V")) </span>
                                                            @Html.TextBoxFor(Function(m) m.roomRates(i).Junior_Neta_porc, New With {.Value = _Junior_Neta_porc, .Class = "rtsPorcent pJunior", disabled_Discount, .Style = hide_DVPO})
                                                            @Html.TextBoxFor(Function(m) m.roomRates(i).Junior_Neta, New With {.Value = IIf(EsNeta, _Junior_Neta, _Junior_Venta), .Class = "rtsMount", disabled_Discount, .Style = hide_OFPE & IIf(EsNeta, "", ";display:none;")})
                                                            @*<span class="tMoneda"> @Unit_Discount</span>*@
                                                            'Else 'Ve la pública, No ve la Neta
                                                            @*<span>V </span>*@
                                                            @*Html.TextBoxFor(Function(m) m.roomRates(i).Junior_Neta_porc, New With {.Value = _Junior_Neta_porc, .Class = "rtsPorcent", disabled_Discount, .Style = hide_DVPO})*@
                                                            @<div class="rVenta" style="float: left;  @hide_DVPE @IIf(EsNeta, ";display:none;", "")">
                                                                @Html.TextBoxFor(Function(m) m.roomRates(i).Junior_Venta, New With {.Value = IIf(EsNeta, _Junior_Neta, _Junior_Venta), .Class = "rtsVent", disabled_Discount})
                                                            </div>
                                                            @<span class="tMoneda"> @Unit_Discount</span>
                                                            'End If
                                                        End If
                                                    </div>
                                                Else
                                                    @<div class="td ch211_@(i)_@(cssClavCuarto)" style="background: #EEEEEE; @styleHeight"></div>
                                                End If
                                            </div>
                                        </div>
                                        hasPromo = True
                                        Exit For
                                    End If
                                Next
                                'MUESTRA LAS HABITACIONES DEL CONTRATO
                                If Not hasPromo And (roomsPlan(i).Clav_Plan <> "EP" And roomsPlan(i).Clav_Plan <> "BI") Then
                                    @<div class="rowRates @String.Format("{0}_{1}", cssClavCuarto, roomsPlan(i).Clav_Plan)" style="display:none">
                                        <div class="roomName">@roomsPlan(i).Nombre_Cuarto -  @roomsPlan(i).Nombre_Plan</div>
                                        <div class="tableRow">
                                            <div class="checkRow" style="width: 60px; @styleHeight">
                                                <input id="chk_@(i)_@(cssClavCuarto)" type="checkbox" @disabled_Discount />
                                            </div>
                                            @If (From l In ListAgesByHotelRoom Where l.Clav_Cuarto = roomsPlan(i).Clav_Cuarto And (l.Cap_Adultos) >= 1).Count > 0 Then
                                                @<div class="td sgl_@(i)_@(cssClavCuarto)" style="@styleHeight">
                                                    @If Session("IsSuperUser") Then 'Si es MarketManager, muestra todo
                                                        @<span class="notif" @IIf(hide_DVPO = "" Or hide_OFPE = "", "", "style=display:none;")>@IIf(Promo.Tipo_Promo.Contains("OF_PO") And Not EsNeta, "V", "N") </span>
                                                        @Html.TextBoxFor(Function(m) m.roomRates(i).Sencillo_Neta_porc, New With {.Value = "0", .Class = "rtsPorcent", disabled_Discount, .Style = hide_DVPO})
                                                        @Html.TextBoxFor(Function(m) m.roomRates(i).Sencillo_Neta, New With {.Value = "0", .Class = "rtsMount", disabled_Discount, .Style = hide_OFPE})
                                                        @<span class="tMoneda" @IIf(hide_DVPO = "" Or hide_OFPE = "", "", "style=display:none;")> @Unit_Discount</span>
                                                        @<div class="rVenta" style="float: left; padding-top: 4px; width: 100%; @hide_DVPE">
                                                            <span class="notif">V </span>
                                                            @Html.TextBoxFor(Function(m) m.roomRates(i).Sencillo_Venta, New With {.Value = "0", disabled_Discount, .Class = "rtsVent"})
                                                            <span class="tMoneda"> @Unit_Discount</span>
                                                        </div>
                                                    Else
                                                        'If notif_Type <> "V" Then 'No ve la pública, ve la neta
                                                        @<span class="notif">@(IIf(EsNeta, "N", "V")) </span>
                                                        @Html.TextBoxFor(Function(m) m.roomRates(i).Sencillo_Neta_porc, New With {.Value = "0", .Class = "rtsPorcent", disabled_Discount, .Style = hide_DVPO})
                                                        @Html.TextBoxFor(Function(m) m.roomRates(i).Sencillo_Neta, New With {.Value = "0", .Class = "rtsMount", disabled_Discount, .Style = hide_OFPE & IIf(EsNeta, "", ";display:none;")})
                                                        @*<span class="tMoneda"> @Unit_Discount</span>*@
                                                        'Else 'Ve la pública, No ve la Neta
                                                        @*<span>V </span>*@
                                                        @*Html.TextBoxFor(Function(m) m.roomRates(i).Sencillo_Neta_porc, New With {.Value = "0", .Class = "rtsPorcent", disabled_Discount, .Style = hide_DVPO})*@
                                                        @<div class="rVenta" style="float: left; @hide_DVPE @IIf(EsNeta, ";display:none;", "")">
                                                            @Html.TextBoxFor(Function(m) m.roomRates(i).Sencillo_Venta, New With {.Value = "0", disabled_Discount, .Class = "rtsVent"})
                                                        </div>
                                                        @<span class="tMoneda"> @Unit_Discount</span>
                                                        'End If
                                                    End If
                                                </div>
                                            Else
                                                @<div class="td sgl_@(i)_@(cssClavCuarto)" style="background: #EEEEEE; @styleHeight"></div>
                                            End If
                                            @If (From l In ListAgesByHotelRoom Where l.Clav_Cuarto = roomsPlan(i).Clav_Cuarto And (l.Cap_Adultos) >= 2).Count > 0 Then
                                                @<div class="td dbl_@(i)_@(cssClavCuarto)" style="@styleHeight">
                                                    @If Session("IsSuperUser") Then 'Si es MarketManager, muestra todo
                                                        @<span class="notif" @IIf(hide_DVPO = "" Or hide_OFPE = "", "", "style=display:none;")>@IIf(Promo.Tipo_Promo.Contains("OF_PO") And Not EsNeta, "V", "N") </span>
                                                        @Html.TextBoxFor(Function(m) m.roomRates(i).Double_Neta_porc, New With {.Value = "0", .Class = "rtsPorcent", disabled_Discount, .Style = hide_DVPO})
                                                        @Html.TextBoxFor(Function(m) m.roomRates(i).Doble_Neta, New With {.Value = "0", .Class = "rtsMount", disabled_Discount, .Style = hide_OFPE})
                                                        @<span class="tMoneda" @IIf(hide_DVPO = "" Or hide_OFPE = "", "", "style=display:none;")> @Unit_Discount</span>
                                                        @<div class="rVenta" style="float: left; padding-top: 4px; width: 100%; @hide_DVPE">
                                                            <span class="notif">V </span>
                                                            @Html.TextBoxFor(Function(m) m.roomRates(i).Double_Venta, New With {.Value = "0", disabled_Discount, .Class = "rtsVent"})
                                                            <span class="tMoneda"> @Unit_Discount</span>
                                                        </div>
                                                    Else
                                                        'If notif_Type <> "V" Then 'No ve la pública, ve la neta
                                                        @<span class="notif">@(IIf(EsNeta, "N", "V")) </span>
                                                        @Html.TextBoxFor(Function(m) m.roomRates(i).Double_Neta_porc, New With {.Value = "0", .Class = "rtsPorcent", disabled_Discount, .Style = hide_DVPO})
                                                        @Html.TextBoxFor(Function(m) m.roomRates(i).Doble_Neta, New With {.Value = "0", .Class = "rtsMount", disabled_Discount, .Style = hide_OFPE & IIf(EsNeta, "", ";display:none;")})
                                                        @*<span class="tMoneda"> @Unit_Discount</span>*@
                                                        'Else 'Ve la pública, No ve la Neta
                                                        @*<span>V </span>*@
                                                        @*Html.TextBoxFor(Function(m) m.roomRates(i).Double_Neta_porc, New With {.Value = "0",.Class = "rtsPorcent", disabled_Discount, .Style = hide_DVPO})*@
                                                        @<div class="rVenta" style="float: left;@hide_DVPE @IIf(EsNeta, ";display:none;", "")">
                                                            @Html.TextBoxFor(Function(m) m.roomRates(i).Double_Venta, New With {.Value = "0", disabled_Discount, .Class = "rtsVent"})
                                                        </div>
                                                        @<span class="tMoneda"> @Unit_Discount</span>
                                                        'End If
                                                    End If
                                                </div>
                                            Else
                                                @<div class="td dbl_@(i)_@(cssClavCuarto)" style="background: #EEEEEE; @styleHeight"></div>
                                            End If

                                            @If (From l In ListAgesByHotelRoom Where l.Clav_Cuarto = roomsPlan(i).Clav_Cuarto And (l.Cap_Adultos) >= 3).Count > 0 Then
                                                @<div class="td trl_@(i)_@(cssClavCuarto)" style="@styleHeight">
                                                    @If Session("IsSuperUser") Then 'Si es MarketManager, muestra todo
                                                        @<span class="notif" @IIf(hide_DVPO = "" Or hide_OFPE = "", "", "style=display:none;")>@IIf(Promo.Tipo_Promo.Contains("OF_PO") And Not EsNeta, "V", "N") </span>
                                                        @Html.TextBoxFor(Function(m) m.roomRates(i).Triple_Neta_porc, New With {.Value = "0", .Class = "rtsPorcent", disabled_Discount, .Style = hide_DVPO})
                                                        @Html.TextBoxFor(Function(m) m.roomRates(i).Triple_Neta, New With {.Value = "0", .Class = "rtsMount", disabled_Discount, .Style = hide_OFPE})
                                                        @<span class="tMoneda" @IIf(hide_DVPO = "" Or hide_OFPE = "", "", "style=display:none;")> @Unit_Discount</span>
                                                        @<div class="rVenta" style="float: left; padding-top: 4px; width: 100%; @hide_DVPE">
                                                            <span class="notif">V </span>
                                                            @Html.TextBoxFor(Function(m) m.roomRates(i).Triple_Venta, New With {.Value = "0", disabled_Discount, .Class = "rtsVent"})
                                                            <span class="tMoneda"> @Unit_Discount</span>
                                                        </div>
                                                    Else
                                                        'If notif_Type <> "V" Then 'No ve la pública, ve la neta
                                                        @<span class="notif">@(IIf(EsNeta, "N", "V")) </span>
                                                        @Html.TextBoxFor(Function(m) m.roomRates(i).Triple_Neta_porc, New With {.Value = "0", .Class = "rtsPorcent", disabled_Discount, .Style = hide_DVPO})
                                                        @Html.TextBoxFor(Function(m) m.roomRates(i).Triple_Neta, New With {.Value = "0", .Class = "rtsMount", disabled_Discount, .Style = hide_OFPE & IIf(EsNeta, "", ";display:none;")})
                                                        @*<span class="tMoneda"> @Unit_Discount</span>*@
                                                        'Else 'Ve la pública, No ve la Neta
                                                        @*<span>V </span>*@
                                                        @*Html.TextBoxFor(Function(m) m.roomRates(i).Triple_Neta_porc, New With {.Value = "0",.Class = "rtsPorcent", disabled_Discount, .Style = hide_DVPO})*@
                                                        @<div class="rVenta" style="float: left; @hide_DVPE @IIf(EsNeta, ";display:none;", "")">
                                                            @Html.TextBoxFor(Function(m) m.roomRates(i).Triple_Venta, New With {.Value = "0", disabled_Discount, .Class = "rtsVent"})
                                                        </div>
                                                        @<span class="tMoneda"> @Unit_Discount</span>
                                                        'End If
                                                    End If
                                                </div>
                                            Else
                                                @<div class="td trl_@(i)_@(cssClavCuarto)" style="background: #EEEEEE; @styleHeight"></div>
                                            End If
                                            @If (From l In ListAgesByHotelRoom Where l.Clav_Cuarto = roomsPlan(i).Clav_Cuarto And (l.Cap_Adultos) >= 4).Count > 0 Then
                                                @<div class="td cuad_@(i)_@(cssClavCuarto)" style="@styleHeight">
                                                    @If Session("IsSuperUser") Then 'Si es MarketManager, muestra todo
                                                        @<span class="notif" @IIf(hide_DVPO = "" Or hide_OFPE = "", "", "style=display:none;")>@IIf(Promo.Tipo_Promo.Contains("OF_PO") And Not EsNeta, "V", "N") </span>
                                                        @Html.TextBoxFor(Function(m) m.roomRates(i).Cuadruple_Neta_porc, New With {.Value = "0", .Class = "rtsPorcent", disabled_Discount, .Style = hide_DVPO})
                                                        @Html.TextBoxFor(Function(m) m.roomRates(i).Cuadruple_Neta, New With {.Value = "0", .Class = "rtsMount", disabled_Discount, .Style = hide_OFPE})
                                                        @<span class="tMoneda" @IIf(hide_DVPO = "" Or hide_OFPE = "", "", "style=display:none;")> @Unit_Discount</span>
                                                        @<div class="rVenta" style="float: left; padding-top: 4px; width: 100%; @hide_DVPE">
                                                            <span class="notif">V </span>
                                                            @Html.TextBoxFor(Function(m) m.roomRates(i).Cuadruple_Venta, New With {.Value = "0", disabled_Discount, .Class = "rtsVent"})
                                                            <span class="tMoneda"> @Unit_Discount</span>
                                                        </div>
                                                    Else
                                                        'If notif_Type <> "V" Then 'No ve la pública, ve la neta
                                                        @<span class="notif">@(IIf(EsNeta, "N", "V")) </span>
                                                        @Html.TextBoxFor(Function(m) m.roomRates(i).Cuadruple_Neta_porc, New With {.Value = "0", .Class = "rtsPorcent", disabled_Discount, .Style = hide_DVPO})
                                                        @Html.TextBoxFor(Function(m) m.roomRates(i).Cuadruple_Neta, New With {.Value = "0", .Class = "rtsMount", disabled_Discount, .Style = hide_OFPE & IIf(EsNeta, "", ";display:none;")})
                                                        @*<span class="tMoneda"> @Unit_Discount</span>*@
                                                        'Else 'Ve la pública, No ve la Neta
                                                        @*<span>V </span>*@
                                                        @*Html.TextBoxFor(Function(m) m.roomRates(i).Cuadruple_Neta_porc, New With {.Value = "0",.Class = "rtsPorcent", disabled_Discount, .Style = hide_DVPO}) *@
                                                        @<div class="rVenta" style="float: left; @hide_DVPE @IIf(EsNeta, ";display:none;", "")">
                                                            @Html.TextBoxFor(Function(m) m.roomRates(i).Cuadruple_Venta, New With {.Value = "0", disabled_Discount, .Class = "rtsVent"})
                                                        </div>
                                                        @<span class="tMoneda"> @Unit_Discount</span>
                                                        'End If
                                                    End If
                                                </div>
                                            Else
                                                @<div class="td cuad_@(i)_@(cssClavCuarto)" style="background: #EEEEEE; @styleHeight"></div>
                                            End If
                                            @If (From l In ListAgesByHotelRoom Where l.Clav_Cuarto = roomsPlan(i).Clav_Cuarto And l.Edad_Nino <> "0 - 0").Count > 0 Then
                                                @<div class="td ch211_@(i)_@(cssClavCuarto)" style="@styleHeight">
                                                    @If Session("IsSuperUser") Then 'Si es MarketManager, muestra todo
                                                        @<span class="notif" @IIf(hide_DVPO = "" Or hide_OFPE = "", "", "style=display:none;")>@IIf(Promo.Tipo_Promo.Contains("OF_PO") And Not EsNeta, "V", "N") </span>
                                                        @Html.TextBoxFor(Function(m) m.roomRates(i).Ninos_Neta_porc, New With {.Value = "0", .Class = "rtsPorcent pChild", disabled_Discount, .Style = hide_DVPO})
                                                        @Html.TextBoxFor(Function(m) m.roomRates(i).Ninos_Neta, New With {.Value = "0", .Class = "rtsMount", disabled_Discount, .Style = hide_OFPE})
                                                        @<span class="tMoneda" @IIf(hide_DVPO = "" Or hide_OFPE = "", "", "style=display:none;")> @Unit_Discount</span>
                                                        @<div class="rVenta" style="float: left; padding-top: 4px; width: 100%; @hide_DVPE">
                                                            <span class="notif">V </span>
                                                            @Html.TextBoxFor(Function(m) m.roomRates(i).Ninos_Venta, New With {.Value = "0", disabled_Discount, .Class = "rtsVent"})
                                                            <span class="tMoneda"> @Unit_Discount</span>
                                                        </div>
                                                    Else
                                                        'If notif_Type <> "V" Then 'No ve la pública, ve la neta
                                                        @<span class="notif">@(IIf(EsNeta, "N", "V")) </span>
                                                        @Html.TextBoxFor(Function(m) m.roomRates(i).Ninos_Neta_porc, New With {.Value = "0", .Class = "rtsPorcent pChild", disabled_Discount, .Style = hide_DVPO})
                                                        @Html.TextBoxFor(Function(m) m.roomRates(i).Ninos_Neta, New With {.Value = "0", .Class = "rtsMount", disabled_Discount, .Style = hide_OFPE & IIf(EsNeta, "", ";display:none;")})
                                                        @*<span class="tMoneda"> @Unit_Discount</span>*@
                                                        'Else 'Ve la pública, No ve la Neta
                                                        @*<span>V </span>*@
                                                        @*Html.TextBoxFor(Function(m) m.roomRates(i).Ninos_Neta_porc, New With {.Value = "0",.Class = "rtsPorcent", disabled_Discount, .Style = hide_DVPO})*@
                                                        @<div class="rVenta" style="float: left; @hide_DVPE @IIf(EsNeta, ";display:none;", "")">
                                                            @Html.TextBoxFor(Function(m) m.roomRates(i).Ninos_Venta, New With {.Value = "0", disabled_Discount, .Class = "rtsVent"})
                                                        </div>
                                                        @<span class="tMoneda"> @Unit_Discount</span>
                                                        'End If
                                                    End If
                                                </div>
                                            Else
                                                @<div class="td ch211_@(i)_@(cssClavCuarto)" style="background: #EEEEEE; @styleHeight"></div>
                                            End If
                                            @*@If (From l In ListAgesByHotelRoom Where l.Edad_Junior <> "0 - 0").Count > 0 Then*@
                                            @If (From l In ListAgesByHotelRoom Where l.Clav_Cuarto = roomsPlan(i).Clav_Cuarto And l.Edad_Junior <> "0 - 0").Count > 0 Then
                                                @<div class="td jr_@(i)_@(cssClavCuarto)" style="@styleHeight">
                                                    @If Session("IsSuperUser") Then 'Si es MarketManager, muestra todo
                                                        @<span class="notif" @IIf(hide_DVPO = "" Or hide_OFPE = "", "", "style=display:none;")>@IIf(Promo.Tipo_Promo.Contains("OF_PO") And Not EsNeta, "V", "N") </span>
                                                        @Html.TextBoxFor(Function(m) m.roomRates(i).Junior_Neta_porc, New With {.Value = "0", .Class = "rtsPorcent pJunior", disabled_Discount, .Style = hide_DVPO})
                                                        @Html.TextBoxFor(Function(m) m.roomRates(i).Junior_Neta, New With {.Value = "0", .Class = "rtsMount", disabled_Discount, .Style = hide_OFPE})
                                                        @<span class="tMoneda" @IIf(hide_DVPO = "" Or hide_OFPE = "", "", "style=display:none;")> @Unit_Discount</span>
                                                        @<div class="rVenta" style="float: left; padding-top: 4px; width: 100%; @hide_DVPE">
                                                            <span class="notif">V </span>
                                                            @Html.TextBoxFor(Function(m) m.roomRates(i).Junior_Venta, New With {.Value = "0", disabled_Discount, .Class = "rtsVent"})
                                                            <span class="tMoneda"> @Unit_Discount</span>
                                                        </div>
                                                    Else
                                                        'If notif_Type <> "V" Then 'No ve la pública, ve la neta
                                                        @<span class="notif">@(IIf(EsNeta, "N", "V")) </span>
                                                        @Html.TextBoxFor(Function(m) m.roomRates(i).Junior_Neta_porc, New With {.Value = "0", .Class = "rtsPorcent pJunior", disabled_Discount, .Style = hide_DVPO})
                                                        @Html.TextBoxFor(Function(m) m.roomRates(i).Junior_Neta, New With {.Value = "0", .Class = "rtsMount", disabled_Discount, .Style = hide_OFPE & IIf(EsNeta, "", ";display:none;")})
                                                        @*<span class="tMoneda"> @Unit_Discount</span>*@
                                                        'Else 'Ve la pública, No ve la Neta
                                                        @*<span>V </span>*@
                                                        @<div class="rVenta" style="float: left; @hide_DVPE @IIf(EsNeta, ";display:none;", "")">
                                                            @Html.TextBoxFor(Function(m) m.roomRates(i).Junior_Venta, New With {.Value = "0", disabled_Discount, .Class = "rtsVent"})
                                                        </div>
                                                        @<span class="tMoneda"> @Unit_Discount</span>
                                                        'End If
                                                    End If
                                                </div>
                                            Else
                                                @<div class="td jr_@(i)_@(cssClavCuarto)" style="background: #EEEEEE; @styleHeight"></div>
                                            End If
                                            @*end if*@
                                        </div>
                                    </div>
                                End If
                            Next

                            @TextoCargaTarifas(Session("TipoCarga"), "AI")
                        </div>
                    End If
                End code
            </div>
            @code

                Dim disabled_NochesDescuento = IIf(Promo.NocheDescuento > 0, "", "disabled=disabled")
                Dim disabled_NochesDescuento2 = IIf(Promo.NocheDescuento2 > 0 And Promo.NocheDescuento > 0, "", "disabled=disabled")
            End Code


            @*<div id="DiscountDays" class="DiscountDays">
                        @Html.CheckBox("open_DaysDiscount", (String.IsNullOrEmpty(disabled_NochesDescuento)), New With {.Class = "toggleSection"})
                        @Html.HiddenFor(Function(m) m.Dias_Descuento)
                        <label for ="open_DaysDiscount" @IIf(disabled_NochesDescuento = "", "class=on", "")>@Resources.Dictionary.SpecifyDaysDiscount.</label><div class="help_tip" id="help_specificArrivals" ></div>

                    <div class="DiscountNights" id="DaysDiscount"  @IIf(disabled_NochesDescuento <> "", "style=display:none;", "")>
                        @Html.DropDownListFor(Function(m) m.AcumulableDescuento, New SelectList(itemsAcumulable, "Value", "Text",IIf(Promo.AcumulableDescuento,1,0)), New With {disabled_NochesDescuento})
                        @Html.TextBoxFor(Function(m) m.NochesDescuento, New With {.Value = Promo.NocheDescuento, disabled_NochesDescuento})<span class="numberSymbol"> ° </span> <span>@Resources.Dictionary.disInfoNights</span>

                        @Html.CheckBox("andNightsDescuento", (String.IsNullOrEmpty(disabled_NochesDescuento2)), New With {.Class = "toggleAND", disabled_NochesDescuento2})<label for="andNights" class="andNights">@Resources.Dictionary.disAnd</label>

                        @Html.DropDownListFor(Function(m) m.AcumulableDescuento2, New SelectList(itemsAcumulable2, "Value", "Text", IIf(Promo.AcumulableDescuento2, 1, 0)), New With {disabled_NochesDescuento2})
                        @Html.TextBoxFor(Function(m) m.NochesDescuento2, New With {.Value = Promo.NocheDescuento2, disabled_NochesDescuento2})<span class="numberSymbol"> ° </span><span>@Resources.Dictionary.disInfoNights</span>
                    </div>
                </div>*@
        </div>
        @*FREEKIDS*@
        @Code
            Dim disabled_FreeKids = IIf(Not Promo.Tipo_Promo.Contains("FK"), "disabled=disabled", "")

            Dim adultPayment = freeKidsText.Split("|")
            Dim Kid1 As Boolean = False
            Dim Kid2 As Boolean = False
            Dim Kid3 As Boolean = False
            Dim Adults As String = ""
            Dim AllFree As String = ""
            'For Each items In adultPayment
            '    If items <> "" Then
            Dim adultKids = adultPayment(0).Split("_")
            If adultKids.Length = 3 Then
                Adults = "_" & adultKids(1)
                Kid1 = adultKids(2).Substring(0, 1)
                Kid2 = adultKids(2).Substring(1, 1)
                Kid3 = adultKids(2).Substring(2, 1)
            Else
                AllFree = "checked=checked"
            End If
            '    End If
            'Next
            'EL check de NIños Gratis
            IsChildFree = IIf(freeKidsText.Contains("FKN"), True, IIf(freeKidsText.Contains("FKJ"), False, IIf(freeKidsText.Contains("FK"), True, False)))
            IsJrFree = IIf(freeKidsText.Contains("FKJ"), True, IIf(freeKidsText.Contains("FKN"), False, IIf(freeKidsText.Contains("FK"), True, False)))

        End Code
        @If Not String.IsNullOrEmpty(sAgesChild) Or Not String.IsNullOrEmpty(sAgesJunior) Then
            @<div class="sectionBox tabContent freeKids off" id="freeKids">
                <span class="sectionSubTitle">@Resources.Dictionary.disChildAgeRanges</span>
                <div class="ageOptions"><input id="chld0" class="ageChild" type="checkbox" @disabled_FreeKids @IIf(IsChildFree, "checked=checked", "") /><label for="chld0"> @Resources.Dictionary.DisNinos (@sAgesChild)</label></div>
                <div class="ageOptions"><input id="chld1" class="ageChild" type="checkbox" @disabled_FreeKids @IIf(IsJrFree, "checked=checked", "") /><label for="chld1"> Jr. (@sAgesJunior)</label></div>
                <div class="ageOptions" style="display:none"><input id="chld2" class="ageChild" type="checkbox" @disabled_FreeKids /><label for="chld2"> @*Jr. (12- 18)*@</label></div>
                <div class="hr"></div>
                <span class="sectionSubTitle applyFor">@Resources.Dictionary.disApplyfor</span>
                <div class="ageOptions">
                    <input class="payedAdults" name="applyFor" id="allKidsFree" @AllFree type="radio" @disabled_FreeKids /> <label for="allKidsFree">@Resources.Dictionary.disAllKidsFree<label></label></label>
                    @If (Adults = "") Then
                        @<div class="childOptions" style="display:none;">
                            <div class="hr"></div>
                            <div><input id="First_Child" type="checkbox" @disabled_FreeKids @(IIf(Kid1, "checked=checked", "")) /><label for="First_Child">@Resources.Dictionary.disFirstChild</label></div>
                            <div><input id="Second_Child" type="checkbox" @disabled_FreeKids @(IIf(Kid2, "checked=checked", "")) /><label for="Second_Child">@Resources.Dictionary.disSecondChild</label></div>
                            <div><input id="Third_Child" type="checkbox" @disabled_FreeKids @(IIf(Kid3, "checked=checked", "")) /><label for="Third_Child">@Resources.Dictionary.disThirdChild</label></div>
                        </div>
                    End If
                </div>
                <div class="ageOptions @(IIf(Adults.Contains("_1"), "selected", ""))">
                    <input class="payedAdults" name="applyFor" id="onePayedAdults" @(IIf(Adults.Contains("_1"), "checked=checked", "")) type="radio" @disabled_FreeKids /><label for="onePayedAdults">@Resources.Dictionary.disOnePayedAdult</label><div class="help_tip" id="help_onePayedAdults"></div>
                    @If (Adults.Contains("_1")) Then
                        @<div class="childOptions">
                            <div class="hr"></div>
                            <div><input id="First_Child" type="checkbox" @disabled_FreeKids @(IIf(Kid1, "checked=checked", "")) /><label for="First_Child">@Resources.Dictionary.disFirstChild</label></div>
                            <div><input id="Second_Child" type="checkbox" @disabled_FreeKids @(IIf(Kid2, "checked=checked", "")) /><label for="Second_Child">@Resources.Dictionary.disSecondChild</label></div>
                            <div><input id="Third_Child" type="checkbox" @disabled_FreeKids @(IIf(Kid3, "checked=checked", "")) /><label for="Third_Child">@Resources.Dictionary.disThirdChild</label></div>
                        </div>
                    End If
                </div>
                <div class="ageOptions @(IIf(Adults.Contains("_2"), "selected", ""))">
                    <input class="payedAdults" name="applyFor" id="twoPayedAdults" @(IIf(Adults.Contains("_2"), "checked=checked", "")) type="radio" @disabled_FreeKids /> <label for="twoPayedAdults">@Resources.Dictionary.disTwoPayedAdults</label><div class="help_tip" id="help_twoPayedAdults"></div>
                    @If Adults.Contains("_2") Then
                        @<div class="childOptions" @(IIf(Not Adults.Contains("_2"), "style=display:none", ""))>
                            <div class="hr"></div>
                            <div><input id="First_Child" type="checkbox" @disabled_FreeKids @(IIf(Kid1, "checked=checked", "")) /><label for="First_Child">@Resources.Dictionary.disFirstChild</label></div>
                            <div><input id="Second_Child" type="checkbox" @disabled_FreeKids @(IIf(Kid2, "checked=checked", "")) /><label for="Second_Child">@Resources.Dictionary.disSecondChild</label></div>
                            <div><input id="Third_Child" type="checkbox" @disabled_FreeKids @(IIf(Kid3, "checked=checked", "")) /><label for="Third_Child">@Resources.Dictionary.disThirdChild</label></div>
                        </div>
                    End If
                </div>
                @Html.HiddenFor(Function(m) m.pfreeKids, New With {.Value = freeKidsText})
            </div>
        End If
    </div>
</div>
@*Conditions*@
@Code
    Dim itemPolicies As List(Of SelectListItem) = New List(Of SelectListItem)

End Code
<div class="sectionWindow conditions">
    <span class="sectionTitle">@Resources.Dictionary.disConditions</span>
    <div class="promoNights">
        <div><span>@Resources.Dictionary.disMinNights: </span>@Html.TextBoxFor(Function(m) m.Dias_Minimos_Estancia, New With {.Value = Promo.Dias_Minimos_Estancia, .Id = "Min_Nights"})</div>
        <div><span>@Resources.Dictionary.disMaxNights: </span>@Html.TextBoxFor(Function(m) m.Dias_Maximos_Estancia, New With {.Value = Promo.Dias_Maximos_Estancia, .Id = "Max_Nights"})</div>
        @Html.HiddenFor(Function(m) m.Dias_Minimos_Estancia_Arrival, New With {.Value = (Promo.Dias_Minimos_Estancia_Arrival)})
        @Html.HiddenFor(Function(m) m.Dias_Maximos_Estancia_Arrival, New With {.Value = (Promo.Dias_Maximos_Estancia_Arrival)})
    </div>
    <div class="combinePromo">
        @If Session("IsSuperUser") Then
            Dim combineChk = IIf(Promo.Combinable = 1, ".Checked=True", "")
            @Html.CheckBox("combinePromo", (Promo.Combinable = 1), New With {.Value = Promo.Combinable})
            @Html.HiddenFor(Function(m) m.Combinable, New With {.Value = (Promo.Combinable = 1)})
            @<label for="combinePromo">@Resources.Dictionary.disCombinePromo </label>@<div class="help_tip" id="help_combinePromo"></div>
        Else
            @Html.HiddenFor(Function(m) m.Combinable, New With {.Value = (Promo.Combinable = 1)})
        End If

    </div>
    @*@if Session("CompanyHotel") <> "BEDA" Or ContratoPagoDestino Then @*@
    <div class="cancelPolicy" style="width:445px;">
        @Resources.Dictionary.disCancellationPolicy
    @Html.DropDownListFor(Function(m) m.Clav_Politica, New SelectList(CType(Session("ListCancelPolicies"), IEnumerable(Of Extranet.Website.Extranet.Data.spe_politica_cancelacionResult)), "Clav_Politica", "Nombre_Politica", Promo.Clav_Politica))
</div>
@*End if*@
<!--TODO: Combina BlackOut -->
@*If Promo.CombinaBloqueo = 1 Then
        @<div Class="combinePromo cancelPolicy">
            <img class='removeRange' src='@Url.Content("~/Content/themes/base/images/promo_active.png")'>
            <Label for="Combina_Bloqueo">@Resources.Dictionary.disCombina_Bloqueo </label><div style="display:none;" class="help_tip" id="help_combineBlackOut"></div>
        </div>
    End If
        -->
    @*<div class="affiliates">
        @Html.CheckBox("open_affiliateDetail", New With {.class = "toggleSection"})@*<input class="toggleSection" id="open_affiliateDetail" type="checkbox">*@
@*<span class="on"> <label for="open_affiliateDetail">@Resources.Dictionary.disAppliesSpecificAffiliate. </label></span><img src="@Url.Content("~/Content/themes/base/images/ic_help.png")" />
        <div class="affiliateDetail sectionBox off" id="affiliateDetail">
            <input value="Enter affiliate name here..." type="text">
            <span class="addSubmit">+ @Resources.Dictionary.disAddAffiliate</span>
            <div class="affiliateShow">
                <span class="sectionSubTitle">Selected Affiliates </span><a href="#" class="deleteAll">@Resources.Dictionary.DisRemoveAll </a>
                <div class="hr"></div>
                <div class="rangeSelected">
                    <ul>
                        <li>Name of the affiliate<img src="@Url.Content("~/Content/themes/base/images/promo_inactive.png")"></li>
                        <li><div class="hr"></div></li>
                        <li>Name of the affiliate<img src="@Url.Content("~/Content/themes/base/images/promo_inactive.png")"></li>
                        <li><div class="hr"></div></li>
                        <li>Name of the affiliate<img src="@Url.Content("~/Content/themes/base/images/promo_inactive.png")"></li>
                        <li><div class="hr"></div></li>
                        <li>Name of the affiliate<img src="@Url.Content("~/Content/themes/base/images/promo_inactive.png")"></li>
                    </ul>
                </div>
            </div>
        </div>
    </div>*@
</div>

@If (Not Is24Hrs Or (ShowPromo24Hrs = 1 Or Session("CompanyHotel") <> "BEDA")) Or Session("IsSuperUser") Then
    @<div class="applyPreview">
        @Html.Hidden("ac")
        <input class="procedButton" id="btnPreviewChangesY" type="submit" value="@Resources.Dictionary.disPreview" />
        <input class="procedButton" id="btnSaveChangesY" type="submit" value="@Resources.Dictionary.DisSaveChanges" />
    </div>
End If
<div id="ResultDivFancy" style="float: left;">@Html.Partial("_TextPromotionsPreview")</div>

</div>

</form>

