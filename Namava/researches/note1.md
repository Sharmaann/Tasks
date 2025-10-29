<div dir=rtl>
	
# تحقیق ها

## 1. تفاوت Stack و Heap

**تفاوت‌ها:**


- Memory capacity
- Memory speed


چرا Reference Type ها آدرس را توی Stack می‌ذارن ولی Value را توی Heap؟ 

---


 ## 2. تفاوت value type و reference type چیست؟

 لیست همه Value Type ها و Reference Type ها در #C
</div>

---
# پاسخ ها:

# Memory Segments

## 1. Stack Segment
- **Stores:**
  1. Local variables
  2. Function parameters
  3. Return addresses
- **Fixed size during runtime**
  <div dir=rtl>
	  
  اندازه stack از همان ابتدا اجرای برنامه مشخص است
	  .
  </div>
  
- **Memory management:**

  <div dir=rtl>
	  
  مدیریت حافظه stack به‌صورت خودکار توسط OS kernel انجام میشود (اختصاص و آزادسازی حافظه handled می‌شود)

  </div>
  
- **Speed:**

  <div dir=rtl>


  سریع‌تر از heap است چون خانه‌های حافظه پشت سر هم هستند و تنها کاری که لازم است انجام شود، اختصاص reference است
  </div>

  
- **Lifetime:**

  <div dir=rtl>


  دیتا فقط زمانی قابل دسترسی است که function مربوطه هنوز در call stack باشد (unfinished)
  
  </div>

## 2. Heap Segment
- **Flexible memory size during runtime**
- **Dynamically allocated memory**

    <div dir=rtl>

مناسب برای ذخیره داده‌هایی که اندازه‌شان از ابتدا مشخص نیست و نیاز به تغییر اندازه دارند
    </div>
  
- **Memory management:**

  <div dir=rtl>

  بسته به زبان برنامه‌نویسی، حافظه ممکن است توسط developer آزاد شود یا runtime با Garbage Collector این کار را انجام دهد. در زبان‌های بدون GC، آزاد نکردن حافظه باعث Memory Leak می‌شود

  </div> 
  
- **Speed:**
	  <div dir=rtl>


  کندتر از stack است، زیرا پیدا کردن memory frame و allocation/deallocation زمان‌بر است
    </div> 

- **Lifetime:**

    <div dir=rtl>

  دیتا تا زمانی که حافظه deallocate نشده و برنامه تمام نشده، قابل دسترس است

    </div> 

## 3. Code Segment (Text Segment)
<div dir=rtl>


حاوی machine code مربوط به توابع و متدهای برنامه
وقتی یک method فراخوانی می‌شود، CPU از بخش مربوط به آن در code segment استفاده می‌کند
</div>

## 4. Data Segment (Global Segment)
- **Stores:**
  1. Global variables
  2. Static variables

---

# Stack Frame
<div dir=rtl>


هر بار که یک function call رخ دهد، یک بلاک از حافظه برای ذخیره اطلاعات آن function اختصاص می‌یابد. این اطلاعات شامل:
</div>

  1. Function parameters
  2. Local variables
  3. Return address

---

# Call Stack
- استکی که همه توابع unfinished را لیست می‌کند و هر وقت کار بالاترین function در stack تمام شد، آن را پاک می‌کند.
- در اصل stack ای از stack frame های function های unfinished است.
- هر thread یک call stack جداگانه دارد.

---

# چه زمانی دیتا را در Heap ذخیره کنیم
- اندازه دیتا **متغیر باشد** (dynamic)
- مدت زمان استفاده از آن دیتا **مشخص نباشد** (unpredictable lifespan)
- نیاز داریم دیتا بین بخش‌های مختلف کد share شود و مختص function scope نباشد

**جمع‌بندی:**

| Segment | ویژگی |
|---------|-------|
| Stack   | Fast, short-lived data |
| Heap    | Flexible, long-lived data |

---

# مثال در ++C

```cpp
int main(){
    int val = 12;
    int* ptr = new int;

    *ptr = val;

    return 0;
}
```

توضیح مثال:

1. ابتدا نام تابع main در call stack اضافه می‌شود و stack frame مربوط به main ساخته می‌شود.
2. متغیر محلی val در stack segment ذخیره می‌شود.
3. دستور new int قسمتی از heap segment را اختصاص می‌دهد. آدرس آن قسمت از حافظه در متغیر محلی ptr (که داخل stack است) ریخته می‌شود. خود ptr صرفاً یک آدرس است و خودش در stack segment ذخیره می‌شود.

---

# Value Types

- وقتی یک متغیر value type را برابر متغیر دیگری قرار می‌دهیم، صرفاً **value ها کپی می‌شوند** و تغییر در یکی تاثیری بر دیگری ندارد.
- معمولاً در **stack** ذخیره می‌شوند مگر اینکه بخشی از یک reference object باشند → در این صورت در **heap**.
- Each variable has its own copy of data.
- Contains an instance of the type.
- `struct` یک **value type** است.
- Value types معمولاً نمی‌توانند `null` باشند → برای این منظور از **nullable value type** استفاده می‌کنیم:

```csharp
public struct Nullable<T> where T : struct
{
    private bool hasValue; // tracks if it actually has a value
    private T value;       // holds the actual value if there is one

    public bool HasValue => hasValue;
    public T Value => value; // throws exception if HasValue is false
}
```

مثال:

```csharp
Nullable<int> x = null;
// or
int? x = null;
```

---

# Reference Types

- برای reference type دو دیتا ذخیره می‌شود:
  1. داده در **heap segment**
  2. reference در **stack segment**
- Reference type مقدار اصلی را ذخیره نمی‌کند، بلکه **pointer** به داده در heap دارد.
- Contains a reference to an instance of the type.

## انواع Reference Types

### 1. Object
- هر نوع دیتا قابل ذخیره‌سازی است.
- همه type ها در #C از object مشتق شده‌اند.
- تبدیل value type به object میشود boxing و برعکسش unboxing:

```csharp
int x = 5;
object a = x; // boxing
int y = (int)a; // unboxing
```

### 2. Delegate
- متغیری که function یا method را ذخیره می‌کند، باید type delegate داشته باشد و **signature** مشابه method باشد.
- مشابه **function pointer** در C/C++ است، اما **type safe**.
- کاربردها:
  1. Functional programming
  2. Event-driven architecture & callbacks

### 3. Dynamic
 مشابه object است اما **runtime type checking** دارد
 
 نسبت به object دارای performance کمتری است
 
 استفاده ازش یعنی:

  Treat variable’s type as unknown until runtime.

```csharp
object obj = "Hello";
Console.WriteLine(obj.Length); // ❌ Compile-time error

dynamic dyn = "Hello";
Console.WriteLine(dyn.Length); // ✅ Works fine
```

- بررسی وجود method ها روی dynamic در runtime انجام می‌شود:

```csharp
dynamic d = "Arman";
Console.WriteLine(d.ToUpper());       // ✅ Works fine
Console.WriteLine(d.NoSuchMethod());  // ❌ Runtime error
```

- همچنین **class** و **array** از reference type ها هستند.

---

[منبع](https://www.educative.io/blog/stack-vs-heap#Heap-memory-the-dynamic-storage)



