using Query.Mission.DTO;

namespace Query.Mission;
public static class MissionMapper
{
    public static MissionDto Map(this Domain.Mission.Mission mission)
    {
        return new MissionDto()
        {
            Id = mission.Id,
            CreationDate = mission.CreationDate,
            CurrentLocation = mission.CurrentLocation,
            Beginning = mission.Beginning,
            Destination = mission.Destination,
            DriverId = mission.DriverId,
            status = (DTO.StatusDto)mission.status,
        };
    }

    public static List<MissionDto> MapList(this List<Domain.Mission.Mission> missions)
    {
        return missions.Select(mission => mission.Map()).ToList();
    }
}