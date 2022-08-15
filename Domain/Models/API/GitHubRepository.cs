using System.Text.Json.Serialization;

namespace Domain.Models.API;

public record GitHubRepository
{
    [JsonPropertyName("id")] public long Id { get; set; }

    [JsonPropertyName("node_id")] public string NodeId { get; set; }

    [JsonPropertyName("name")] public string Name { get; set; }

    [JsonPropertyName("full_name")] public string FullName { get; set; }

    [JsonPropertyName("owner")] public Owner Owner { get; set; }

    [JsonPropertyName("private")] public bool Private { get; set; }

    [JsonPropertyName("html_url")] public Uri HtmlUrl { get; set; }

    [JsonPropertyName("description")] public string Description { get; set; }

    [JsonPropertyName("fork")] public bool Fork { get; set; }

    [JsonPropertyName("url")] public Uri Url { get; set; }

    [JsonPropertyName("archive_url")] public string ArchiveUrl { get; set; }

    [JsonPropertyName("assignees_url")] public string AssigneesUrl { get; set; }

    [JsonPropertyName("blobs_url")] public string BlobsUrl { get; set; }

    [JsonPropertyName("branches_url")] public string BranchesUrl { get; set; }

    [JsonPropertyName("collaborators_url")] public string CollaboratorsUrl { get; set; }

    [JsonPropertyName("comments_url")] public string CommentsUrl { get; set; }

    [JsonPropertyName("commits_url")] public string CommitsUrl { get; set; }

    [JsonPropertyName("compare_url")] public string CompareUrl { get; set; }

    [JsonPropertyName("contents_url")] public string ContentsUrl { get; set; }

    [JsonPropertyName("contributors_url")] public Uri ContributorsUrl { get; set; }

    [JsonPropertyName("deployments_url")] public Uri DeploymentsUrl { get; set; }

    [JsonPropertyName("downloads_url")] public Uri DownloadsUrl { get; set; }

    [JsonPropertyName("events_url")] public Uri EventsUrl { get; set; }

    [JsonPropertyName("forks_url")] public Uri ForksUrl { get; set; }

    [JsonPropertyName("git_commits_url")] public string GitCommitsUrl { get; set; }

    [JsonPropertyName("git_refs_url")] public string GitRefsUrl { get; set; }

    [JsonPropertyName("git_tags_url")] public string GitTagsUrl { get; set; }

    [JsonPropertyName("git_url")] public string GitUrl { get; set; }

    [JsonPropertyName("issue_comment_url")] public string IssueCommentUrl { get; set; }

    [JsonPropertyName("issue_events_url")] public string IssueEventsUrl { get; set; }

    [JsonPropertyName("issues_url")] public string IssuesUrl { get; set; }

    [JsonPropertyName("keys_url")] public string KeysUrl { get; set; }

    [JsonPropertyName("labels_url")] public string LabelsUrl { get; set; }

    [JsonPropertyName("languages_url")] public Uri LanguagesUrl { get; set; }

    [JsonPropertyName("merges_url")] public Uri MergesUrl { get; set; }

    [JsonPropertyName("milestones_url")] public string MilestonesUrl { get; set; }

    [JsonPropertyName("notifications_url")] public string NotificationsUrl { get; set; }

    [JsonPropertyName("pulls_url")] public string PullsUrl { get; set; }

    [JsonPropertyName("releases_url")] public string ReleasesUrl { get; set; }

    [JsonPropertyName("ssh_url")] public string SshUrl { get; set; }

    [JsonPropertyName("stargazers_url")] public Uri StargazersUrl { get; set; }

    [JsonPropertyName("statuses_url")] public string StatusesUrl { get; set; }

    [JsonPropertyName("subscribers_url")] public Uri SubscribersUrl { get; set; }

    [JsonPropertyName("subscription_url")] public Uri SubscriptionUrl { get; set; }

    [JsonPropertyName("tags_url")] public Uri TagsUrl { get; set; }

    [JsonPropertyName("teams_url")] public Uri TeamsUrl { get; set; }

    [JsonPropertyName("trees_url")] public string TreesUrl { get; set; }

    [JsonPropertyName("clone_url")] public Uri CloneUrl { get; set; }

    [JsonPropertyName("mirror_url")] public string MirrorUrl { get; set; }

    [JsonPropertyName("hooks_url")] public Uri HooksUrl { get; set; }

    [JsonPropertyName("svn_url")] public Uri SvnUrl { get; set; }

    [JsonPropertyName("homepage")] public Uri Homepage { get; set; }

    [JsonPropertyName("organization")] public object Organization { get; set; }

    [JsonPropertyName("language")] public object Language { get; set; }

    [JsonPropertyName("forks")] public long Forks { get; set; }

    [JsonPropertyName("forks_count")] public long ForksCount { get; set; }

