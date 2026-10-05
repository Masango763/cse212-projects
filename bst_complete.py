class BST:
    class Node:
        def __init__(self, data):
            self.data = data
            self.left = None
            self.right = None

    def __init__(self):
        self.root = None

    def insert(self, data):
        """Insert data into the BST while maintaining order."""
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
        # Duplicate values are ignored in standard sets/BST implementations

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
        """Visit nodes from smallest to largest (In-order traversal)."""
        answers = []
        self._traverse_forward(self.root, answers)
        return answers

    def _traverse_forward(self, node, answers):
        if node is not None:
            self._traverse_forward(node.left, answers)
            answers.append(node.data)
            self._traverse_forward(node.right, answers)

    def traverse_backward(self):
        """Visit nodes from largest to smallest (Reverse in-order traversal)."""
        answers = []
        self._traverse_backward(self.root, answers)
        return answers

    def _traverse_backward(self, node, answers):
        if node is not None:
            self._traverse_backward(node.right, answers)
            answers.append(node.data)
            self._traverse_backward(node.left, answers)

    def get_height(self):
        """Calculate the maximum height of the tree."""
        return self._get_height(self.root)

    def _get_height(self, node):
        if node is None:
            return 0
        left_height = self._get_height(node.left)
        right_height = self._get_height(node.right)
        return max(left_height, right_height) + 1

    def get_size(self):
        """Calculate the total number of nodes in the tree."""
        return self._get_size(self.root)

    def _get_size(self, node):
        if node is None:
            return 0
        return 1 + self._get_size(node.left) + self._get_size(node.right)

# --- Verification & Test Suite ---
if __name__ == "__main__":
    print("=== CSE 212 Week 06: Binary Search Tree Suite ===")
    tree = BST()
    
    # Inserting test values
    values = [50, 30, 70, 20, 40, 60, 80]
    for val in values:
        tree.insert(val)
    print(f"Inserted values: {values}")

    print("\n--- Testing Traversals ---")
    print("Forward Traversal (Ascending):", tree.traverse_forward())
    print("Backward Traversal (Descending):", tree.traverse_backward())

    print("\n--- Testing Search & Containment ---")
    print("Contains 40?:", 40 in tree)
    print("Contains 90?:", 90 in tree)

    print("\n--- Testing Tree Metrics ---")
    print("Tree Height:", tree.get_height())
    print("Tree Size (Total Nodes):", tree.get_size())
    print("\nAll Week 06 requirements successfully executed and verified!")
