class Comment:
    def __init__(self, commenter_name, comment_text):
        self.commenter_name = commenter_name
        self.comment_text = comment_text

    def get_commenter_name(self):
        return self.commenter_name

    def get_comment_text(self):
        return self.comment_text