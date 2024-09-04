namespace ClubManager.Domain.DTOs.MembersTeams
{
    public class CreateClubMemberDTO
    {
        public string FirstName { get; set; }  
        public string LastName { get; set; }     
        public bool Partner { get; set; } // se é socio ou nao
        public bool EducationOfficer { get; set; }  //se é encarregado de educacao de algum jogador
        public DateTime DateOfJoining { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Email { get; set; }        
        public string PhoneNumber { get; set; } 
        public string Address { get; set; }     
        public bool IsUser {  get; set; }
        public int UserId { get; set; }
    }
}
