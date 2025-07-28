pipeline {
    agent any

    tools {
        dotnetsdk 'dotnet9'  // This name must match your Jenkins Global Tool Config
    }

    triggers {
        pollSCM('* * * * *')  // Poll every minute for changes
    }

    stages {
        stage('Checkout Source') {
            steps {
                checkout scm
            }
        }

        stage('Build .NET Project') {
            when {
                changeset "**/*.cs"
            }
            steps {
                echo 'Changes detected in .NET source code...'
                sh 'dotnet restore'
                sh 'dotnet build'
            }
        }

        stage('SQL Script Change Detected') {
            when {
                changeset "sql/**"
            }
            steps {
                echo 'Changes detected in SQL folder.'
                echo 'You can run database migration or validation steps here.'
            }
        }
    }

    post {
        always {
            echo 'Pipeline execution completed.'
        }
    }
}
