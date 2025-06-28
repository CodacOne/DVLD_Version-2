# 🚗 DVLD - Driving Licenses Management System
# 🚦 نظام إدارة رخص القيادة الذكي DVLD  
## الحل البرمجي الشامل لإدارة عمليات الترخيص والفحوصات في إدارات المرور 🚗💡

مشروع تدريبي متكامل تم تطويره ضمن الكورس 19 (Full Real Project) من خارطة الدكتور أبو هدهود.  
يحاكي النظام واقع إدارات المرور في إدارة عمليات ترخيص السائقين والمركبات، مع التركيز على الجوانب البرمجية، تحليل النظم، وقواعد البيانات.

---

## 🧰 التقنيات المستخدمة

- **C# - Windows Forms (WinForms)**
- **SQL Server**
- **ADO.NET**
- **3-Tier Architecture (Presentation - Business Logic - Data Access)**
- **OOP: Events, Delegates, Composition**

---

## 🧾 وصف النظام

نظام DVLD يقدم مجموعة واسعة من الخدمات المتعلقة برخص القيادة، ويعتمد على قاعدة بيانات مركزية لتنظيم معلومات السائقين، الطلبات، الفحوصات، والرخص.  
تم تصميم النظام ليحاكي الواقع العملي داخل إدارات المرور مع إمكانية التوسعة المستقبلية.

---

## 🧩 المزايا الرئيسية

### 📄 الطلبات المدعومة

| الخدمة                | رسوم الطلب |
|-----------------------|------------|
| إصدار رخصة لأول مرة  | 5$         |
| إعادة فحص             | 5$         |
| تجديد الرخصة          | 5$         |
| إصدار بدل فاقد        | 5$         |
| إصدار بدل تالف        | 5$         |
| فك حجز رخصة           | 5$         |
| إصدار رخصة دولية      | 5$         |

> **ملاحظات:**
> - رسوم الفحوصات والرخص تُضاف إلى رسوم الطلب.
> - يُمنع تكرار نفس نوع الطلب إذا لم يُستكمل سابقاً.

---

### 🧑‍💼 معلومات مقدم الطلب

- الرقم الوطني (أساسي وفريد)
- الاسم الرباعي
- تاريخ الميلاد
- العنوان
- الهاتف
- البريد الإلكتروني
- الجنسية
- الصورة الشخصية

---

### 🪪 فئات رخص القيادة

| الفئة | الوصف                  | العمر الأدنى | رسوم الرخصة | الصلاحية   |
|-------|------------------------|--------------|-------------|------------|
| 1     | دراجات نارية صغيرة     | 18           | 15$         | 5 سنوات    |
| 2     | دراجات نارية ثقيلة     | 21           | 30$         | 5 سنوات    |
| 3     | مركبات خفيفة / سيارات  | 18           | 20$         | 10 سنوات   |
| 4     | سيارات أجرة / ليموزين  | 21           | 200$        | 10 سنوات   |
| 5     | مركبات زراعية          | 21           | 50$         | 10 سنوات   |
| 6     | حافلات صغيرة ومتوسطة   | 21           | 250$        | 10 سنوات   |
| 7     | شاحنات ومركبات ثقيلة   | 21           | 300$        | 10 سنوات   |

---

### 🧪 اختبارات الرخصة

- **اختبار النظر:** 10$
- **الاختبار النظري:** 20$ (علامة من 100)
- **الاختبار العملي:** حسب الفئة

> لا يمكن الانتقال لاختبار لاحق دون اجتياز السابق.  
> يتم تسجيل النتائج والمواعيد في قاعدة البيانات.

---

### 📋 خدمات إضافية

- **إصدار رخصة دولية:** فقط لحاملي رخصة من الفئة الثالثة، ويجب أن تكون الرخصة فعالة وغير محجوزة، ولا يمكن وجود أكثر من رخصة دولية فعالة لنفس السائق.
- **إعادة فحص:** متاحة بعد الرسوب فقط، وترتبط بالطلب الأصلي.
- **فك الحجز:** يتطلب دفع الغرامة وتسجيل تاريخ فك الحجز.

---

### 🔐 إدارة النظام

- **إدارة المستخدمين:** إضافة/تعديل/تجميد/حذف، ربط كل مستخدم بشخص حقيقي، توزيع الصلاحيات.
- **إدارة الأشخاص:** منع تكرار الرقم الوطني، تعديل البيانات، البحث المتقدم.
- **إدارة الطلبات:** فلترة حسب الحالة، ربط الطلب بشخص، إدارة رسوم الطلبات.
- **إدارة الفئات والاختبارات:** الفئات ثابتة مع إمكانية تعديل خصائصها، تعديل رسوم الاختبارات.

---

## 💡 مميزات طبقتها كمطور

