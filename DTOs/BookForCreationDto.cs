namespace WebApi.DTOs {
    public class BookForCreationDto : BookDtoBase, IIdentityDto {
        public int Id { get;set; }
    }
}