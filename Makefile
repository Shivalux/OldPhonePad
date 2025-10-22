NAME		= OldPhonePad.sh
SRC_PRJ		= OldPhonePad.csproj
TEST_PRJ	= OldPhonePad.Tests.csproj
SRCS		= ./OldPhonePad
TESTS		= ./OldPhonePad.Tests
ARGS		= $(wordlist 2, $(words $(MAKECMDGOALS)), $(MAKECMDGOALS))

$(NAME):
	@dotnet build $(SRCS)
	@dotnet build $(TESTS)
	@echo '#!/bin/bash' > $(NAME)
	@echo 'dotnet run --project ./OldPhonePad "$$@"' >> $(NAME)
	@chmod +x $(NAME)

%:
	@:

all: $(NAME)

run:
	@dotnet run --project $(SRCS)/$(SRC_PRJ) $(ARGS)

test:
	dotnet test $(TESTS)/$(TEST)

clean:
	@dotnet clean $(SRCS)
	@dotnet clean $(TESTS)
	@rm -rf $(NAME)

fclean: clean
	@rm -rf $(SRCS)/bin $(SRCS)/obj $(TESTS)/bin $(TESTS)/obj

re: fclean all

.PHONY: all clean fclean run test re