    [JsonPropertyName("stargazers_count")] public long StargazersCount { get; set; }

    [JsonPropertyName("watchers_count")] public long WatchersCount { get; set; }

    [JsonPropertyName("watchers")] public long Watchers { get; set; }

    [JsonPropertyName("size")] public long Size { get; set; }

    [JsonPropertyName("default_branch")] public string DefaultBranch { get; set; }

    [JsonPropertyName("open_issues")] public long OpenIssues { get; set; }

    [JsonPropertyName("open_issues_count")] public long OpenIssuesCount { get; set; }

    [JsonPropertyName("is_template")] public bool IsTemplate { get; set; }

    [JsonPropertyName("license")] public License License { get; set; }

    [JsonPropertyName("topics")] public List<string> Topics { get; set; }

    [JsonPropertyName("has_issues")] public bool HasIssues { get; set; }

    [JsonPropertyName("has_projects")] public bool HasProjects { get; set; }

    [JsonPropertyName("has_wiki")] public bool HasWiki { get; set; }

    [JsonPropertyName("has_pages")] public bool HasPages { get; set; }

    [JsonPropertyName("has_downloads")] public bool HasDownloads { get; set; }

    [JsonPropertyName("archived")] public bool Archived { get; set; }

    [JsonPropertyName("disabled")] public bool Disabled { get; set; }

    [JsonPropertyName("visibility")] public string Visibility { get; set; }

    [JsonPropertyName("pushed_at")] public DateTimeOffset PushedAt { get; set; }

    [JsonPropertyName("created_at")] public DateTimeOffset CreatedAt { get; set; }

    [JsonPropertyName("updated_at")] public DateTimeOffset UpdatedAt { get; set; }

    [JsonPropertyName("permissions")] public Permissions Permissions { get; set; }

    [JsonPropertyName("allow_rebase_merge")] public bool AllowRebaseMerge { get; set; }

    [JsonPropertyName("template_repository")] public object TemplateRepository { get; set; }

    [JsonPropertyName("temp_clone_token")] public string TempCloneToken { get; set; }

    [JsonPropertyName("allow_squash_merge")] public bool AllowSquashMerge { get; set; }

    [JsonPropertyName("allow_auto_merge")] public bool AllowAutoMerge { get; set; }

    [JsonPropertyName("delete_branch_on_merge")]
    public bool DeleteBranchOnMerge { get; set; }

    [JsonPropertyName("allow_merge_commit")] public bool AllowMergeCommit { get; set; }

    [JsonPropertyName("subscribers_count")] public long SubscribersCount { get; set; }

    [JsonPropertyName("network_count")] public long NetworkCount { get; set; }
}

public partial class License
{
    [JsonPropertyName("key")] public string Key { get; set; }

    [JsonPropertyName("name")] public string Name { get; set; }

    [JsonPropertyName("url")] public Uri Url { get; set; }

    [JsonPropertyName("spdx_id")] public string SpdxId { get; set; }

    [JsonPropertyName("node_id")] public string NodeId { get; set; }

    [JsonPropertyName("html_url")] public Uri HtmlUrl { get; set; }
}

public class Owner
{
    [JsonPropertyName("login")] public string Login { get; set; }

    [JsonPropertyName("id")] public long Id { get; set; }

    [JsonPropertyName("node_id")] public string NodeId { get; set; }

    [JsonPropertyName("avatar_url")] public Uri AvatarUrl { get; set; }

    [JsonPropertyName("gravatar_id")] public string GravatarId { get; set; }

    [JsonPropertyName("url")] public Uri Url { get; set; }

    [JsonPropertyName("html_url")] public Uri HtmlUrl { get; set; }

    [JsonPropertyName("followers_url")] public Uri FollowersUrl { get; set; }

    [JsonPropertyName("following_url")] public string FollowingUrl { get; set; }

    [JsonPropertyName("gists_url")] public string GistsUrl { get; set; }

    [JsonPropertyName("starred_url")] public string StarredUrl { get; set; }

    [JsonPropertyName("subscriptions_url")] public Uri SubscriptionsUrl { get; set; }

    [JsonPropertyName("organizations_url")] public Uri OrganizationsUrl { get; set; }

    [JsonPropertyName("repos_url")] public Uri ReposUrl { get; set; }

    [JsonPropertyName("events_url")] public string EventsUrl { get; set; }

    [JsonPropertyName("received_events_url")] public Uri ReceivedEventsUrl { get; set; }

    [JsonPropertyName("type")] public string Type { get; set; }

    [JsonPropertyName("site_admin")] public bool SiteAdmin { get; set; }
}

public class Permissions
{
    [JsonPropertyName("admin")] public bool Admin { get; set; }

    [JsonPropertyName("push")] public bool Push { get; set; }

    [JsonPropertyName("pull")] public bool Pull { get; set; }
}
