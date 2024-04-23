using Application.Features.Auth.Constants;
using Application.Features.OperationClaims.Constants;
using Application.Features.UserOperationClaims.Constants;
using Application.Features.Users.Constants;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NArchitecture.Core.Security.Constants;
using Application.Features.Members.Constants;
using Application.Features.Addresses.Constants;
using Application.Features.Streets.Constants;
using Application.Features.Neighborhoods.Constants;
using Application.Features.Districts.Constants;
using Application.Features.Cities.Constants;
using Application.Features.Branches.Constants;
using Application.Features.Libraries.Constants;
using Application.Features.PaymentMethods.Constants;
using Application.Features.SocialMediaAccounts.Constants;
using Application.Features.MaterialCopies.Constants;
using Application.Features.Locations.Constants;
using Application.Features.Materials.Constants;
using Application.Features.Publishers.Constants;
using Application.Features.Languages.Constants;
using Application.Features.Authors.Constants;
using Application.Features.Translators.Constants;
using Application.Features.FavoriteLists.Constants;
using Application.Features.Notifications.Constants;
using Application.Features.BorrowedMaterials.Constants;
using Application.Features.Penalties.Constants;
using Application.Features.MaterialProperties.Constants;
using Application.Features.MaterialPropertyValues.Constants;
using Application.Features.MaterialTypes.Constants;
using Application.Features.MemberContacts.Constants;
using Application.Features.Members.Constants;
using Application.Features.Notifications.Constants;
using Application.Features.BorrowedMaterials.Constants;
using Application.Features.Members.Constants;
using Application.Features.AuthorMaterials.Constants;
using Application.Features.FavoriteListMaterials.Constants;
using Application.Features.LanguageMaterials.Constants;
using Application.Features.MemberAddresses.Constants;
using Application.Features.MemberNotifications.Constants;
using Application.Features.PublisherMaterials.Constants;
using Application.Features.TranslatorMaterials.Constants;
using Application.Features.Genres.Constants;
using Application.Features.MaterialGenres.Constants;









namespace Persistence.EntityConfigurations;

