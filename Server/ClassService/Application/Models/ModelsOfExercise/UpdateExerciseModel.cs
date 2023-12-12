﻿namespace Application.Models.ModelsOfExercise
{
    public class UpdateExerciseModel
    {
        public string IdExercise { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? FileName { get; set; }
        public string? LinkFile { get; set; }
        public DateTime? Deadline { get; set; }
    }
}
