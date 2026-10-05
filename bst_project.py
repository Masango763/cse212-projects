class BST:
    class Node:
        def __init__(self, data):
            self.data = data
            self.left = None
            self.right = None

    def __init__(self):
        self.root = None

    def insert(self, data):
        """Insert data into the BST."""
        if self.root is None:
            self.root = self.Node(data)
        else:
            self._insert(data, self.root)

    def _insert(self, data, node):
        if data < node.data:
            if node.left is None:
                node.left = self.Node(data)
            else:
                self._insert(data, node.left)
        elif data > node.data:
            if node.right is None:
                node.right = self.Node(data)
            else:
                self._insert(data, node.right)

    def __contains__(self, data):
        """Check if data exists in the BST."""
        return self._contains(data, self.root)

    def _contains(self, data, node):
        if node is None:
            return False
        if data == node.data:
            return True
        if data < node.data:
            return self._contains(data, node.left)
        return self._contains(data, node.right)

    def traverse_forward(self):
        """Yield values in ascending order (In-order traversal)."""
        answers = []
        self._traverse_forward(self.root, answers)
        return answers

    def _traverse_forward(self, node, answers):
        if node is not None:
            self._traverse_forward(node.left, answers)
            answers.append(node.data)
            self._traverse_forward(node.right, answers)

if __name__ == "__main__":
    print("Initializing Week 06 BST Project on Desktop...")
    tree = BST()
    for val in [50, 30, 70, 20, 40, 60, 80]:
        tree.insert(val)

    print("Forward Traversal (Sorted):", tree.traverse_forward())
    print("Contains 40?:", 40 in tree)
    print("Contains 90?:", 90 in tree)
    print("Week 06 Project structure ready and verified on Desktop!")
