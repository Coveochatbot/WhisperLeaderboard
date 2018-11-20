export class Suggestion {
    public questions: Array<QuestionToClient>;
    public documents: Array<Document>;
    public activeFacets: Array<Facet>;

    constructor() {
        this.questions = new Array();
        this.documents = new Array();
        this.activeFacets = new Array();
    }
}

export class QuestionToClient {
    public id: string;
    public text: string;
}

export class Document {
    public id: string;
    public title: string;
    public uri: string;
    public printableUri: string;
    public summary: string;
    public excerpt: string;
}

export class Facet {
    public id: string;
    public name: string;
    public value: string;
}