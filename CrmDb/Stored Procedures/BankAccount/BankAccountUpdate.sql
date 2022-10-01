create procedure [dbo].[BankAccountUpdate]
	@Id TIdentifier,
	@FileAs TName,
	@AccountId TIdentifier,
	@CashAccount bit,
	@Bank TName,
	@Address nvarchar(256),
	@Account TCode,
	@SWIFT TCode,
	@ABA TCode,
	@BIC TCode,
	@IBAN TCode,
	@IntermediaryBank TName,
	@IntermediaryAddress nvarchar(256),
	@IntermediaryAccount TCode,
	@IntermediarySWIFT TCode,
	@IntermediaryABA TCode,
	@Comments nvarchar(max),
	@RowVersion timestamp
as
begin
	set nocount on;

	declare @UserId int;

	set @UserId = [dbo].[GetCurrentUserId]();

	update [dbo].[BankAccount]
	set
		[FileAs] = @FileAs,
		[AccountId] = @AccountId,
		[CashAccount] = @CashAccount,
		[Bank] = @Bank,
		[Address] = @Address,
		[Account] = @Account,
		[SWIFT] = @SWIFT,
		[ABA] = @ABA,
		[BIC] = @BIC,
		[IBAN] = @IBAN,
		[IntermediaryBank] = @IntermediaryBank,
		[IntermediaryAddress] = @IntermediaryAddress,
		[IntermediaryAccount] = @IntermediaryAccount,
		[IntermediarySWIFT] = @IntermediarySWIFT,
		[IntermediaryABA] = @IntermediaryABA,
		[Comments] = @Comments,
		[Modified] = getdate(),
		[ModifiedBy] = @UserId
	where
		[Id] = @Id;

	exec [dbo].[BankAccountGet] @Id;

	return 0;
end
