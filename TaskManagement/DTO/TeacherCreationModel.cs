using System.ComponentModel.DataAnnotations;

namespace TaskManagement.DTO
{
    public class TeacherCreationModel
    {
        [Required(ErrorMessage = "Le champ 'Prénom' est obligatoire.")]
        public string? FirstName { get; set; }

        [Required(ErrorMessage = "Le champ 'Nom de famille' est obligatoire.")]
        public string? LastName { get; set; }

        [Required(ErrorMessage = "Le champ 'Matière enseignée' est obligatoire.")]
        public string? TeachedSubject { get; set; }

        public DateTime YearOfBirth { get; set; }
        public string? PlaceOfBirth { get; set; }
    }
}
