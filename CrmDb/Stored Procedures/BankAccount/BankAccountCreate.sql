create procedure [dbo].[BankAccountCreate]
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
	@Comments nvarchar(max)
as
begin
	set nocount on;

	declare @Id TIdentifier, @UserId int;

	set @UserId = [dbo].[GetCurrentUserId]();

	insert into [dbo].[BankAccount]
		([State], [FileAs], [AccountId], [CashAccount], [Bank], [Address], [Account], [SWIFT], [ABA], [BIC],
		[IBAN], [IntermediaryBank], [IntermediaryAddress], [IntermediaryAccount], [IntermediarySWIFT],
		[IntermediaryABA], [Comments], [Created], [CreatedBy], [Modified], [ModifiedBy])
	values
		(1, @FileAs, @AccountId, @CashAccount, @Bank, @Address, @Account, @SWIFT, @ABA, @BIC, @IBAN,
		@IntermediaryBank, @IntermediaryAddress, @IntermediaryAccount, @IntermediarySWIFT, @IntermediaryABA,
		@Comments, getdate(), @UserId, getdate(), @UserId);

	set @Id = scope_identity();

	exec [dbo].[BankAccountGet] @Id;

	return 0;
end