- ✅ فصل الكود إلى طبقات احترافية (3-Tier Architecture)
- ✅ استخدام UserControls قابلة لإعادة الاستخدام
- ✅ استخدام Delegates وEvents للتفاعل بين الواجهات
- ✅ تصميم قاعدة بيانات متكاملة بقيود فعلية
- ✅ التعامل المتقدم مع DataGridView
- ✅ معالجة الأخطاء والتحقق من صحة البيانات

---

## ▶️ كيفية التشغيل

1. فتح المشروع في **Visual Studio**.
2. تعديل **connection string** لقاعدة البيانات في ملف الإعدادات.
3. استيراد قاعدة البيانات من ملف `.bak`.
4. تشغيل التطبيق باستخدام المستخدم الافتراضي:
   - **اسم المستخدم:** a
   - **كلمة المرور:** a

---

## 👨‍💻 المؤلف

**Abdulftah Kashkash**  
مهندس تحكم وأتمتة صناعية  
مطور C# و SQL و C++

---

> هذا المشروع جزء من التدريب العملي على تطوير الأنظمة البرمجية المتكاملة باستخدام C# و SQL Server.



# 🚦 DVLD Smart Driving Licenses Management System  
## The Ultimate Software Solution for Licensing & Testing Operations in Traffic Departments 🚗💡

A comprehensive training project developed as part of Course 19 (Full Real Project) from Dr. Abu Hadhoud’s roadmap.  
This system simulates real-world driver and vehicle licensing operations, focusing on software engineering, systems analysis, and database design.

---

## 🧰 Technologies Used

- **C# - Windows Forms (WinForms)**
- **SQL Server**
- **ADO.NET**
- **3-Tier Architecture (Presentation - Business Logic - Data Access)**
- **OOP: Events, Delegates, Composition**

---

## 🧾 System Overview

DVLD offers a wide range of services related to driving licenses, relying on a central database to organize driver, application, exam, and license information.  
The system is designed to reflect real workflows in traffic departments, with future scalability in mind.

---

## 🧩 Key Features

### 📄 Supported Applications

| Service                        | Application Fee |
|---------------------------------|----------------|
| First-time License Issuance     | $5             |
| Re-examination                  | $5             |
| License Renewal                 | $5             |
| Lost License Replacement        | $5             |
| Damaged License Replacement     | $5             |
| License Release (from hold)     | $5             |
| International License Issuance  | $5             |

> **Notes:**
> - Exam and license fees are added to the application fee.
> - Duplicate applications of the same type are not allowed if a previous one is still pending.

---

### 🧑‍💼 Applicant Information

- National ID (primary & unique)
- Full Name
- Date of Birth
- Address
- Phone Number
- Email
- Nationality
- Personal Photo

---

### 🪪 License Categories

| Category | Description                 | Minimum Age | License Fee | Validity   |
|----------|-----------------------------|-------------|-------------|------------|
| 1        | Small Motorcycles           | 18          | $15         | 5 years    |
| 2        | Heavy Motorcycles           | 21          | $30         | 5 years    |
| 3        | Light Vehicles / Cars       | 18          | $20         | 10 years   |
| 4        | Taxis / Limousines          | 21          | $200        | 10 years   |
| 5        | Agricultural Vehicles       | 21          | $50         | 10 years   |
| 6        | Small & Medium Buses        | 21          | $250        | 10 years   |
| 7        | Trucks & Heavy Vehicles     | 21          | $300        | 10 years   |

---

### 🧪 License Exams

- **Vision Test:** $10
- **Theory Test:** $20 (graded out of 100)
- **Practical Test:** Fee depends on category

> Applicants cannot proceed to the next exam without passing the previous one.  
> All results and appointments are recorded in the database.

---

### 📋 Additional Services

- **International License Issuance:**  
  Only available for holders of an active, unheld Category 3 license.  
  Only one active international license per driver is allowed.
- **Re-examination:**  
  Available only after failing an exam and is linked to the original application.
- **License Release (from hold):**  
  Requires paying the fine and recording the release date.

---

### 🔐 System Management

- **User Management:** Add/Edit/Freeze/Delete users, link each user to a real person, assign permissions.
- **Person Management:** Prevent duplicate national IDs, edit data, advanced search.
- **Application Management:** Filter by status, link application to person, manage application fees.
- **Category & Exam Management:** Fixed categories with editable properties, adjustable exam fees.

---

## 💡 Developer Highlights

- ✅ Professional code separation using 3-Tier Architecture
- ✅ Reusable UserControls
- ✅ Use of Delegates and Events for UI interaction
- ✅ Comprehensive database design with real constraints
- ✅ Advanced DataGridView handling
- ✅ Error handling and data validation

---

## ▶️ How to Run

1. Open the project in **Visual Studio**.
2. Update the **connection string** for the database in the settings file.
3. Import the database from the `.bak` file.
4. Run the application using the default user:
   - **Username:** a
   - **Password:** a

---

## 👨‍💻 Author

**Abdulftah Kashkash**  
Control & Industrial Automation Engineer  
C#, SQL, and C++ Developer

---

> This project is part of practical training in developing integrated software systems using C# and SQL Server.




