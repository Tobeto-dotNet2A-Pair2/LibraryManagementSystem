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
        
        return featureOperationClaims;
    }
#pragma warning restore S1854 // Unused assignments should be removed
}
