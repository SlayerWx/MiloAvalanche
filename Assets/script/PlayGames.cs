using UnityEngine;
using System;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using UnityEngine.SocialPlatforms;
public class PlayGames : MonoBehaviour
{
    public int playerScore;
    string leaderboardID = "";
    string achievementID = "CgkI5e37wqAKEAIQAQ";
    public static PlayGamesPlatform platform = null;
    public static PlayGames Instance = null;
    bool ChallengeComplet = false;
    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        if (platform == null)
        {
            PlayGamesClientConfiguration config = new PlayGamesClientConfiguration.Builder().Build();
            PlayGamesPlatform.InitializeInstance(config);
            PlayGamesPlatform.DebugLogEnabled = true;
            platform = PlayGamesPlatform.Activate();
			// Ejemplo de solicitud de permisos en tiempo de ejecución en Unity
        }

        Social.Active.localUser.Authenticate(success =>
        {
            if (success)
            {
                Debug.Log("Logged in successfully");
                GetArchievemnt();
            }
            else
            {
                Debug.Log("Login Failed");
            }
        });
		
	}

    public void AddScoreToLeaderboard()
    {
        if (Social.Active.localUser.authenticated)
        {
            Social.ReportScore(playerScore, leaderboardID, success => { });
        }
    }

    public void ShowLeaderboard()
    {
        if (Social.Active.localUser.authenticated)
        {
            platform.ShowLeaderboardUI();
        }
    }

    public void ShowAchievements()
    {
        if (Social.Active.localUser.authenticated)
        {
            platform.ShowAchievementsUI();
        }
    }

    public void UnlockAchievement()
    {
        if (Social.Active.localUser.authenticated)
        {
            Social.ReportProgress(achievementID, 100f, success => { });
        }
    }
    public void GetArchievemnt()
    {
        ChallengeComplet = false;
        Social.LoadAchievements(achievements => {
            if (achievements.Length > 0)
            {
                Debug.Log("Got " + achievements.Length + " achievement instances");
                foreach (IAchievement achievement in achievements)
                {
                    ChallengeComplet = achievement.completed;
                }
            }
            else
                Debug.Log("No achievements returned");
        });
    }
    public bool GetSuccessArchivment()
    {
        return ChallengeComplet;
    }

}