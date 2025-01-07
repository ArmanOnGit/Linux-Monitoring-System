# Linux Monitoring System

## Project Overview

The Linux Monitoring System is a web-based monitoring solution designed for servers. This project provides an intuitive dashboard to display real-time data from the server’s CPU, disk, memory, and general system information, enabling users to track the most critical performance metrics efficiently. Additionally, the system is fully dockerized, making it portable and easy to deploy in any containerized environment.

## Key Features

- Real-Time Monitoring: Displays up-to-date information about server resources, including:
  1. CPU Usage
  2. Disk Space and Usage
  3. Memory Utilization
  4. General System Information (e.g., uptime, OS version)
- User-Friendly Web Interface: A clean and organized panel to visualize critical server data.
- Dockerized Deployment: Simplifies setup and ensures consistent behavior across different environments.

## Technologies Used

- **Backend:** ASP.NET Core MVC to manage server-side logic and deliver a robust, scalable platform.
- **Frontend:** Built using HTML and CSS (with Bootstrap for responsive design) and enhanced with JavaScript for interactive and dynamic updates via AJAX.
- **System Info Collection:** Lightweight and efficient Bash scripts fetch real-time metrics from the system.
- **Containerization:** Docker ensures seamless deployment and portability across environments.

## How It Works

1. The monitoring system collects data from the server using lightweight Bash scripts.
2. The backend, built with ASP.NET Core MVC, processes the collected data and serves it to the frontend.
3. AJAX is used for asynchronous data updates, ensuring the dashboard displays the latest metrics without requiring full-page reloads.
4. Docker encapsulates the entire application, allowing seamless deployment and scalability.

## Deployment Instructions

1. Clone the Repository:
   ```bash
   git clone https://github.com/ArmanOnGit/Linux-Monitoring-System.git
   ```
2. Navigate to the Project Directory:
   ```bash
   cd Linux-Monitoring-System
   ```
3. Build the Docker Image:
   ```bash
   docker build -t linux-monitoring-system .
   ```
4. Run the Docker Container:
   ```bash
   docker run -d -p 8080:8080 linux-monitoring-system
   ```
5. Access the Application:
   Open your web browser and go to `http://localhost:8080`.

## Future Improvements

1. Add support for monitoring network traffic.
2. Implement alert systems for critical metrics (e.g., high CPU usage).
3. Integrate historical data storage for long-term trend analysis.
4. Expand compatibility for non-Linux systems.

## Contributors

- ArmanOnGit
- AtaOnGit

## Feedback and Contributions

We welcome contributions and feedback to improve this project. Feel free to open an issue or submit a pull request on our [GitHub repository](https://github.com/ArmanOnGit/Linux-Monitoring-System).

![Site-Preview](https://github.com/user-attachments/assets/083e162e-fa57-4e3c-ad0f-8b10bbb9957e)

