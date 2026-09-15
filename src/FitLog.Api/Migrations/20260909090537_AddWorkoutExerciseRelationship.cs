using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FitLog.Api.Migrations
{
    /// <inheritdoc />
    public partial class AddWorkoutExerciseRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RepetititonCount",
                table: "WorkoutExercises",
                newName: "RepetitionCount");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RepetitionCount",
                table: "WorkoutExercises",
                newName: "RepetititonCount");
        }
    }
}
