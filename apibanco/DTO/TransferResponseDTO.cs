namespace apibanco.DTO
{
    public class TransferResponseDto
    {
        public TransferResponseDto(string message, int status)
        {
            Message = message;
            Status = status;
        }

        public string Message { get; set; }
        public int Status { get; set; }
    }
}
