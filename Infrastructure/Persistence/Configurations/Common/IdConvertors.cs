using BuberDinner.Domain.Bill.ValueObjects;
using BuberDinner.Domain.Dinner.ValueObjects;
using BuberDinner.Domain.Guest.ValueObjects;
using BuberDinner.Domain.Host.ValueObjects;
using BuberDinner.Domain.Menu.ValueObjects;
using BuberDinner.Domain.User.ValueObjects;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BuberDinner.Infrastructure.Persistence.Configurations.Common
{
    public static class IdConvertors
    {
        public static readonly ValueConverter<MenuId, Guid> MenuIdConvertor = new(
            id => id.Value,
            value => MenuId.Create(value));

        public static readonly ValueConverter<HostId, Guid> HostIdConvertor = new(
            id => id.Value,
            value => HostId.Create(value));

        public static readonly ValueConverter<GuestId, Guid> GuestIdConvertor = new(
            id => id.Value,
            value => GuestId.Create(value));

        public static readonly ValueConverter<BillId, Guid> BillIdConvertor = new(
            id => id.Value,
            value => BillId.Create(value));

        public static readonly ValueConverter<UserId, Guid> UserIdConvertor = new(
            id => id.Value,
            value => UserId.Create(value));

        public static readonly ValueConverter<DinnerId, Guid> DinnerIdConvertor = new(
            id => id.Value,
            value => DinnerId.Create(value));
    }
}
