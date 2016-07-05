// Aho-Corasick-CPP.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"

using namespace std;

const int ALPHABET_SIZE = 26;
string p[124];

struct listNode
{
	int patternIndex;
	listNode* next;
	listNode(int index, listNode* nextNode)
	{
		patternIndex = index;
		next = nextNode;
	}
};

struct trie
{
	trie* failLink;
	trie* parent;
	trie* alphabet[ALPHABET_SIZE];
	int index = -1; // If it is != -1 it is pattern, otherwise not
	listNode* patterns;
	static trie* constructTrie(trie&, string[], int);
	static trie* newNode();
	static trie* constructAutomata(trie&);
	void searchPatterns(string, vector< vector<int> >&);
};

int parseToIndex(char c)
{
	return ((int)c - (int)'a');
}

void trie::searchPatterns(string text, vector< vector<int> >& results)
{
	trie* node = this;
	trie* root = this;
	int charIndex;
	for (int i = 0; i < (int)text.size(); ++i)
	{
		charIndex = parseToIndex(text[i]);
		while (!node->alphabet[charIndex] && node != root)
		{
			node = node->failLink;
		}

		if (node->alphabet[charIndex])
		{
			node = node->alphabet[charIndex];
		}

		for (listNode* n = node->patterns; n; n = n->next)
		{
			results[n->patternIndex].push_back(i);
		}
	}
}

trie* trie::newNode()
{
	trie *t = new trie;
	t->failLink = NULL;
	t->parent = NULL;
	t->index = -1;
	t->patterns = NULL;
	for (int i = 0; i < 26; ++i)
	{
		t->alphabet[i] = NULL;
	}
	return t;
}

trie* trie::constructTrie(trie& root, string patterns[], int numberOfPatterns)
{
	root = (*trie::newNode());
	int patternSize, alphaIndex;
	trie* currNode;
	for (int patternIndex = 0; patternIndex < numberOfPatterns; ++patternIndex)
	{
		currNode = &root;
		patternSize = patterns[patternIndex].size();
		for (int charIndex = 0; charIndex < patternSize; ++charIndex)
		{
			alphaIndex = parseToIndex(patterns[patternIndex][charIndex]);
			if (!currNode->alphabet[alphaIndex])
			{
				currNode->alphabet[alphaIndex] = trie::newNode();
			}
			currNode = currNode->alphabet[alphaIndex];
		}
		currNode->index = patternIndex;
	}
	return &root;
}

trie* trie::constructAutomata(trie& root)
{
	queue<trie*> bfsQueue;
	trie* currNode;
	trie* alphaNode;
	trie* failNode;

	//int index = 1;

	for (int i = 0; i < ALPHABET_SIZE; ++i)
	{
		if (root.alphabet[i])
		{
			root.alphabet[i]->failLink = &root;
			bfsQueue.push(root.alphabet[i]);
		}
	}
	
	while (!bfsQueue.empty())
	{
		currNode = bfsQueue.front();
		//currNode->index = index++;
		bfsQueue.pop();
		for (int i = 0; i < ALPHABET_SIZE; ++i)
		{
			alphaNode = currNode->alphabet[i];
			if (alphaNode != NULL)
			{
				bfsQueue.push(alphaNode);
				failNode = currNode->failLink;
				while (!failNode->alphabet[i] && failNode != &root)
				{
					failNode = failNode->failLink;
				}
				alphaNode->failLink = failNode->alphabet[i] ? failNode->alphabet[i] : failNode;
				alphaNode->patterns = alphaNode->index != -1 ? new listNode(alphaNode->index, alphaNode->failLink->patterns) : alphaNode->failLink->patterns;
			}
		}
	}
	return &root;
}

int _tmain(int argc, _TCHAR* argv[])
{
	ios::sync_with_stdio(false);
	trie t;
	/*string p[4];
	p[0] = "he";
	p[1] = "she";
	p[2] = "his";
	p[3] = "hers";*/
	int n;
	cin >> n;
	for (int i = 0; i < n; ++i)
	{
		getline(cin, p[i]);
	}
	trie::constructTrie(t, p, n);
	trie::constructAutomata(t);
	string text;
	getline(cin, text);
	vector < vector < int > > results(101);
	t.searchPatterns(text, results);
	for (int i = 0; i < n; ++i)
	{
		if (!results[i].empty())
		{
			for (int j = 0; j < results[i].size; ++j)
			{
				/*text.replace(results[i][j] - p[i].length() + 1, p[i].length, )*/
				for (int k = results[i][j] - p[i].length() + 1; k <= results[i][j]; ++k)
				{
					text[k] = '@';
				}
			}
		}
	}
	return 0;
}