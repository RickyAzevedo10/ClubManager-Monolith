namespace ClubManager.Domain.Constants
{
    public class Constants
    {
        public readonly struct NotificationKeys
        {
            public static readonly string DATABASE_COMMIT_ERROR = "DATABASE_COMMIT_ERROR";
            public static readonly string CANT_CONSULT = "CANT_CONSULT";
            public static readonly string CANT_DELETE = "CANT_DELETE";
            public static readonly string CANT_EDIT = "CANT_EDIT";
            public static readonly string CANT_CREATE = "CANT_CREATE";

            public readonly struct InstitutionNotifications
            {
                public static readonly string INSTITUTION_NOT_FOUND = "INSTITUTION_NOT_FOUND";
                public static readonly string INSTITUTION_ALREADY_EXITS = "INSTITUTION_ALREADY_EXITS";
                public static readonly string ERROR_INSTITUTION_CREATED = "ERROR_INSTITUTION_CREATED";
                public static readonly string INSTITUTION_CREATED = "INSTITUTION_CREATED";
                public static readonly string INSTITUTION_UPDATED = "INSTITUTION_UPDATED";
                public static readonly string INSTITUTION_DELETED = "INSTITUTION_DELETED";
            }

            public readonly struct UserNotifications
            {
                public static readonly string USER_DONT_EXITS = "USER_DONT_EXITS";
                public static readonly string USER_ALREADY_EXITS = "USER_ALREADY_EXITS";
                public static readonly string ERROR_USER_CREATED = "ERROR_USER_CREATED";
                public static readonly string ERROR_USER_UPDATED = "ERROR_USER_UPDATED";
                public static readonly string ERROR_USER_PERMISSIONS_CREATED = "ERROR_USER_PERMISSIONS_CREATED";
                public static readonly string INVALID_USER_CREDENTIALS = "INVALID_USER_CREDENTIALS";
                public static readonly string INVALID_REFRESH_TOKEN = "INVALID_REFRESH_TOKEN";
                public static readonly string USER_CREATED = "USER_CREATED";
                public static readonly string USER_UPDATED = "USER_UPDATED";
                public static readonly string USER_DELETED = "USER_DELETED";
            }

            public readonly struct ClubMemberNotifications
            {
                public static readonly string CLUBMEMBER_DONT_EXITS = "CLUBMEMBER_DONT_EXITS";
                public static readonly string CLUBMEMBER_ALREADY_EXITS = "CLUBMEMBER_ALREADY_EXITS";
                public static readonly string ERROR_CLUBMEMBER_CREATED = "ERROR_CLUBMEMBER_CREATED";
                public static readonly string ERROR_CLUBMEMBER_PERMISSIONS_CREATED = "ERROR_CLUBMEMBER_PERMISSIONS_CREATED";
                public static readonly string INVALID_CLUBMEMBER_CREDENTIALS = "INVALID_CLUBMEMBER_CREDENTIALS";
                public static readonly string INVALID_REFRESH_TOKEN = "INVALID_REFRESH_TOKEN";
                public static readonly string CLUBMEMBER_CREATED = "CLUBMEMBER_CREATED";
                public static readonly string CLUBMEMBER_UPDATED = "CLUBMEMBER_UPDATED";
                public static readonly string CLUBMEMBER_DELETED = "CLUBMEMBER_DELETED";
            }

            public readonly struct MinorClubMemberNotifications
            {
                public static readonly string MINORCLUBMEMBER_DONT_EXIST = "MINORCLUBMEMBER_DONT_EXIST";
                public static readonly string MINORCLUBMEMBER_ALREADY_EXISTS = "MINORCLUBMEMBER_ALREADY_EXISTS";
                public static readonly string ERROR_MINORCLUBMEMBER_CREATED = "ERROR_MINORCLUBMEMBER_CREATED";
                public static readonly string ERROR_MINORCLUBMEMBER_PERMISSIONS_CREATED = "ERROR_MINORCLUBMEMBER_PERMISSIONS_CREATED";
                public static readonly string INVALID_MINORCLUBMEMBER_CREDENTIALS = "INVALID_MINORCLUBMEMBER_CREDENTIALS";
                public static readonly string INVALID_REFRESH_TOKEN = "INVALID_REFRESH_TOKEN";
                public static readonly string MINORCLUBMEMBER_CREATED = "MINORCLUBMEMBER_CREATED";
                public static readonly string MINORCLUBMEMBER_UPDATED = "MINORCLUBMEMBER_UPDATED";
                public static readonly string MINORCLUBMEMBER_DELETED = "MINORCLUBMEMBER_DELETED";
            }

            public readonly struct PlayerTransferNotifications
            {
                public static readonly string PLAYERTRANSFER_DONT_EXITS = "PLAYERTRANSFER_DONT_EXITS";
                public static readonly string PLAYERTRANSFER_ALREADY_EXITS = "PLAYERTRANSFER_ALREADY_EXITS";
                public static readonly string ERROR_PLAYERTRANSFER_CREATED = "ERROR_PLAYERTRANSFER_CREATED";
                public static readonly string ERROR_PLAYERTRANSFER_PERMISSIONS_CREATED = "ERROR_PLAYERTRANSFER_PERMISSIONS_CREATED";
                public static readonly string INVALID_PLAYERTRANSFER_CREDENTIALS = "INVALID_PLAYERTRANSFER_CREDENTIALS";
                public static readonly string INVALID_REFRESH_TOKEN = "INVALID_REFRESH_TOKEN";
                public static readonly string PLAYERTRANSFER_CREATED = "PLAYERTRANSFER_CREATED";
                public static readonly string PLAYERTRANSFER_UPDATED = "PLAYERTRANSFER_UPDATED";
                public static readonly string PLAYERTRANSFER_DELETED = "PLAYERTRANSFER_DELETED";
            }

            public readonly struct PlayerNotifications
            {
                public static readonly string PLAYER_DONT_EXITS = "PLAYER_DONT_EXITS";
                public static readonly string PLAYER_ALREADY_EXITS = "PLAYER_ALREADY_EXITS";
                public static readonly string ERROR_PLAYER_CREATED = "ERROR_PLAYER_CREATED";
                public static readonly string ERROR_PLAYER_UPDATED = "ERROR_PLAYER_UPDATED";
                public static readonly string ERROR_PLAYER_PERMISSIONS_CREATED = "ERROR_PLAYER_PERMISSIONS_CREATED";
                public static readonly string INVALID_PLAYER_CREDENTIALS = "INVALID_PLAYER_CREDENTIALS";
                public static readonly string INVALID_REFRESH_TOKEN = "INVALID_REFRESH_TOKEN";
                public static readonly string PLAYER_CREATED = "PLAYER_CREATED";
                public static readonly string PLAYER_UPDATED = "PLAYER_UPDATED";
                public static readonly string PLAYER_DELETED = "PLAYER_DELETED";
            }

            public readonly struct PlayerContractNotifications
            {
                public static readonly string PLAYERCONTRACT_DONT_EXITS = "PLAYERCONTRACT_DONT_EXITS";
                public static readonly string PLAYERCONTRACT_ALREADY_EXITS = "PLAYERCONTRACT_ALREADY_EXITS";
                public static readonly string ERROR_PLAYERCONTRACT_CREATED = "ERROR_PLAYERCONTRACT_CREATED";
                public static readonly string ERROR_PLAYERCONTRACT_PERMISSIONS_CREATED = "ERROR_PLAYERCONTRACT_PERMISSIONS_CREATED";
                public static readonly string INVALID_PLAYERCONTRACT_CREDENTIALS = "INVALID_PLAYERCONTRACT_CREDENTIALS";
                public static readonly string INVALID_REFRESH_TOKEN = "INVALID_REFRESH_TOKEN";
                public static readonly string PLAYERCONTRACT_CREATED = "PLAYERCONTRACT_CREATED";
                public static readonly string PLAYERCONTRACT_UPDATED = "PLAYERCONTRACT_UPDATED";
                public static readonly string PLAYERCONTRACT_DELETED = "PLAYERCONTRACT_DELETED";
                public static readonly string PLAYER_ALREADY_HAVE_ACTIVE_CONTRACT = "PLAYER_ALREADY_HAVE_ACTIVE_CONTRACT";
            }

            public readonly struct PlayerPerformanceHistoryNotifications
            {
                public static readonly string PLAYERPERFORMANCEHISTORY_DONT_EXITS = "PLAYERPERFORMANCEHISTORY_DONT_EXITS";
                public static readonly string PLAYERPERFORMANCEHISTORY_ALREADY_EXITS = "PLAYERPERFORMANCEHISTORY_ALREADY_EXITS";
                public static readonly string ERROR_PLAYERPERFORMANCEHISTORY_CREATED = "ERROR_PLAYERPERFORMANCEHISTORY_CREATED";
                public static readonly string ERROR_PLAYERPERFORMANCEHISTORY_PERMISSIONS_CREATED = "ERROR_PLAYERPERFORMANCEHISTORY_PERMISSIONS_CREATED";
                public static readonly string INVALID_PLAYERPERFORMANCEHISTORY_CREDENTIALS = "INVALID_PLAYERPERFORMANCEHISTORY_CREDENTIALS";
                public static readonly string INVALID_REFRESH_TOKEN = "INVALID_REFRESH_TOKEN";
                public static readonly string PLAYERPERFORMANCEHISTORY_CREATED = "PLAYERPERFORMANCEHISTORY_CREATED";
                public static readonly string PLAYERPERFORMANCEHISTORY_UPDATED = "PLAYERPERFORMANCEHISTORY_UPDATED";
                public static readonly string PLAYERPERFORMANCEHISTORY_DELETED = "PLAYERPERFORMANCEHISTORY_DELETED";
            }

            public readonly struct TeamNotifications
            {
                public static readonly string TEAM_DONT_EXITS = "TEAM_DONT_EXITS";
                public static readonly string TEAM_ALREADY_EXITS = "TEAM_ALREADY_EXITS";
                public static readonly string ERROR_TEAM_CREATED = "ERROR_TEAM_CREATED";
                public static readonly string ERROR_TEAM_UPDATED = "ERROR_TEAM_UPDATED";
                public static readonly string ERROR_TEAM_PERMISSIONS_CREATED = "ERROR_TEAM_PERMISSIONS_CREATED";
                public static readonly string INVALID_TEAM_CREDENTIALS = "INVALID_TEAM_CREDENTIALS";
                public static readonly string INVALID_REFRESH_TOKEN = "INVALID_REFRESH_TOKEN";
                public static readonly string TEAM_CREATED = "TEAM_CREATED";
                public static readonly string TEAM_UPDATED = "TEAM_UPDATED";
                public static readonly string TEAM_DELETED = "TEAM_DELETED";
            }
              
            public readonly struct FacilityNotifications
            {
                public static readonly string FACILITY_DOES_NOT_EXIST = "FACILITY_DOES_NOT_EXIST";
                public static readonly string FACILITY_ALREADY_EXISTS = "FACILITY_ALREADY_EXISTS";
                public static readonly string ERROR_FACILITY_CREATED = "ERROR_FACILITY_CREATED";
                public static readonly string ERROR_FACILITY_UPDATED = "ERROR_FACILITY_UPDATED";
                public static readonly string ERROR_FACILITY_PERMISSIONS_CREATED = "ERROR_FACILITY_PERMISSIONS_CREATED";
                public static readonly string INVALID_FACILITY_CREDENTIALS = "INVALID_FACILITY_CREDENTIALS";
                public static readonly string INVALID_REFRESH_TOKEN = "INVALID_REFRESH_TOKEN";
                public static readonly string FACILITY_CREATED = "FACILITY_CREATED";
                public static readonly string FACILITY_UPDATED = "FACILITY_UPDATED";
                public static readonly string FACILITY_DELETED = "FACILITY_DELETED";
            }

            public readonly struct FacilityReservationNotifications
            {
                public static readonly string FACILITY_RESERVATION_DOES_NOT_EXIST = "FACILITY_RESERVATION_DOES_NOT_EXIST";
                public static readonly string FACILITY_RESERVATION_ALREADY_EXISTS = "FACILITY_RESERVATION_ALREADY_EXISTS";
                public static readonly string ERROR_FACILITY_RESERVATION_CREATED = "ERROR_FACILITY_RESERVATION_CREATED";
                public static readonly string ERROR_FACILITY_RESERVATION_UPDATED = "ERROR_FACILITY_RESERVATION_UPDATED";
                public static readonly string ERROR_FACILITY_RESERVATION_PERMISSIONS_CREATED = "ERROR_FACILITY_RESERVATION_PERMISSIONS_CREATED";
                public static readonly string INVALID_FACILITY_RESERVATION_CREDENTIALS = "INVALID_FACILITY_RESERVATION_CREDENTIALS";
                public static readonly string INVALID_REFRESH_TOKEN = "INVALID_REFRESH_TOKEN";
                public static readonly string FACILITY_RESERVATION_CREATED = "FACILITY_RESERVATION_CREATED";
                public static readonly string FACILITY_RESERVATION_UPDATED = "FACILITY_RESERVATION_UPDATED";
                public static readonly string FACILITY_RESERVATION_DELETED = "FACILITY_RESERVATION_DELETED";
            }

            public readonly struct MaintenanceRequestNotifications
            {
                public static readonly string MAINTENANCE_REQUEST_DOES_NOT_EXIST = "MAINTENANCE_REQUEST_DOES_NOT_EXIST";
                public static readonly string MAINTENANCE_REQUEST_ALREADY_EXISTS = "MAINTENANCE_REQUEST_ALREADY_EXISTS";
                public static readonly string ERROR_MAINTENANCE_REQUEST_CREATED = "ERROR_MAINTENANCE_REQUEST_CREATED";
                public static readonly string ERROR_MAINTENANCE_REQUEST_UPDATED = "ERROR_MAINTENANCE_REQUEST_UPDATED";
                public static readonly string ERROR_MAINTENANCE_REQUEST_PERMISSIONS_CREATED = "ERROR_MAINTENANCE_REQUEST_PERMISSIONS_CREATED";
                public static readonly string INVALID_MAINTENANCE_REQUEST_CREDENTIALS = "INVALID_MAINTENANCE_REQUEST_CREDENTIALS";
                public static readonly string INVALID_REFRESH_TOKEN = "INVALID_REFRESH_TOKEN";
                public static readonly string MAINTENANCE_REQUEST_CREATED = "MAINTENANCE_REQUEST_CREATED";
                public static readonly string MAINTENANCE_REQUEST_UPDATED = "MAINTENANCE_REQUEST_UPDATED";
                public static readonly string MAINTENANCE_REQUEST_DELETED = "MAINTENANCE_REQUEST_DELETED";
            }

            public readonly struct MaintenanceHistoryNotifications
            {
                public static readonly string MAINTENANCE_HISTORY_DATETIME_INVALID = "MAINTENANCE_HISTORY_DATETIME_INVALID";
            }

            public readonly struct MatchNotifications
            {
                public static readonly string MATCH_DOES_NOT_EXIST = "MATCH_DOES_NOT_EXIST";
                public static readonly string MATCH_ALREADY_EXISTS = "MATCH_ALREADY_EXISTS";
                public static readonly string ERROR_MATCH_CREATED = "ERROR_MATCH_CREATED";
                public static readonly string ERROR_MATCH_UPDATED = "ERROR_MATCH_UPDATED";
                public static readonly string ERROR_MATCH_PERMISSIONS_CREATED = "ERROR_MATCH_PERMISSIONS_CREATED";
                public static readonly string INVALID_MATCH_CREDENTIALS = "INVALID_MATCH_CREDENTIALS";
                public static readonly string INVALID_REFRESH_TOKEN = "INVALID_REFRESH_TOKEN";
                public static readonly string MATCH_CREATED = "MATCH_CREATED";
                public static readonly string MATCH_UPDATED = "MATCH_UPDATED";
                public static readonly string MATCH_DELETED = "MATCH_DELETED";
            }
            public readonly struct MatchStatisticNotifications
            {
                public static readonly string MATCH_STATISTIC_DOES_NOT_EXIST = "MATCH_STATISTIC_DOES_NOT_EXIST";
                public static readonly string MATCH_STATISTIC_ALREADY_EXISTS = "MATCH_STATISTIC_ALREADY_EXISTS";
                public static readonly string ERROR_MATCH_STATISTIC_CREATED = "ERROR_MATCH_STATISTIC_CREATED";
                public static readonly string ERROR_MATCH_STATISTIC_UPDATED = "ERROR_MATCH_STATISTIC_UPDATED";
                public static readonly string ERROR_MATCH_STATISTIC_PERMISSIONS_CREATED = "ERROR_MATCH_STATISTIC_PERMISSIONS_CREATED";
                public static readonly string MATCH_STATISTIC_CREATED = "MATCH_STATISTIC_CREATED";
                public static readonly string MATCH_STATISTIC_UPDATED = "MATCH_STATISTIC_UPDATED";
                public static readonly string MATCH_STATISTIC_DELETED = "MATCH_STATISTIC_DELETED";
            }

            public readonly struct TrainingSessionNotifications
            {
                public static readonly string TRAINING_SESSION_DOES_NOT_EXIST = "TRAINING_SESSION_DOES_NOT_EXIST";
                public static readonly string TRAINING_SESSION_ALREADY_EXISTS = "TRAINING_SESSION_ALREADY_EXISTS";
                public static readonly string ERROR_TRAINING_SESSION_CREATED = "ERROR_TRAINING_SESSION_CREATED";
                public static readonly string ERROR_TRAINING_SESSION_UPDATED = "ERROR_TRAINING_SESSION_UPDATED";
                public static readonly string ERROR_TRAINING_SESSION_PERMISSIONS_CREATED = "ERROR_TRAINING_SESSION_PERMISSIONS_CREATED";
                public static readonly string TRAINING_SESSION_CREATED = "TRAINING_SESSION_CREATED";
                public static readonly string TRAINING_SESSION_UPDATED = "TRAINING_SESSION_UPDATED";
                public static readonly string TRAINING_SESSION_DELETED = "TRAINING_SESSION_DELETED";
            }

            public readonly struct TrainingAttendanceNotifications
            {
                public static readonly string TRAINING_ATTENDANCE_DOES_NOT_EXIST = "TRAINING_ATTENDANCE_DOES_NOT_EXIST";
                public static readonly string TRAINING_ATTENDANCE_ALREADY_EXISTS = "TRAINING_ATTENDANCE_ALREADY_EXISTS";
                public static readonly string ERROR_TRAINING_ATTENDANCE_CREATED = "ERROR_TRAINING_ATTENDANCE_CREATED";
                public static readonly string ERROR_TRAINING_ATTENDANCE_UPDATED = "ERROR_TRAINING_ATTENDANCE_UPDATED";
                public static readonly string ERROR_TRAINING_ATTENDANCE_PERMISSIONS_CREATED = "ERROR_TRAINING_ATTENDANCE_PERMISSIONS_CREATED";
                public static readonly string TRAINING_ATTENDANCE_CREATED = "TRAINING_ATTENDANCE_CREATED";
                public static readonly string TRAINING_ATTENDANCE_UPDATED = "TRAINING_ATTENDANCE_UPDATED";
                public static readonly string TRAINING_ATTENDANCE_DELETED = "TRAINING_ATTENDANCE_DELETED";
            }


        }
    }
}
