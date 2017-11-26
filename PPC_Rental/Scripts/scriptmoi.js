(function ( $ ) {
 
    $.fn.imagePicker = function( options ) {
        
        // Define plugin options
        var settings = $.extend({
            // Input name attribute
            name: "",
            // Classes for styling the input
            class: "form-control btn btn-default btn-block",
            // Icon which displays in center of input
            icon: "glyphicon glyphicon-plus"
        }, options );
        
        // Create an input inside each matched element
        return this.each(function() {
            $(this).html(create_btn(this, settings));
        });
 
    };
 
    // Private function for creating the input element
    function create_btn(that, settings) {
        // The input icon element
        var picker_btn_icon = $('<i class="'+settings.icon+'"></i>');
        
        // The actual file input which stays hidden
        var picker_btn_input = $('<input type="file" name="'+settings.name+'" />');
        
        // The actual element displayed
        var picker_btn = $('<div class="'+settings.class+' img-upload-btn"></div>')
            .append(picker_btn_icon)
            .append(picker_btn_input);
            
        // File load listener
        picker_btn_input.change(function() {
            if ($(this).prop('files')[0]) {
                // Use FileReader to get file
                var reader = new FileReader();
                
                // Create a preview once image has loaded
                reader.onload = function(e) {
                    var preview = create_preview(that, e.target.result, settings);
                    $(that).html(preview);
                }
                
                // Load image
                reader.readAsDataURL(picker_btn_input.prop('files')[0]);
            }                
        });

        return picker_btn
    };
    
    // Private function for creating a preview element
    function create_preview(that, src, settings) {
        
            // The preview image
            var picker_preview_image = $('<img src="'+src+'" class="img-responsive img-rounded" />');
            
            // The remove image button
            var picker_preview_remove = $('<button class="btn btn-link"><small>Remove</small></button>');
            
            // The preview element
            var picker_preview = $('<div class="text-center"></div>')
                .append(picker_preview_image)
                .append(picker_preview_remove);

            // Remove image listener
            picker_preview_remove.click(function() {
                var btn = create_btn(that, settings);
                $(that).html(btn);
            });
            
            return picker_preview;
    };
    
}( jQuery ));

$(document).ready(function() {
    $('.img-picker').imagePicker({name: 'images'});
})




