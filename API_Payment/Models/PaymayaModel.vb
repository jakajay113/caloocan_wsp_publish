
Namespace GetCheckoutAPI
    Public Class Details
        Public Property discount As String
        Public Property serviceCharge As String
        Public Property shippingFee As String
        Public Property tax As String
        Public Property subtotal As String
    End Class

    Public Class Amount
        Public Property value As Integer
        Public Property details As Details
    End Class

    Public Class TotalAmount
        Public Property value As Integer
        Public Property details As Details
    End Class

    Public Class Item
        Public Property name As String
        Public Property quantity As String
        Public Property code As String
        Public Property description As String
        Public Property amount As Amount
        Public Property totalAmount As TotalAmount
    End Class

    Public Class Metadata
    End Class

    Public Class Receipt
        Public Property transactionId As String
        Public Property receiptNo As String
        Public Property approval_code As String
        Public Property approvalCode As String
    End Class

    Public Class Card
        Public Property cardNumber As String
        Public Property expiryMonth As String
        Public Property expiryYear As String
    End Class

    Public Class FundingInstrument
        Public Property card As Card
    End Class

    Public Class Payer
        Public Property fundingInstrument As FundingInstrument
    End Class

    Public Class Efs
        Public Property paymentTransactionReferenceNo As String
        Public Property status As String
        Public Property receipt As Receipt
        Public Property payer As Payer
        Public Property amount As Amount
        Public Property created_at As DateTime
    End Class

    Public Class Responses
        Public Property efs As Efs
    End Class

    Public Class PaymentDetails
        Public Property responses As Responses
        Public Property paymentAt As DateTime
        Public Property _3ds As Boolean
    End Class

    Public Class Contact
        Public Property phone As String
        Public Property email As String
    End Class

    Public Class BillingAddress
        Public Property line1 As String
        Public Property line2 As String
        Public Property city As String
        Public Property state As String
        Public Property zipCode As String
        Public Property countryCode As String
    End Class

    Public Class ShippingAddress
        Public Property line1 As String
        Public Property line2 As String
        Public Property city As String
        Public Property state As String
        Public Property zipCode As String
        Public Property countryCode As String
    End Class

    Public Class Buyer
        Public Property contact As Contact
        Public Property firstName As String
        Public Property lastName As String
        Public Property middleName As String
        Public Property billingAddress As BillingAddress
        Public Property shippingAddress As ShippingAddress
    End Class

    Public Class Merchant
        Public Property currency As String
        Public Property email As String
        Public Property locale As String
        Public Property homepageUrl As String
        Public Property isEmailToMerchantEnabled As Boolean
        Public Property isEmailToBuyerEnabled As Boolean
        Public Property isPaymentFacilitator As Boolean
        Public Property isPageCustomized As Boolean
        Public Property supportedSchemes As String()
        Public Property canPayPal As Boolean
        Public Property payPalEmail As Object
        Public Property payPalWebExperienceId As Object
        Public Property expressCheckout As Boolean
        Public Property name As String
    End Class

    Public Class RedirectUrl
        Public Property success As String
        Public Property failure As String
        Public Property cancel As String
    End Class

    Public Class GetCheckoutModel
        Public Property id As String
        Public Property items As Item()
        Public Property metadata As Metadata
        Public Property requestReferenceNumber As String
        Public Property receiptNumber As String
        Public Property createdAt As DateTime
        Public Property updatedAt As DateTime
        Public Property paymentScheme As String
        Public Property expressCheckout As Boolean
        Public Property refundedAmount As String
        Public Property canPayPal As Boolean
        Public Property expiredAt As DateTime
        Public Property status As String
        Public Property paymentStatus As String
        Public Property paymentDetails As PaymentDetails
        Public Property buyer As Buyer
        Public Property merchant As Merchant
        Public Property totalAmount As TotalAmount
        Public Property redirectUrl As RedirectUrl
        Public Property transactionReferenceNumber As String
    End Class



End Namespace

Namespace GetPaymentAPI
    Public Class Details
        Public Property scheme As String
        Public Property last4 As String
        Public Property first6 As String
        Public Property masked As String
        Public Property issuer As String
    End Class

    Public Class FundSource
        Public Property type As String
        Public Property id As String
        Public Property description As String
        Public Property details As Details
    End Class

    Public Class Receipt
        Public Property transactionId As String
        Public Property receiptNo As String
        Public Property approval_code As String
        Public Property approvalCode As String
    End Class

    Public Class Metadata
    End Class

    Public Class GetPaymentClass
        Public Property id As String
        Public Property isPaid As Boolean
        Public Property status As String
        Public Property amount As String
        Public Property currency As String
        Public Property canVoid As Boolean
        Public Property canRefund As Boolean
        Public Property canCapture As Boolean
        Public Property createdAt As DateTime
        Public Property updatedAt As DateTime
        Public Property description As String
        Public Property paymentTokenId As String
        Public Property fundSource As FundSource
        Public Property receipt As Receipt
        Public Property metadata As Metadata
        Public Property approvalCode As String
        Public Property receiptNumber As String
        Public Property requestReferenceNumber As String
    End Class



End Namespace


