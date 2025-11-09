const API_BASE = "http://localhost:5019/api";
const courseList = document.getElementById("courseList");
const studentList = document.getElementById("studentList");
const courseSelect = document.getElementById("courseSelect");
const studentSelect = document.getElementById("studentSelect");

document.getElementById("addCourseForm").addEventListener("submit", addCourse);
document.getElementById("addStudentForm").addEventListener("submit", addStudent);
document.getElementById("assignForm").addEventListener("submit", assignStudent);

// --- Courses ---
async function loadCourses() {
    const res = await fetch(`${API_BASE}/courses`);
    const courses = await res.json();
    courseList.innerHTML = "";
    courseSelect.innerHTML = "";

    courses.forEach(c => {
        const li = document.createElement("li");
        li.textContent = `${c.title} - ${c.description}`;
        courseList.appendChild(li);

        const option = document.createElement("option");
        option.value = c.id;
        option.textContent = c.title;
        courseSelect.appendChild(option);
    });
}

async function addCourse(e) {
    e.preventDefault();
    const course = {
        title: document.getElementById("title").value,
        description: document.getElementById("description").value
    };
    await fetch(`${API_BASE}/courses`, {
        method: "POST",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify(course)
    });
    e.target.reset();
    loadCourses();
}

// --- Students ---
async function loadStudents() {
    const res = await fetch(`${API_BASE}/students`);
    const students = await res.json();
    studentList.innerHTML = "";
    studentSelect.innerHTML = "";

    students.forEach(s => {
        const li = document.createElement("li");
        li.textContent = s.name;
        studentList.appendChild(li);

        const option = document.createElement("option");
        option.value = s.id;
        option.textContent = s.name;
        studentSelect.appendChild(option);
    });
}

async function addStudent(e) {
    e.preventDefault();
    const student = {
        name: document.getElementById("studentName").value
    };
    await fetch(`${API_BASE}/students`, {
        method: "POST",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify(student)
    });
    e.target.reset();
    loadStudents();
}

// --- Assignments ---
async function assignStudent(e) {
    e.preventDefault();
    const enrolment = {
        courseId: courseSelect.value,
        studentId: studentSelect.value
    };
    await fetch(`${API_BASE}/enrolments`, {
        method: "POST",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify(enrolment)
    });
    alert("Student assigned!");
    loadReport();
}

// --- Report ---
const reportContainer = document.getElementById("report-container");

async function loadReport() {
    reportContainer.innerHTML = `<p class="loading">Loading report...</p>`;
    try {
        const res = await fetch(`${API_BASE}/enrolments/report`);
        if (!res.ok) throw new Error("Failed to load report");
        const data = await res.json();
        renderReport(data);
    } catch (err) {
        console.error(err);
        reportContainer.innerHTML = `<p class="error">Error loading report</p>`;
    }
}

function renderReport(courses) {
    if (!courses.length) {
        reportContainer.innerHTML = `<p>No courses found.</p>`;
        return;
    }

    reportContainer.innerHTML = "";

    courses.forEach(course => {
        const card = document.createElement("div");
        card.className = "report-card";

        const header = document.createElement("div");
        header.className = "report-header";
        header.innerHTML = `
      <h3>${course.courseTitle}</h3>
      <p>${course.courseDescription}</p>
    `;

        const studentList = document.createElement("ul");
        studentList.className = "student-list";

        if (course.enrolledStudents.length > 0) {
            course.enrolledStudents.forEach(student => {
                const li = document.createElement("li");
                li.className = "student-item";
                const initials = student.name
                    .split(" ")
                    .map(w => w[0].toUpperCase())
                    .join("")
                    .slice(0, 2);

                li.innerHTML = `
          <div class="avatar">${initials}</div>
          <span>${student.name}</span>
        `;
                studentList.appendChild(li);
            });
        } else {
            const none = document.createElement("li");
            none.className = "no-students";
            none.textContent = "No students enrolled";
            studentList.appendChild(none);
        }

        card.appendChild(header);
        card.appendChild(studentList);
        reportContainer.appendChild(card);
    });
}


// --- Initial load ---
loadCourses();
loadStudents();
loadReport();