public class OperationClaimConfiguration : IEntityTypeConfiguration<OperationClaim>
{
    public void Configure(EntityTypeBuilder<OperationClaim> builder)
    {
        builder.ToTable("OperationClaims").HasKey(oc => oc.Id);

        builder.Property(oc => oc.Id).HasColumnName("Id").IsRequired();
        builder.Property(oc => oc.Name).HasColumnName("Name").IsRequired();
        builder.Property(oc => oc.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(oc => oc.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(oc => oc.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(oc => !oc.DeletedDate.HasValue);

        builder.HasData(_seeds);

        builder.HasBaseType((string)null!);
    }

    public static int AdminId => 1;
    private IEnumerable<OperationClaim> _seeds
    {
        get
        {
            yield return new() { Id = AdminId, Name = GeneralOperationClaims.Admin };

            IEnumerable<OperationClaim> featureOperationClaims = getFeatureOperationClaims(AdminId);
            foreach (OperationClaim claim in featureOperationClaims)
                yield return claim;
        }
    }

#pragma warning disable S1854 // Unused assignments should be removed
    private IEnumerable<OperationClaim> getFeatureOperationClaims(int initialId)
    {
        int lastId = initialId;
        List<OperationClaim> featureOperationClaims = new();

        #region Auth
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = AuthOperationClaims.Admin },
                new() { Id = ++lastId, Name = AuthOperationClaims.Read },
                new() { Id = ++lastId, Name = AuthOperationClaims.Write },
                new() { Id = ++lastId, Name = AuthOperationClaims.RevokeToken },
            ]
        );
        #endregion

        #region OperationClaims
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = OperationClaimsOperationClaims.Admin },
                new() { Id = ++lastId, Name = OperationClaimsOperationClaims.Read },
                new() { Id = ++lastId, Name = OperationClaimsOperationClaims.Write },
                new() { Id = ++lastId, Name = OperationClaimsOperationClaims.Create },
                new() { Id = ++lastId, Name = OperationClaimsOperationClaims.Update },
                new() { Id = ++lastId, Name = OperationClaimsOperationClaims.Delete },
            ]
        );
        #endregion

        #region UserOperationClaims
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = UserOperationClaimsOperationClaims.Admin },
                new() { Id = ++lastId, Name = UserOperationClaimsOperationClaims.Read },
                new() { Id = ++lastId, Name = UserOperationClaimsOperationClaims.Write },
                new() { Id = ++lastId, Name = UserOperationClaimsOperationClaims.Create },
                new() { Id = ++lastId, Name = UserOperationClaimsOperationClaims.Update },
                new() { Id = ++lastId, Name = UserOperationClaimsOperationClaims.Delete },
            ]
        );
        #endregion

        #region Users
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = UsersOperationClaims.Admin },
                new() { Id = ++lastId, Name = UsersOperationClaims.Read },
                new() { Id = ++lastId, Name = UsersOperationClaims.Write },
                new() { Id = ++lastId, Name = UsersOperationClaims.Create },
                new() { Id = ++lastId, Name = UsersOperationClaims.Update },
                new() { Id = ++lastId, Name = UsersOperationClaims.Delete },
            ]
        );
        #endregion

        
        #region Members
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = MembersOperationClaims.Admin },
                new() { Id = ++lastId, Name = MembersOperationClaims.Read },
                new() { Id = ++lastId, Name = MembersOperationClaims.Write },
                new() { Id = ++lastId, Name = MembersOperationClaims.Create },
                new() { Id = ++lastId, Name = MembersOperationClaims.Update },
                new() { Id = ++lastId, Name = MembersOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region Addresses
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = AddressesOperationClaims.Admin },
                new() { Id = ++lastId, Name = AddressesOperationClaims.Read },
                new() { Id = ++lastId, Name = AddressesOperationClaims.Write },
                new() { Id = ++lastId, Name = AddressesOperationClaims.Create },
                new() { Id = ++lastId, Name = AddressesOperationClaims.Update },
                new() { Id = ++lastId, Name = AddressesOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region Streets
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = StreetsOperationClaims.Admin },
                new() { Id = ++lastId, Name = StreetsOperationClaims.Read },
                new() { Id = ++lastId, Name = StreetsOperationClaims.Write },
                new() { Id = ++lastId, Name = StreetsOperationClaims.Create },
                new() { Id = ++lastId, Name = StreetsOperationClaims.Update },
                new() { Id = ++lastId, Name = StreetsOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region Neighborhoods
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = NeighborhoodsOperationClaims.Admin },
                new() { Id = ++lastId, Name = NeighborhoodsOperationClaims.Read },
                new() { Id = ++lastId, Name = NeighborhoodsOperationClaims.Write },
                new() { Id = ++lastId, Name = NeighborhoodsOperationClaims.Create },
                new() { Id = ++lastId, Name = NeighborhoodsOperationClaims.Update },
                new() { Id = ++lastId, Name = NeighborhoodsOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region Districts
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = DistrictsOperationClaims.Admin },
                new() { Id = ++lastId, Name = DistrictsOperationClaims.Read },
                new() { Id = ++lastId, Name = DistrictsOperationClaims.Write },
                new() { Id = ++lastId, Name = DistrictsOperationClaims.Create },
                new() { Id = ++lastId, Name = DistrictsOperationClaims.Update },
                new() { Id = ++lastId, Name = DistrictsOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region Cities
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = CitiesOperationClaims.Admin },
                new() { Id = ++lastId, Name = CitiesOperationClaims.Read },
                new() { Id = ++lastId, Name = CitiesOperationClaims.Write },
                new() { Id = ++lastId, Name = CitiesOperationClaims.Create },
                new() { Id = ++lastId, Name = CitiesOperationClaims.Update },
                new() { Id = ++lastId, Name = CitiesOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region Branches
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = BranchesOperationClaims.Admin },
                new() { Id = ++lastId, Name = BranchesOperationClaims.Read },
                new() { Id = ++lastId, Name = BranchesOperationClaims.Write },
                new() { Id = ++lastId, Name = BranchesOperationClaims.Create },
                new() { Id = ++lastId, Name = BranchesOperationClaims.Update },
                new() { Id = ++lastId, Name = BranchesOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region Libraries
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = LibrariesOperationClaims.Admin },
                new() { Id = ++lastId, Name = LibrariesOperationClaims.Read },
                new() { Id = ++lastId, Name = LibrariesOperationClaims.Write },
                new() { Id = ++lastId, Name = LibrariesOperationClaims.Create },
                new() { Id = ++lastId, Name = LibrariesOperationClaims.Update },
                new() { Id = ++lastId, Name = LibrariesOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region PaymentMethods
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = PaymentMethodsOperationClaims.Admin },
                new() { Id = ++lastId, Name = PaymentMethodsOperationClaims.Read },
                new() { Id = ++lastId, Name = PaymentMethodsOperationClaims.Write },
                new() { Id = ++lastId, Name = PaymentMethodsOperationClaims.Create },
                new() { Id = ++lastId, Name = PaymentMethodsOperationClaims.Update },
                new() { Id = ++lastId, Name = PaymentMethodsOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region SocialMediaAccounts
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = SocialMediaAccountsOperationClaims.Admin },
                new() { Id = ++lastId, Name = SocialMediaAccountsOperationClaims.Read },
                new() { Id = ++lastId, Name = SocialMediaAccountsOperationClaims.Write },
                new() { Id = ++lastId, Name = SocialMediaAccountsOperationClaims.Create },
                new() { Id = ++lastId, Name = SocialMediaAccountsOperationClaims.Update },
                new() { Id = ++lastId, Name = SocialMediaAccountsOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region MaterialCopies
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = MaterialCopiesOperationClaims.Admin },
                new() { Id = ++lastId, Name = MaterialCopiesOperationClaims.Read },
                new() { Id = ++lastId, Name = MaterialCopiesOperationClaims.Write },
                new() { Id = ++lastId, Name = MaterialCopiesOperationClaims.Create },
                new() { Id = ++lastId, Name = MaterialCopiesOperationClaims.Update },
                new() { Id = ++lastId, Name = MaterialCopiesOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region Locations
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = LocationsOperationClaims.Admin },
                new() { Id = ++lastId, Name = LocationsOperationClaims.Read },
                new() { Id = ++lastId, Name = LocationsOperationClaims.Write },
                new() { Id = ++lastId, Name = LocationsOperationClaims.Create },
                new() { Id = ++lastId, Name = LocationsOperationClaims.Update },
                new() { Id = ++lastId, Name = LocationsOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region Materials
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = MaterialsOperationClaims.Admin },
                new() { Id = ++lastId, Name = MaterialsOperationClaims.Read },
                new() { Id = ++lastId, Name = MaterialsOperationClaims.Write },
                new() { Id = ++lastId, Name = MaterialsOperationClaims.Create },
                new() { Id = ++lastId, Name = MaterialsOperationClaims.Update },
                new() { Id = ++lastId, Name = MaterialsOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region Locations
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = LocationsOperationClaims.Admin },
                new() { Id = ++lastId, Name = LocationsOperationClaims.Read },
                new() { Id = ++lastId, Name = LocationsOperationClaims.Write },
                new() { Id = ++lastId, Name = LocationsOperationClaims.Create },
                new() { Id = ++lastId, Name = LocationsOperationClaims.Update },
                new() { Id = ++lastId, Name = LocationsOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region MaterialCopies
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = MaterialCopiesOperationClaims.Admin },
                new() { Id = ++lastId, Name = MaterialCopiesOperationClaims.Read },
                new() { Id = ++lastId, Name = MaterialCopiesOperationClaims.Write },
                new() { Id = ++lastId, Name = MaterialCopiesOperationClaims.Create },
                new() { Id = ++lastId, Name = MaterialCopiesOperationClaims.Update },
                new() { Id = ++lastId, Name = MaterialCopiesOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region Locations
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = LocationsOperationClaims.Admin },
                new() { Id = ++lastId, Name = LocationsOperationClaims.Read },
                new() { Id = ++lastId, Name = LocationsOperationClaims.Write },
                new() { Id = ++lastId, Name = LocationsOperationClaims.Create },
                new() { Id = ++lastId, Name = LocationsOperationClaims.Update },
                new() { Id = ++lastId, Name = LocationsOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region Publishers
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = PublishersOperationClaims.Admin },
                new() { Id = ++lastId, Name = PublishersOperationClaims.Read },
                new() { Id = ++lastId, Name = PublishersOperationClaims.Write },
                new() { Id = ++lastId, Name = PublishersOperationClaims.Create },
                new() { Id = ++lastId, Name = PublishersOperationClaims.Update },
                new() { Id = ++lastId, Name = PublishersOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region Languages
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = LanguagesOperationClaims.Admin },
                new() { Id = ++lastId, Name = LanguagesOperationClaims.Read },
                new() { Id = ++lastId, Name = LanguagesOperationClaims.Write },
                new() { Id = ++lastId, Name = LanguagesOperationClaims.Create },
                new() { Id = ++lastId, Name = LanguagesOperationClaims.Update },
                new() { Id = ++lastId, Name = LanguagesOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region Authors
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = AuthorsOperationClaims.Admin },
                new() { Id = ++lastId, Name = AuthorsOperationClaims.Read },
                new() { Id = ++lastId, Name = AuthorsOperationClaims.Write },
                new() { Id = ++lastId, Name = AuthorsOperationClaims.Create },
                new() { Id = ++lastId, Name = AuthorsOperationClaims.Update },
                new() { Id = ++lastId, Name = AuthorsOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region Translators
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = TranslatorsOperationClaims.Admin },
                new() { Id = ++lastId, Name = TranslatorsOperationClaims.Read },
                new() { Id = ++lastId, Name = TranslatorsOperationClaims.Write },
                new() { Id = ++lastId, Name = TranslatorsOperationClaims.Create },
                new() { Id = ++lastId, Name = TranslatorsOperationClaims.Update },
                new() { Id = ++lastId, Name = TranslatorsOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region FavoriteLists
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = FavoriteListsOperationClaims.Admin },
                new() { Id = ++lastId, Name = FavoriteListsOperationClaims.Read },
                new() { Id = ++lastId, Name = FavoriteListsOperationClaims.Write },
                new() { Id = ++lastId, Name = FavoriteListsOperationClaims.Create },
                new() { Id = ++lastId, Name = FavoriteListsOperationClaims.Update },
                new() { Id = ++lastId, Name = FavoriteListsOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region Notifications
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = NotificationsOperationClaims.Admin },
                new() { Id = ++lastId, Name = NotificationsOperationClaims.Read },
                new() { Id = ++lastId, Name = NotificationsOperationClaims.Write },
                new() { Id = ++lastId, Name = NotificationsOperationClaims.Create },
                new() { Id = ++lastId, Name = NotificationsOperationClaims.Update },
                new() { Id = ++lastId, Name = NotificationsOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region Notifications
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = NotificationsOperationClaims.Admin },
                new() { Id = ++lastId, Name = NotificationsOperationClaims.Read },
                new() { Id = ++lastId, Name = NotificationsOperationClaims.Write },
                new() { Id = ++lastId, Name = NotificationsOperationClaims.Create },
                new() { Id = ++lastId, Name = NotificationsOperationClaims.Update },
                new() { Id = ++lastId, Name = NotificationsOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region BorrowedMaterials
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = BorrowedMaterialsOperationClaims.Admin },
                new() { Id = ++lastId, Name = BorrowedMaterialsOperationClaims.Read },
                new() { Id = ++lastId, Name = BorrowedMaterialsOperationClaims.Write },
                new() { Id = ++lastId, Name = BorrowedMaterialsOperationClaims.Create },
                new() { Id = ++lastId, Name = BorrowedMaterialsOperationClaims.Update },
                new() { Id = ++lastId, Name = BorrowedMaterialsOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region Materials
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = MaterialsOperationClaims.Admin },
                new() { Id = ++lastId, Name = MaterialsOperationClaims.Read },
                new() { Id = ++lastId, Name = MaterialsOperationClaims.Write },
                new() { Id = ++lastId, Name = MaterialsOperationClaims.Create },
                new() { Id = ++lastId, Name = MaterialsOperationClaims.Update },
                new() { Id = ++lastId, Name = MaterialsOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region MaterialCopies
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = MaterialCopiesOperationClaims.Admin },
                new() { Id = ++lastId, Name = MaterialCopiesOperationClaims.Read },
                new() { Id = ++lastId, Name = MaterialCopiesOperationClaims.Write },
                new() { Id = ++lastId, Name = MaterialCopiesOperationClaims.Create },
                new() { Id = ++lastId, Name = MaterialCopiesOperationClaims.Update },
                new() { Id = ++lastId, Name = MaterialCopiesOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region Members
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = MembersOperationClaims.Admin },
                new() { Id = ++lastId, Name = MembersOperationClaims.Read },
                new() { Id = ++lastId, Name = MembersOperationClaims.Write },
                new() { Id = ++lastId, Name = MembersOperationClaims.Create },
                new() { Id = ++lastId, Name = MembersOperationClaims.Update },
                new() { Id = ++lastId, Name = MembersOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region Penalties
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = PenaltiesOperationClaims.Admin },
                new() { Id = ++lastId, Name = PenaltiesOperationClaims.Read },
                new() { Id = ++lastId, Name = PenaltiesOperationClaims.Write },
                new() { Id = ++lastId, Name = PenaltiesOperationClaims.Create },
                new() { Id = ++lastId, Name = PenaltiesOperationClaims.Update },
                new() { Id = ++lastId, Name = PenaltiesOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region Addresses
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = AddressesOperationClaims.Admin },
                new() { Id = ++lastId, Name = AddressesOperationClaims.Read },
                new() { Id = ++lastId, Name = AddressesOperationClaims.Write },
                new() { Id = ++lastId, Name = AddressesOperationClaims.Create },
                new() { Id = ++lastId, Name = AddressesOperationClaims.Update },
                new() { Id = ++lastId, Name = AddressesOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region Authors
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = AuthorsOperationClaims.Admin },
                new() { Id = ++lastId, Name = AuthorsOperationClaims.Read },
                new() { Id = ++lastId, Name = AuthorsOperationClaims.Write },
                new() { Id = ++lastId, Name = AuthorsOperationClaims.Create },
                new() { Id = ++lastId, Name = AuthorsOperationClaims.Update },
                new() { Id = ++lastId, Name = AuthorsOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region BorrowedMaterials
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = BorrowedMaterialsOperationClaims.Admin },
                new() { Id = ++lastId, Name = BorrowedMaterialsOperationClaims.Read },
                new() { Id = ++lastId, Name = BorrowedMaterialsOperationClaims.Write },
                new() { Id = ++lastId, Name = BorrowedMaterialsOperationClaims.Create },
                new() { Id = ++lastId, Name = BorrowedMaterialsOperationClaims.Update },
                new() { Id = ++lastId, Name = BorrowedMaterialsOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region Branches
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = BranchesOperationClaims.Admin },
                new() { Id = ++lastId, Name = BranchesOperationClaims.Read },
                new() { Id = ++lastId, Name = BranchesOperationClaims.Write },
                new() { Id = ++lastId, Name = BranchesOperationClaims.Create },
                new() { Id = ++lastId, Name = BranchesOperationClaims.Update },
                new() { Id = ++lastId, Name = BranchesOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region Cities
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = CitiesOperationClaims.Admin },
                new() { Id = ++lastId, Name = CitiesOperationClaims.Read },
                new() { Id = ++lastId, Name = CitiesOperationClaims.Write },
                new() { Id = ++lastId, Name = CitiesOperationClaims.Create },
                new() { Id = ++lastId, Name = CitiesOperationClaims.Update },
                new() { Id = ++lastId, Name = CitiesOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region Districts
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = DistrictsOperationClaims.Admin },
                new() { Id = ++lastId, Name = DistrictsOperationClaims.Read },
                new() { Id = ++lastId, Name = DistrictsOperationClaims.Write },
                new() { Id = ++lastId, Name = DistrictsOperationClaims.Create },
                new() { Id = ++lastId, Name = DistrictsOperationClaims.Update },
                new() { Id = ++lastId, Name = DistrictsOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region FavoriteLists
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = FavoriteListsOperationClaims.Admin },
                new() { Id = ++lastId, Name = FavoriteListsOperationClaims.Read },
                new() { Id = ++lastId, Name = FavoriteListsOperationClaims.Write },
                new() { Id = ++lastId, Name = FavoriteListsOperationClaims.Create },
                new() { Id = ++lastId, Name = FavoriteListsOperationClaims.Update },
                new() { Id = ++lastId, Name = FavoriteListsOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region Languages
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = LanguagesOperationClaims.Admin },
                new() { Id = ++lastId, Name = LanguagesOperationClaims.Read },
                new() { Id = ++lastId, Name = LanguagesOperationClaims.Write },
                new() { Id = ++lastId, Name = LanguagesOperationClaims.Create },
                new() { Id = ++lastId, Name = LanguagesOperationClaims.Update },
                new() { Id = ++lastId, Name = LanguagesOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region Libraries
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = LibrariesOperationClaims.Admin },
                new() { Id = ++lastId, Name = LibrariesOperationClaims.Read },
                new() { Id = ++lastId, Name = LibrariesOperationClaims.Write },
                new() { Id = ++lastId, Name = LibrariesOperationClaims.Create },
                new() { Id = ++lastId, Name = LibrariesOperationClaims.Update },
                new() { Id = ++lastId, Name = LibrariesOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region Locations
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = LocationsOperationClaims.Admin },
                new() { Id = ++lastId, Name = LocationsOperationClaims.Read },
                new() { Id = ++lastId, Name = LocationsOperationClaims.Write },
                new() { Id = ++lastId, Name = LocationsOperationClaims.Create },
                new() { Id = ++lastId, Name = LocationsOperationClaims.Update },
                new() { Id = ++lastId, Name = LocationsOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region Materials
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = MaterialsOperationClaims.Admin },
                new() { Id = ++lastId, Name = MaterialsOperationClaims.Read },
                new() { Id = ++lastId, Name = MaterialsOperationClaims.Write },
                new() { Id = ++lastId, Name = MaterialsOperationClaims.Create },
                new() { Id = ++lastId, Name = MaterialsOperationClaims.Update },
                new() { Id = ++lastId, Name = MaterialsOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region MaterialCopies
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = MaterialCopiesOperationClaims.Admin },
                new() { Id = ++lastId, Name = MaterialCopiesOperationClaims.Read },
                new() { Id = ++lastId, Name = MaterialCopiesOperationClaims.Write },
                new() { Id = ++lastId, Name = MaterialCopiesOperationClaims.Create },
                new() { Id = ++lastId, Name = MaterialCopiesOperationClaims.Update },
                new() { Id = ++lastId, Name = MaterialCopiesOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region MaterialProperties
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = MaterialPropertiesOperationClaims.Admin },
                new() { Id = ++lastId, Name = MaterialPropertiesOperationClaims.Read },
                new() { Id = ++lastId, Name = MaterialPropertiesOperationClaims.Write },
                new() { Id = ++lastId, Name = MaterialPropertiesOperationClaims.Create },
                new() { Id = ++lastId, Name = MaterialPropertiesOperationClaims.Update },
                new() { Id = ++lastId, Name = MaterialPropertiesOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region MaterialPropertyValues
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = MaterialPropertyValuesOperationClaims.Admin },
                new() { Id = ++lastId, Name = MaterialPropertyValuesOperationClaims.Read },
                new() { Id = ++lastId, Name = MaterialPropertyValuesOperationClaims.Write },
                new() { Id = ++lastId, Name = MaterialPropertyValuesOperationClaims.Create },
                new() { Id = ++lastId, Name = MaterialPropertyValuesOperationClaims.Update },
                new() { Id = ++lastId, Name = MaterialPropertyValuesOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region MaterialTypes
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = MaterialTypesOperationClaims.Admin },
                new() { Id = ++lastId, Name = MaterialTypesOperationClaims.Read },
                new() { Id = ++lastId, Name = MaterialTypesOperationClaims.Write },
                new() { Id = ++lastId, Name = MaterialTypesOperationClaims.Create },
                new() { Id = ++lastId, Name = MaterialTypesOperationClaims.Update },
                new() { Id = ++lastId, Name = MaterialTypesOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region Members
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = MembersOperationClaims.Admin },
                new() { Id = ++lastId, Name = MembersOperationClaims.Read },
                new() { Id = ++lastId, Name = MembersOperationClaims.Write },
                new() { Id = ++lastId, Name = MembersOperationClaims.Create },
                new() { Id = ++lastId, Name = MembersOperationClaims.Update },
                new() { Id = ++lastId, Name = MembersOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region Neighborhoods
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = NeighborhoodsOperationClaims.Admin },
                new() { Id = ++lastId, Name = NeighborhoodsOperationClaims.Read },
                new() { Id = ++lastId, Name = NeighborhoodsOperationClaims.Write },
                new() { Id = ++lastId, Name = NeighborhoodsOperationClaims.Create },
                new() { Id = ++lastId, Name = NeighborhoodsOperationClaims.Update },
                new() { Id = ++lastId, Name = NeighborhoodsOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region Notifications
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = NotificationsOperationClaims.Admin },
                new() { Id = ++lastId, Name = NotificationsOperationClaims.Read },
                new() { Id = ++lastId, Name = NotificationsOperationClaims.Write },
                new() { Id = ++lastId, Name = NotificationsOperationClaims.Create },
                new() { Id = ++lastId, Name = NotificationsOperationClaims.Update },
                new() { Id = ++lastId, Name = NotificationsOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region PaymentMethods
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = PaymentMethodsOperationClaims.Admin },
                new() { Id = ++lastId, Name = PaymentMethodsOperationClaims.Read },
                new() { Id = ++lastId, Name = PaymentMethodsOperationClaims.Write },
                new() { Id = ++lastId, Name = PaymentMethodsOperationClaims.Create },
                new() { Id = ++lastId, Name = PaymentMethodsOperationClaims.Update },
                new() { Id = ++lastId, Name = PaymentMethodsOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region Penalties
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = PenaltiesOperationClaims.Admin },
                new() { Id = ++lastId, Name = PenaltiesOperationClaims.Read },
                new() { Id = ++lastId, Name = PenaltiesOperationClaims.Write },
                new() { Id = ++lastId, Name = PenaltiesOperationClaims.Create },
                new() { Id = ++lastId, Name = PenaltiesOperationClaims.Update },
                new() { Id = ++lastId, Name = PenaltiesOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region Publishers
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = PublishersOperationClaims.Admin },
                new() { Id = ++lastId, Name = PublishersOperationClaims.Read },
                new() { Id = ++lastId, Name = PublishersOperationClaims.Write },
                new() { Id = ++lastId, Name = PublishersOperationClaims.Create },
                new() { Id = ++lastId, Name = PublishersOperationClaims.Update },
                new() { Id = ++lastId, Name = PublishersOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region SocialMediaAccounts
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = SocialMediaAccountsOperationClaims.Admin },
                new() { Id = ++lastId, Name = SocialMediaAccountsOperationClaims.Read },
                new() { Id = ++lastId, Name = SocialMediaAccountsOperationClaims.Write },
                new() { Id = ++lastId, Name = SocialMediaAccountsOperationClaims.Create },
                new() { Id = ++lastId, Name = SocialMediaAccountsOperationClaims.Update },
                new() { Id = ++lastId, Name = SocialMediaAccountsOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region Streets
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = StreetsOperationClaims.Admin },
                new() { Id = ++lastId, Name = StreetsOperationClaims.Read },
                new() { Id = ++lastId, Name = StreetsOperationClaims.Write },
                new() { Id = ++lastId, Name = StreetsOperationClaims.Create },
                new() { Id = ++lastId, Name = StreetsOperationClaims.Update },
                new() { Id = ++lastId, Name = StreetsOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region Translators
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = TranslatorsOperationClaims.Admin },
                new() { Id = ++lastId, Name = TranslatorsOperationClaims.Read },
                new() { Id = ++lastId, Name = TranslatorsOperationClaims.Write },
                new() { Id = ++lastId, Name = TranslatorsOperationClaims.Create },
                new() { Id = ++lastId, Name = TranslatorsOperationClaims.Update },
                new() { Id = ++lastId, Name = TranslatorsOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region BorrowedMaterials
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = BorrowedMaterialsOperationClaims.Admin },
                new() { Id = ++lastId, Name = BorrowedMaterialsOperationClaims.Read },
                new() { Id = ++lastId, Name = BorrowedMaterialsOperationClaims.Write },
                new() { Id = ++lastId, Name = BorrowedMaterialsOperationClaims.Create },
                new() { Id = ++lastId, Name = BorrowedMaterialsOperationClaims.Update },
                new() { Id = ++lastId, Name = BorrowedMaterialsOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region BorrowedMaterials
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = BorrowedMaterialsOperationClaims.Admin },
                new() { Id = ++lastId, Name = BorrowedMaterialsOperationClaims.Read },
                new() { Id = ++lastId, Name = BorrowedMaterialsOperationClaims.Write },
                new() { Id = ++lastId, Name = BorrowedMaterialsOperationClaims.Create },
                new() { Id = ++lastId, Name = BorrowedMaterialsOperationClaims.Update },
                new() { Id = ++lastId, Name = BorrowedMaterialsOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region MaterialCopies
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = MaterialCopiesOperationClaims.Admin },
                new() { Id = ++lastId, Name = MaterialCopiesOperationClaims.Read },
                new() { Id = ++lastId, Name = MaterialCopiesOperationClaims.Write },
                new() { Id = ++lastId, Name = MaterialCopiesOperationClaims.Create },
                new() { Id = ++lastId, Name = MaterialCopiesOperationClaims.Update },
                new() { Id = ++lastId, Name = MaterialCopiesOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region Members
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = MembersOperationClaims.Admin },
                new() { Id = ++lastId, Name = MembersOperationClaims.Read },
                new() { Id = ++lastId, Name = MembersOperationClaims.Write },
                new() { Id = ++lastId, Name = MembersOperationClaims.Create },
                new() { Id = ++lastId, Name = MembersOperationClaims.Update },
                new() { Id = ++lastId, Name = MembersOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region MemberContacts
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = MemberContactsOperationClaims.Admin },
                new() { Id = ++lastId, Name = MemberContactsOperationClaims.Read },
                new() { Id = ++lastId, Name = MemberContactsOperationClaims.Write },
                new() { Id = ++lastId, Name = MemberContactsOperationClaims.Create },
                new() { Id = ++lastId, Name = MemberContactsOperationClaims.Update },
                new() { Id = ++lastId, Name = MemberContactsOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region Libraries
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = LibrariesOperationClaims.Admin },
                new() { Id = ++lastId, Name = LibrariesOperationClaims.Read },
                new() { Id = ++lastId, Name = LibrariesOperationClaims.Write },
                new() { Id = ++lastId, Name = LibrariesOperationClaims.Create },
                new() { Id = ++lastId, Name = LibrariesOperationClaims.Update },
                new() { Id = ++lastId, Name = LibrariesOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region Materials
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = MaterialsOperationClaims.Admin },
                new() { Id = ++lastId, Name = MaterialsOperationClaims.Read },
                new() { Id = ++lastId, Name = MaterialsOperationClaims.Write },
                new() { Id = ++lastId, Name = MaterialsOperationClaims.Create },
                new() { Id = ++lastId, Name = MaterialsOperationClaims.Update },
                new() { Id = ++lastId, Name = MaterialsOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region Notifications
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = NotificationsOperationClaims.Admin },
                new() { Id = ++lastId, Name = NotificationsOperationClaims.Read },
                new() { Id = ++lastId, Name = NotificationsOperationClaims.Write },
                new() { Id = ++lastId, Name = NotificationsOperationClaims.Create },
                new() { Id = ++lastId, Name = NotificationsOperationClaims.Update },
                new() { Id = ++lastId, Name = NotificationsOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region Penalties
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = PenaltiesOperationClaims.Admin },
                new() { Id = ++lastId, Name = PenaltiesOperationClaims.Read },
                new() { Id = ++lastId, Name = PenaltiesOperationClaims.Write },
                new() { Id = ++lastId, Name = PenaltiesOperationClaims.Create },
                new() { Id = ++lastId, Name = PenaltiesOperationClaims.Update },
                new() { Id = ++lastId, Name = PenaltiesOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region Members
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = MembersOperationClaims.Admin },
                new() { Id = ++lastId, Name = MembersOperationClaims.Read },
                new() { Id = ++lastId, Name = MembersOperationClaims.Write },
                new() { Id = ++lastId, Name = MembersOperationClaims.Create },
                new() { Id = ++lastId, Name = MembersOperationClaims.Update },
                new() { Id = ++lastId, Name = MembersOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region Notifications
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = NotificationsOperationClaims.Admin },
                new() { Id = ++lastId, Name = NotificationsOperationClaims.Read },
                new() { Id = ++lastId, Name = NotificationsOperationClaims.Write },
                new() { Id = ++lastId, Name = NotificationsOperationClaims.Create },
                new() { Id = ++lastId, Name = NotificationsOperationClaims.Update },
                new() { Id = ++lastId, Name = NotificationsOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region BorrowedMaterials
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = BorrowedMaterialsOperationClaims.Admin },
                new() { Id = ++lastId, Name = BorrowedMaterialsOperationClaims.Read },
                new() { Id = ++lastId, Name = BorrowedMaterialsOperationClaims.Write },
                new() { Id = ++lastId, Name = BorrowedMaterialsOperationClaims.Create },
                new() { Id = ++lastId, Name = BorrowedMaterialsOperationClaims.Update },
                new() { Id = ++lastId, Name = BorrowedMaterialsOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region Members
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = MembersOperationClaims.Admin },
                new() { Id = ++lastId, Name = MembersOperationClaims.Read },
                new() { Id = ++lastId, Name = MembersOperationClaims.Write },
                new() { Id = ++lastId, Name = MembersOperationClaims.Create },
                new() { Id = ++lastId, Name = MembersOperationClaims.Update },
                new() { Id = ++lastId, Name = MembersOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region Addresses
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = AddressesOperationClaims.Admin },
                new() { Id = ++lastId, Name = AddressesOperationClaims.Read },
                new() { Id = ++lastId, Name = AddressesOperationClaims.Write },
                new() { Id = ++lastId, Name = AddressesOperationClaims.Create },
                new() { Id = ++lastId, Name = AddressesOperationClaims.Update },
                new() { Id = ++lastId, Name = AddressesOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region Authors
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = AuthorsOperationClaims.Admin },
                new() { Id = ++lastId, Name = AuthorsOperationClaims.Read },
                new() { Id = ++lastId, Name = AuthorsOperationClaims.Write },
                new() { Id = ++lastId, Name = AuthorsOperationClaims.Create },
                new() { Id = ++lastId, Name = AuthorsOperationClaims.Update },
                new() { Id = ++lastId, Name = AuthorsOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region AuthorMaterials
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = AuthorMaterialsOperationClaims.Admin },
                new() { Id = ++lastId, Name = AuthorMaterialsOperationClaims.Read },
                new() { Id = ++lastId, Name = AuthorMaterialsOperationClaims.Write },
                new() { Id = ++lastId, Name = AuthorMaterialsOperationClaims.Create },
                new() { Id = ++lastId, Name = AuthorMaterialsOperationClaims.Update },
                new() { Id = ++lastId, Name = AuthorMaterialsOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region BorrowedMaterials
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = BorrowedMaterialsOperationClaims.Admin },
                new() { Id = ++lastId, Name = BorrowedMaterialsOperationClaims.Read },
                new() { Id = ++lastId, Name = BorrowedMaterialsOperationClaims.Write },
                new() { Id = ++lastId, Name = BorrowedMaterialsOperationClaims.Create },
                new() { Id = ++lastId, Name = BorrowedMaterialsOperationClaims.Update },
                new() { Id = ++lastId, Name = BorrowedMaterialsOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region Branches
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = BranchesOperationClaims.Admin },
                new() { Id = ++lastId, Name = BranchesOperationClaims.Read },
                new() { Id = ++lastId, Name = BranchesOperationClaims.Write },
                new() { Id = ++lastId, Name = BranchesOperationClaims.Create },
                new() { Id = ++lastId, Name = BranchesOperationClaims.Update },
                new() { Id = ++lastId, Name = BranchesOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region Cities
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = CitiesOperationClaims.Admin },
                new() { Id = ++lastId, Name = CitiesOperationClaims.Read },
                new() { Id = ++lastId, Name = CitiesOperationClaims.Write },
                new() { Id = ++lastId, Name = CitiesOperationClaims.Create },
                new() { Id = ++lastId, Name = CitiesOperationClaims.Update },
                new() { Id = ++lastId, Name = CitiesOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region Districts
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = DistrictsOperationClaims.Admin },
                new() { Id = ++lastId, Name = DistrictsOperationClaims.Read },
                new() { Id = ++lastId, Name = DistrictsOperationClaims.Write },
                new() { Id = ++lastId, Name = DistrictsOperationClaims.Create },
                new() { Id = ++lastId, Name = DistrictsOperationClaims.Update },
                new() { Id = ++lastId, Name = DistrictsOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region FavoriteLists
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = FavoriteListsOperationClaims.Admin },
                new() { Id = ++lastId, Name = FavoriteListsOperationClaims.Read },
                new() { Id = ++lastId, Name = FavoriteListsOperationClaims.Write },
                new() { Id = ++lastId, Name = FavoriteListsOperationClaims.Create },
                new() { Id = ++lastId, Name = FavoriteListsOperationClaims.Update },
                new() { Id = ++lastId, Name = FavoriteListsOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region FavoriteListMaterials
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = FavoriteListMaterialsOperationClaims.Admin },
                new() { Id = ++lastId, Name = FavoriteListMaterialsOperationClaims.Read },
                new() { Id = ++lastId, Name = FavoriteListMaterialsOperationClaims.Write },
                new() { Id = ++lastId, Name = FavoriteListMaterialsOperationClaims.Create },
                new() { Id = ++lastId, Name = FavoriteListMaterialsOperationClaims.Update },
                new() { Id = ++lastId, Name = FavoriteListMaterialsOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region Languages
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = LanguagesOperationClaims.Admin },
                new() { Id = ++lastId, Name = LanguagesOperationClaims.Read },
                new() { Id = ++lastId, Name = LanguagesOperationClaims.Write },
                new() { Id = ++lastId, Name = LanguagesOperationClaims.Create },
                new() { Id = ++lastId, Name = LanguagesOperationClaims.Update },
                new() { Id = ++lastId, Name = LanguagesOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region LanguageMaterials
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = LanguageMaterialsOperationClaims.Admin },
                new() { Id = ++lastId, Name = LanguageMaterialsOperationClaims.Read },
                new() { Id = ++lastId, Name = LanguageMaterialsOperationClaims.Write },
                new() { Id = ++lastId, Name = LanguageMaterialsOperationClaims.Create },
                new() { Id = ++lastId, Name = LanguageMaterialsOperationClaims.Update },
                new() { Id = ++lastId, Name = LanguageMaterialsOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region Libraries
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = LibrariesOperationClaims.Admin },
                new() { Id = ++lastId, Name = LibrariesOperationClaims.Read },
                new() { Id = ++lastId, Name = LibrariesOperationClaims.Write },
                new() { Id = ++lastId, Name = LibrariesOperationClaims.Create },
                new() { Id = ++lastId, Name = LibrariesOperationClaims.Update },
                new() { Id = ++lastId, Name = LibrariesOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region Locations
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = LocationsOperationClaims.Admin },
                new() { Id = ++lastId, Name = LocationsOperationClaims.Read },
                new() { Id = ++lastId, Name = LocationsOperationClaims.Write },
                new() { Id = ++lastId, Name = LocationsOperationClaims.Create },
                new() { Id = ++lastId, Name = LocationsOperationClaims.Update },
                new() { Id = ++lastId, Name = LocationsOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region Materials
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = MaterialsOperationClaims.Admin },
                new() { Id = ++lastId, Name = MaterialsOperationClaims.Read },
                new() { Id = ++lastId, Name = MaterialsOperationClaims.Write },
                new() { Id = ++lastId, Name = MaterialsOperationClaims.Create },
                new() { Id = ++lastId, Name = MaterialsOperationClaims.Update },
                new() { Id = ++lastId, Name = MaterialsOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region MaterialCopies
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = MaterialCopiesOperationClaims.Admin },
                new() { Id = ++lastId, Name = MaterialCopiesOperationClaims.Read },
                new() { Id = ++lastId, Name = MaterialCopiesOperationClaims.Write },
                new() { Id = ++lastId, Name = MaterialCopiesOperationClaims.Create },
                new() { Id = ++lastId, Name = MaterialCopiesOperationClaims.Update },
                new() { Id = ++lastId, Name = MaterialCopiesOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region MaterialProperties
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = MaterialPropertiesOperationClaims.Admin },
                new() { Id = ++lastId, Name = MaterialPropertiesOperationClaims.Read },
                new() { Id = ++lastId, Name = MaterialPropertiesOperationClaims.Write },
                new() { Id = ++lastId, Name = MaterialPropertiesOperationClaims.Create },
                new() { Id = ++lastId, Name = MaterialPropertiesOperationClaims.Update },
                new() { Id = ++lastId, Name = MaterialPropertiesOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region MaterialPropertyValues
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = MaterialPropertyValuesOperationClaims.Admin },
                new() { Id = ++lastId, Name = MaterialPropertyValuesOperationClaims.Read },
                new() { Id = ++lastId, Name = MaterialPropertyValuesOperationClaims.Write },
                new() { Id = ++lastId, Name = MaterialPropertyValuesOperationClaims.Create },
                new() { Id = ++lastId, Name = MaterialPropertyValuesOperationClaims.Update },
                new() { Id = ++lastId, Name = MaterialPropertyValuesOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region MaterialTypes
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = MaterialTypesOperationClaims.Admin },
                new() { Id = ++lastId, Name = MaterialTypesOperationClaims.Read },
                new() { Id = ++lastId, Name = MaterialTypesOperationClaims.Write },
                new() { Id = ++lastId, Name = MaterialTypesOperationClaims.Create },
                new() { Id = ++lastId, Name = MaterialTypesOperationClaims.Update },
                new() { Id = ++lastId, Name = MaterialTypesOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region Members
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = MembersOperationClaims.Admin },
                new() { Id = ++lastId, Name = MembersOperationClaims.Read },
                new() { Id = ++lastId, Name = MembersOperationClaims.Write },
                new() { Id = ++lastId, Name = MembersOperationClaims.Create },
                new() { Id = ++lastId, Name = MembersOperationClaims.Update },
                new() { Id = ++lastId, Name = MembersOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region MemberAddresses
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = MemberAddressesOperationClaims.Admin },
                new() { Id = ++lastId, Name = MemberAddressesOperationClaims.Read },
                new() { Id = ++lastId, Name = MemberAddressesOperationClaims.Write },
                new() { Id = ++lastId, Name = MemberAddressesOperationClaims.Create },
                new() { Id = ++lastId, Name = MemberAddressesOperationClaims.Update },
                new() { Id = ++lastId, Name = MemberAddressesOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region MemberContacts
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = MemberContactsOperationClaims.Admin },
                new() { Id = ++lastId, Name = MemberContactsOperationClaims.Read },
                new() { Id = ++lastId, Name = MemberContactsOperationClaims.Write },
                new() { Id = ++lastId, Name = MemberContactsOperationClaims.Create },
                new() { Id = ++lastId, Name = MemberContactsOperationClaims.Update },
                new() { Id = ++lastId, Name = MemberContactsOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region MemberNotifications
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = MemberNotificationsOperationClaims.Admin },
                new() { Id = ++lastId, Name = MemberNotificationsOperationClaims.Read },
                new() { Id = ++lastId, Name = MemberNotificationsOperationClaims.Write },
                new() { Id = ++lastId, Name = MemberNotificationsOperationClaims.Create },
                new() { Id = ++lastId, Name = MemberNotificationsOperationClaims.Update },
                new() { Id = ++lastId, Name = MemberNotificationsOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region Neighborhoods
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = NeighborhoodsOperationClaims.Admin },
                new() { Id = ++lastId, Name = NeighborhoodsOperationClaims.Read },
                new() { Id = ++lastId, Name = NeighborhoodsOperationClaims.Write },
                new() { Id = ++lastId, Name = NeighborhoodsOperationClaims.Create },
                new() { Id = ++lastId, Name = NeighborhoodsOperationClaims.Update },
                new() { Id = ++lastId, Name = NeighborhoodsOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region Notifications
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = NotificationsOperationClaims.Admin },
                new() { Id = ++lastId, Name = NotificationsOperationClaims.Read },
                new() { Id = ++lastId, Name = NotificationsOperationClaims.Write },
                new() { Id = ++lastId, Name = NotificationsOperationClaims.Create },
                new() { Id = ++lastId, Name = NotificationsOperationClaims.Update },
                new() { Id = ++lastId, Name = NotificationsOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region PaymentMethods
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = PaymentMethodsOperationClaims.Admin },
                new() { Id = ++lastId, Name = PaymentMethodsOperationClaims.Read },
                new() { Id = ++lastId, Name = PaymentMethodsOperationClaims.Write },
                new() { Id = ++lastId, Name = PaymentMethodsOperationClaims.Create },
                new() { Id = ++lastId, Name = PaymentMethodsOperationClaims.Update },
                new() { Id = ++lastId, Name = PaymentMethodsOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region Penalties
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = PenaltiesOperationClaims.Admin },
                new() { Id = ++lastId, Name = PenaltiesOperationClaims.Read },
                new() { Id = ++lastId, Name = PenaltiesOperationClaims.Write },
                new() { Id = ++lastId, Name = PenaltiesOperationClaims.Create },
                new() { Id = ++lastId, Name = PenaltiesOperationClaims.Update },
                new() { Id = ++lastId, Name = PenaltiesOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region Publishers
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = PublishersOperationClaims.Admin },
                new() { Id = ++lastId, Name = PublishersOperationClaims.Read },
                new() { Id = ++lastId, Name = PublishersOperationClaims.Write },
                new() { Id = ++lastId, Name = PublishersOperationClaims.Create },
                new() { Id = ++lastId, Name = PublishersOperationClaims.Update },
                new() { Id = ++lastId, Name = PublishersOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region PublisherMaterials
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = PublisherMaterialsOperationClaims.Admin },
                new() { Id = ++lastId, Name = PublisherMaterialsOperationClaims.Read },
                new() { Id = ++lastId, Name = PublisherMaterialsOperationClaims.Write },
                new() { Id = ++lastId, Name = PublisherMaterialsOperationClaims.Create },
                new() { Id = ++lastId, Name = PublisherMaterialsOperationClaims.Update },
                new() { Id = ++lastId, Name = PublisherMaterialsOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region SocialMediaAccounts
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = SocialMediaAccountsOperationClaims.Admin },
                new() { Id = ++lastId, Name = SocialMediaAccountsOperationClaims.Read },
                new() { Id = ++lastId, Name = SocialMediaAccountsOperationClaims.Write },
                new() { Id = ++lastId, Name = SocialMediaAccountsOperationClaims.Create },
                new() { Id = ++lastId, Name = SocialMediaAccountsOperationClaims.Update },
                new() { Id = ++lastId, Name = SocialMediaAccountsOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region Streets
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = StreetsOperationClaims.Admin },
                new() { Id = ++lastId, Name = StreetsOperationClaims.Read },
                new() { Id = ++lastId, Name = StreetsOperationClaims.Write },
                new() { Id = ++lastId, Name = StreetsOperationClaims.Create },
                new() { Id = ++lastId, Name = StreetsOperationClaims.Update },
                new() { Id = ++lastId, Name = StreetsOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region Translators
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = TranslatorsOperationClaims.Admin },
                new() { Id = ++lastId, Name = TranslatorsOperationClaims.Read },
                new() { Id = ++lastId, Name = TranslatorsOperationClaims.Write },
                new() { Id = ++lastId, Name = TranslatorsOperationClaims.Create },
                new() { Id = ++lastId, Name = TranslatorsOperationClaims.Update },
                new() { Id = ++lastId, Name = TranslatorsOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region TranslatorMaterials
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = TranslatorMaterialsOperationClaims.Admin },
                new() { Id = ++lastId, Name = TranslatorMaterialsOperationClaims.Read },
                new() { Id = ++lastId, Name = TranslatorMaterialsOperationClaims.Write },
                new() { Id = ++lastId, Name = TranslatorMaterialsOperationClaims.Create },
                new() { Id = ++lastId, Name = TranslatorMaterialsOperationClaims.Update },
                new() { Id = ++lastId, Name = TranslatorMaterialsOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region Genres
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = GenresOperationClaims.Admin },
                new() { Id = ++lastId, Name = GenresOperationClaims.Read },
                new() { Id = ++lastId, Name = GenresOperationClaims.Write },
                new() { Id = ++lastId, Name = GenresOperationClaims.Create },
                new() { Id = ++lastId, Name = GenresOperationClaims.Update },
                new() { Id = ++lastId, Name = GenresOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region MaterialGenres
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = MaterialGenresOperationClaims.Admin },
                new() { Id = ++lastId, Name = MaterialGenresOperationClaims.Read },
                new() { Id = ++lastId, Name = MaterialGenresOperationClaims.Write },
                new() { Id = ++lastId, Name = MaterialGenresOperationClaims.Create },
                new() { Id = ++lastId, Name = MaterialGenresOperationClaims.Update },
                new() { Id = ++lastId, Name = MaterialGenresOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region Materials
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = MaterialsOperationClaims.Admin },
                new() { Id = ++lastId, Name = MaterialsOperationClaims.Read },
                new() { Id = ++lastId, Name = MaterialsOperationClaims.Write },
                new() { Id = ++lastId, Name = MaterialsOperationClaims.Create },
                new() { Id = ++lastId, Name = MaterialsOperationClaims.Update },
                new() { Id = ++lastId, Name = MaterialsOperationClaims.Delete },
            ]
        );
        #endregion
        
        return featureOperationClaims;
    }
#pragma warning restore S1854 // Unused assignments should be removed
}
