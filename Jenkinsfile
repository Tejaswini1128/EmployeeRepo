pipeline {
    agent any

    tools {
        dotnet 'dotnet-9' // This must match the name you gave in Jenkins
    }

    stages {
        stage('Checkout') {
            steps {
                git 'https://github.com/Tejaswini1128/EmployeeRepo.git'
            }
        }

        stage('Restore') {
            steps {
                bat 'dotnet restore'
            }
        }

        stage('Build') {
            steps {
                bat 'dotnet build --configuration Release'
            }
        }

        stage('Run') {
            steps {
                bat 'dotnet run'
            }
        }
    }

    post {
        success {
            echo '✅ Build and run successful!'
        }
        failure {
            echo '❌ Build or run failed. Check logs.'
        }
    }
}
