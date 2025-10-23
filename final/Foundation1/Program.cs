class Comment:
    def __init__(self, commenter_name, comment_text):
        self.commenter_name = commenter_name
        self.comment_text = comment_text

    def get_commenter_name(self):
        return self.commenter_name

    def get_comment_text(self):
        return self.comment_text

class Video:
    def __init__(self, title, author, length_in_seconds):
        self.title = title
        self.author = author
        self.length_in_seconds = length_in_seconds
        self.comments = []

    def add_comment(self, comment):
        """Add a Comment object to the video"""
        self.comments.append(comment)

    def get_number_of_comments(self):
        """Return how many comments are on this video"""
        return len(self.comments)

    def display_video_info(self):
        """Display basic video details"""
        print(f"Title: {self.title}")
        print(f"Author: {self.author}")
        print(f"Length: {self.length_in_seconds} seconds")
        print(f"Number of Comments: {self.get_number_of_comments()}")
        print("Comments:")

        for comment in self.comments:
            print(f"- {comment.get_commenter_name()}: {comment.get_comment_text()}")
        print("-" * 40)