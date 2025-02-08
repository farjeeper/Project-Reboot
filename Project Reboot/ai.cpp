#include "ai.h"

FVector* __fastcall AI::GetRandomLocationSafeToReach(UObject* AIBotController, FVector* outVec, __int64* a3)
{
	// std::cout << "aa!\\n";
	// FVector aa = FVector{ 1250, 1818, 3284 };
	// return &aa;

	auto PlayerController = Helper::GetLocalPlayerController();
	if (!PlayerController)
	{
		std::cerr << "Failed to get local player controller.\\n";
		return nullptr;
	}

	auto PlayerPawn = Helper::GetPawnFromController(PlayerController);
	if (!PlayerPawn)
	{
		std::cerr << "Failed to get local player pawn.\\n";
		return nullptr;
	}

	auto PlayerLocation = Helper::GetActorLocation(PlayerPawn);
	std::cout << "Player location: " << PlayerLocation.Describe() << '\\n';

	*outVec = PlayerLocation;
	return outVec;
}