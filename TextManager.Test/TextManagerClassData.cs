namespace TextManager.Test;
using System.Collections;

public class TextManagerClassData:IEnumerable<Object[]>
{
    public IEnumerator<object[]> GetEnumerator(){
        yield return new Object[] {"",0};
        yield return new Object[] {"Hola mundo",2};
        yield return new Object[] {"Saludos a todos desde el curso de xunit",8};
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}