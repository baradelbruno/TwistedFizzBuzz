namespace TwistedFizzBuzzLibrary.Interface;

public interface ITwistedFizzBuzz
{
	List<string> Execute(int start, int end);
	List<string> Execute(List<int> input);
	void UpdateTokenMap(Dictionary<string, int> tokenMap);
	IReadOnlyDictionary<string, int> GetTokenMap();
	Task UpdateTokenMapWithAPIGeneratedData();
}
