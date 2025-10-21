NAME	= OldPhonePad.csproj
TEST	= OldPhonePad.Tests.csproj
SRCS	= ./OldPhonePad
TESTS	= ./OldPhonePad.Tests
ARGS	= $(wordlist 2, $(words $(MAKECMDGOALS)), $(MAKECMDGOALS))

$(NAME):
	dotnet build $(SRCS)
	dotnet build $(TESTS)

%:
	@:

all: $(NAME)

run:
	@dotnet run --project $(SRCS)/$(NAME) $(ARGS)
	
test:
	dotnet test $(TESTS)/$(TEST)

clean:
	dotnet clean $(SRCS)
	dotnet clean $(TESTS)

fclean: clean
	@rm -rf $(SRCS)/bin $(SRCS)/obj $(TESTS)/bin $(TESTS)/obj

re: fclean all

.PHONY: all build clean fclean run test