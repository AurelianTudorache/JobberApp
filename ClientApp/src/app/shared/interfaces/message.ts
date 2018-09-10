export class Message {
    public text = '';
    public author = '';
    public jobGroup = '';

    constructor() {
    }

    AddData(text: string, author: string, jobGroup: string) {
        this.text = text;
        this.author = author;
        this.jobGroup = jobGroup;
    }
}