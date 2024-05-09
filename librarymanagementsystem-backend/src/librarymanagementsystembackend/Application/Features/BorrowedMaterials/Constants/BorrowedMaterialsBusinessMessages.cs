namespace Application.Features.BorrowedMaterials.Constants;

public static class BorrowedMaterialsBusinessMessages
{
    public const string SectionName = "BorrowedMaterial";

    public const string BorrowedMaterialNotExists = "BorrowedMaterialNotExists";
    
    public const string MemberHasDebt = "MemberHasDebt";
    
    public const string MemberAlreadyHaveThisMaterialCopy = "MemberAlreadyHaveThisMaterialCopy";
    
    public const string MemberHasNotThisMaterialCopy = "MemberHasNotThisMaterialCopy";

    public const string BorrowedMaterialEmailHtmlBody = "Merhaba %FullName%, </br> Ödünç almış olduğunuz Kitap : %MaterialName% </br> Teslim Tarihi : %ReturnDate%";

    public const string BorrowedMaterialEmailSubject = "Tobeto Kütüphanesi Ödünç Alma İşleminiz";
    
}