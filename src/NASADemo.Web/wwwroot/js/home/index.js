import 'alpinejs';

window.vm = function () {
	return {
		buttonText: 'Download images',
		status: 200,
		inProgress: false,
		errorMessage: '',
		successMessage: '',
		downloadedFiles: [],
		uploadAttempted: false,
		submit() {
			if (this.inProgress) return;

			this.uploadAttempted = true;
			this.errorMessage = '';
			this.successMessage = '';
			this.inProgress = true;
			this.buttonText = 'Processing...';

			let fileInput = document.querySelector('input[type="file"]');
			let data = new FormData();
			data.append('file', fileInput.files[0]);

			fetch('/api/nasa/getRoverPhotosByDate', {
				method: 'POST',
				body: data
			})
			.then(response => {
				this.status = response.status;

				return response.json();
			})
			.then(data => {
				if (this.status === 400) {
					if (data.File) {
						this.errorMessage = data.File[0];
					}
				}
				else {
					this.successMessage = 'Successfully downloaded';
					this.downloadedFiles = data.downloadedFiles;
				}

				fileInput.value = '';
				this.inProgress = false;
				this.buttonText = 'Download images';
			})
			.catch(() => {
				fileInput.value = '';
				this.inProgress = false;
				this.buttonText = 'Download images';

				this.errorMessage = 'Ooops! Something went wrong!'
			})
        }
    }
}