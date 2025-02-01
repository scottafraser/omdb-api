### **📌 README.md**

# 🎬 Vue + Vuetify + .NET Movie Search App

This is a **movie search application** built using:

- **Vue 3 + Vuetify** for the frontend
- **.NET 9 Web API** for the backend
- **OMDb API** for movie data

## 📌 Features

✅ Search for movies using the OMDb API  
✅ Paginate through search results  
✅ Click a movie to view details  
✅ Responsive Vuetify UI  
✅ Backend in .NET 9 with CORS enabled

---

## **🛠 Setup Instructions**

### **1️⃣ Clone the Repository**

```sh
git clone https://github.com/scottafraser/omdb-api.git
cd omdb-api
```

---

## **🚀 Backend Setup (.NET 9 API)**

### **1️⃣ Navigate to Backend Directory**

```sh
cd api
```

### **2️⃣ Install Dependencies**

```sh
dotnet restore
```

### **3️⃣ Set Up OMDb API Key**

- Get an **OMDb API Key** from: [http://www.omdbapi.com/apikey.aspx](http://www.omdbapi.com/apikey.aspx)
- Create a **`appsettings.json`** file in the backend project (if not already created) and add:

```json
{
  "OMDbApiKey": "YOUR_OMDB_API_KEY"
}
```

### **4️⃣ Run the .NET API**

```sh
dotnet run
```

By default, the API runs on **http://localhost:5104/**.

---

## **🎨 Frontend Setup (Vue 3 + Vuetify)**

### **1️⃣ Navigate to Frontend Directory**

```sh
cd frontend
```

### **2️⃣ Install Dependencies**

```sh
npm install
```

### **3️⃣ Configure API URL**

- Open **`frontend/src/stores/useMovieStore.ts`**
- Update API URL to match your backend:
  ```ts
  const response = await axios.get(
    `http://localhost:5104/api/movies/search?title=${query.value}&page=${page}`
  );
  ```

### **4️⃣ Start the Vue App**

```sh
npm run dev
```

The frontend runs at **http://localhost:5173/**.

---

## **🛠 API Endpoints**

### 🔍 **Search Movies**

**GET** `/api/movies/search?title={movieTitle}&page={page}`
Example:

```sh
http://localhost:5104/api/movies/search?title=Inception&page=1
```

### 🎥 **Get Movie Details**

**GET** `/api/movies/detail?id={imdbID}`
Example:

```sh
http://localhost:5104/api/movies/detail?id=tt1375666
```

---

## **🌟 Technologies Used**

- **Frontend:** Vue 3, Vuetify, Pinia, Axios, Vue Router
- **Backend:** .NET 9, C#, ASP.NET Web API
- **Database:** OMDb API (external)
- **Tools:** Node.js, npm, dotnet CLI

---

## **🚀 Running Both Frontend & Backend**

To spin up the **entire application**, open **two terminals**:

### **Terminal 1: Start Backend**

```sh
cd backend
dotnet run
```

### **Terminal 2: Start Frontend**

```sh
cd frontend
npm run dev
```

Then open **http://localhost:5173/** in your browser! 🎬

---

## **📜 License**

This project is licensed under the **MIT License**.

---

## **💡 Notes**

- Ensure **.NET 9 SDK** and **Node.js 22+** are installed before running.
- If you encounter **CORS issues**, restart the backend after adding the correct `CORS` policy in `Program.cs`.

---

## **🎯 Next Steps**

- Add frontend and backend tests
- Add logging
- Dockerize for simple set up
- Deploy pipeline
- User Auth? Favorites? All sorts of fun features!

---

🚀 **Now you're ready to search movies like a pro!** 🎥🔥

```

```
