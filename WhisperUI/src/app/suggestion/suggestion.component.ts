import { Suggestion, Document, QuestionToClient } from './../models/suggestion';
import { SuggestionService } from './../services/suggestion.service';
import { Component, Input, Output, EventEmitter, Renderer2, ElementRef, 
    ChangeDetectorRef, AfterContentInit, ViewChild } from '@angular/core';
import { DomSanitizer, SafeResourceUrl} from '@angular/platform-browser';
import { SuiTransition, TransitionDirection, Transition, TransitionController } from 'ng2-semantic-ui';


@Component({
    selector: 'whisper-suggestion',
    templateUrl: './suggestion.component.html',
    styleUrls: ['./suggestion.component.css']
})
export class SuggestionComponent implements AfterContentInit {
    @Input() public suggestion: Suggestion;
    @Output() public suggestionClickEvent: EventEmitter<string> = new EventEmitter(); 
    
    @ViewChild('mySuggestion') public suggestionElement: ElementRef;
    @ViewChild('myDocument') public documentWrapperElement: ElementRef;

    private transitionSuggestion: TransitionController;
    private transitionDocument: TransitionController;

    public selectedDocument: SafeResourceUrl = this.sanitizer.bypassSecurityTrustResourceUrl('about:blank');
    constructor(
        private suggestionService: SuggestionService,
        private renderer: Renderer2,
        private _changeDetector: ChangeDetectorRef,
        private sanitizer: DomSanitizer
    ) {
        this.transitionSuggestion = new TransitionController();
        this.transitionDocument =  new TransitionController(true);
    }

    public ngAfterContentInit(): void { 
        this.transitionSuggestion.registerElement(this.suggestionElement.nativeElement);
        this.transitionSuggestion.registerRenderer(this.renderer);
        this.transitionSuggestion.registerChangeDetector(this._changeDetector);

        this.transitionDocument.registerElement(this.documentWrapperElement.nativeElement);
        this.transitionDocument.registerRenderer(this.renderer);
        this.transitionDocument.registerChangeDetector(this._changeDetector);
    }

    public choiceSuggestion(document: Document): void {
        this.selectedDocument = this.sanitizer.bypassSecurityTrustResourceUrl(document.uri);

        this.transitionSuggestion.animate(new Transition('scale', 300, TransitionDirection.Out, () => {
            this.renderer.addClass(this.suggestionElement.nativeElement, 'hidden');
            this.transitionDocument.animate(new Transition('scale', 300, TransitionDirection.In , 
                () => this.renderer.removeClass(this.documentWrapperElement.nativeElement, 'hidden')));
        }));
    }

    public choiceQuestion(question: QuestionToClient, chatKey: string): void {
        this.suggestionService.selectSuggestion(chatKey, question.id);
        this.suggestionClickEvent.emit(question.text);
    }

    public closeDocument(): void {
        this.transitionDocument.animate(new Transition('scale', 300, TransitionDirection.Out, () => {
            this.renderer.addClass(this.documentWrapperElement.nativeElement, 'hidden');
            this.transitionSuggestion.animate(new Transition('scale', 300, TransitionDirection.In, 
                () => this.renderer.removeClass(this.suggestionElement.nativeElement, 'hidden')));
        }));
    }
}