//Text area

    /* http://github.com/mindmup/bootstrap-wysiwyg */
    /*global jQuery, $, FileReader*/
    /*jslint browser:true*/
    (function ($) {
        'use strict';
        var readFileIntoDataUrl = function (fileInfo) {
            var loader = $.Deferred(),
                fReader = new FileReader();
            fReader.onload = function (e) {
                loader.resolve(e.target.result);
            };
            fReader.onerror = loader.reject;
            fReader.onprogress = loader.notify;
            fReader.readAsDataURL(fileInfo);
            return loader.promise();
        };
        $.fn.cleanHtml = function () {
            var html = $(this).html();
            return html && html.replace(/(<br>|\s|<div><br><\/div>|&nbsp;)*$/, '');
        };
        $.fn.wysiwyg = function (userOptions) {
            var editor = this,
                selectedRange,
                options,
                toolbarBtnSelector,
                updateToolbar = function () {
                    if (options.activeToolbarClass) {
                        $(options.toolbarSelector).find(toolbarBtnSelector).each(function () {
                            var command = $(this).data(options.commandRole);
                            if (document.queryCommandState(command)) {
                                $(this).addClass(options.activeToolbarClass);
                            } else {
                                $(this).removeClass(options.activeToolbarClass);
                            }
                        });
                    }
                },
                execCommand = function (commandWithArgs, valueArg) {
                    var commandArr = commandWithArgs.split(' '),
                        command = commandArr.shift(),
                        args = commandArr.join(' ') + (valueArg || '');
                    document.execCommand(command, 0, args);
                    updateToolbar();
                },
                bindHotkeys = function (hotKeys) {
                    $.each(hotKeys, function (hotkey, command) {
                        editor.keydown(hotkey, function (e) {
                            if (editor.attr('contenteditable') && editor.is(':visible')) {
                                e.preventDefault();
                                e.stopPropagation();
                                execCommand(command);
                            }
                        }).keyup(hotkey, function (e) {
                            if (editor.attr('contenteditable') && editor.is(':visible')) {
                                e.preventDefault();
                                e.stopPropagation();
                            }
                        });
                    });
                },
                getCurrentRange = function () {
                    var sel = window.getSelection();
                    if (sel.getRangeAt && sel.rangeCount) {
                        return sel.getRangeAt(0);
                    }
                },
                saveSelection = function () {
                    selectedRange = getCurrentRange();
                },
                restoreSelection = function () {
                    var selection = window.getSelection();
                    if (selectedRange) {
                        try {
                            selection.removeAllRanges();
                        } catch (ex) {
                            document.body.createTextRange().select();
                            document.selection.empty();
                        }

                        selection.addRange(selectedRange);
                    }
                },
                insertFiles = function (files) {
                    editor.focus();
                    $.each(files, function (idx, fileInfo) {
                        if (/^image\//.test(fileInfo.type)) {
                            $.when(readFileIntoDataUrl(fileInfo)).done(function (dataUrl) {
                                execCommand('insertimage', dataUrl);
                            }).fail(function (e) {
                                options.fileUploadError("file-reader", e);
                            });
                        } else {
                            options.fileUploadError("unsupported-file-type", fileInfo.type);
                        }
                    });
                },
                markSelection = function (input, color) {
                    restoreSelection();
                    if (document.queryCommandSupported('hiliteColor')) {
                        document.execCommand('hiliteColor', 0, color || 'transparent');
                    }
                    saveSelection();
                    input.data(options.selectionMarker, color);
                },
                bindToolbar = function (toolbar, options) {
                    toolbar.find(toolbarBtnSelector).click(function () {
                        restoreSelection();
                        editor.focus();
                        execCommand($(this).data(options.commandRole));
                        saveSelection();
                    });
                    toolbar.find('[data-toggle=dropdown]').click(restoreSelection);

                    toolbar.find('input[type=text][data-' + options.commandRole + ']').on('webkitspeechchange change', function () {
                        var newValue = this.value; /* ugly but prevents fake double-calls due to selection restoration */
                        this.value = '';
                        restoreSelection();
                        if (newValue) {
                            editor.focus();
                            execCommand($(this).data(options.commandRole), newValue);
                        }
                        saveSelection();
                    }).on('focus', function () {
                        var input = $(this);
                        if (!input.data(options.selectionMarker)) {
                            markSelection(input, options.selectionColor);
                            input.focus();
                        }
                    }).on('blur', function () {
                        var input = $(this);
                        if (input.data(options.selectionMarker)) {
                            markSelection(input, false);
                        }
                    });
                    toolbar.find('input[type=file][data-' + options.commandRole + ']').change(function () {
                        restoreSelection();
                        if (this.type === 'file' && this.files && this.files.length > 0) {
                            insertFiles(this.files);
                        }
                        saveSelection();
                        this.value = '';
                    });
                },
                initFileDrops = function () {
                    editor.on('dragenter dragover', false)
                        .on('drop', function (e) {
                            var dataTransfer = e.originalEvent.dataTransfer;
                            e.stopPropagation();
                            e.preventDefault();
                            if (dataTransfer && dataTransfer.files && dataTransfer.files.length > 0) {
                                insertFiles(dataTransfer.files);
                            }
                        });
                };
            options = $.extend({}, $.fn.wysiwyg.defaults, userOptions);
            toolbarBtnSelector = 'a[data-' + options.commandRole + '],button[data-' + options.commandRole + '],input[type=button][data-' + options.commandRole + ']';
            bindHotkeys(options.hotKeys);
            if (options.dragAndDropImages) {
                initFileDrops();
            }
            bindToolbar($(options.toolbarSelector), options);
            editor.attr('contenteditable', true)
                .on('mouseup keyup mouseout', function () {
                    saveSelection();
                    updateToolbar();
                });
            $(window).bind('touchend', function (e) {
                var isInside = (editor.is(e.target) || editor.has(e.target).length > 0),
                    currentRange = getCurrentRange(),
                    clear = currentRange && (currentRange.startContainer === currentRange.endContainer && currentRange.startOffset === currentRange.endOffset);
                if (!clear || isInside) {
                    saveSelection();
                    updateToolbar();
                }
            });
            return this;
        };
        $.fn.wysiwyg.defaults = {
            hotKeys: {
                'ctrl+b meta+b': 'bold',
                'ctrl+i meta+i': 'italic',
                'ctrl+u meta+u': 'underline',
                'ctrl+z meta+z': 'undo',
                'ctrl+y meta+y meta+shift+z': 'redo',
                'ctrl+l meta+l': 'justifyleft',
                'ctrl+r meta+r': 'justifyright',
                'ctrl+e meta+e': 'justifycenter',
                'ctrl+j meta+j': 'justifyfull',
                'shift+tab': 'outdent',
                'tab': 'indent'
            },
            toolbarSelector: '[data-role=editor-toolbar]',
            commandRole: 'edit',
            activeToolbarClass: 'btn-info',
            selectionMarker: 'edit-focus-marker',
            selectionColor: 'darkgrey',
            dragAndDropImages: true,
            fileUploadError: function (reason, detail) { console.log("File upload error", reason, detail); }
        };
    }(window.jQuery));